namespace DxBall.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Reflection;
    using System.IO;
    using Attribute;

    public static class SolutionTypes
    {
        private static readonly ConcurrentDictionary<Type, object> InstanceByType;
        private static readonly TypeInfo ThisType = typeof(SolutionTypes).GetTypeInfo();
        private static TypeInfo entryPointClass;
        private static Assembly[] solutionAssemblies;
        private static TypeInfo[] solutionTypes;

        static SolutionTypes()
        {
            InstanceByType = new ConcurrentDictionary<Type, object>();
            var solutionNamespace = ThisType.Namespace?.Split('.')[0];
            GetTypesBySolutionLibraries(ThisType.Assembly, solutionNamespace);
        }

        public static TypeInfo[] Interfaces => solutionTypes.Where(type => type.IsInterface).ToArray();

        public static TypeInfo[] Classes(bool? areAbstract = null)
        {
            if (areAbstract != null)
            {
                return solutionTypes
                    .Where(type => type.IsClass && type.IsAbstract == areAbstract)
                    .ToArray();
            }

            return solutionTypes.Where(type => type.IsClass).ToArray();
        }

        public static T InitializeCallers<T>()
            where T : class
        {
            if (entryPointClass == null)
            {
                GetInitialValues();
            }

            return (T)InstanceByType[typeof(T)];
        }

        public static bool IsThisInstanceOfThisBaseType(TypeInfo @this, TypeInfo @base)
        {
            return @this.IsInstanceOfType(@base);
        }

        private static void GetInitialValues()
        {
            entryPointClass = Classes().FirstOrDefault(c => c.IsDefined(typeof(EntryPointAttribute)));
            var members = GetOrderedMembers(entryPointClass).ToArray();
            var entryPoint = Activator.CreateInstanceFrom(entryPointClass.Assembly.Location, entryPointClass.FullName).Unwrap();
            InstantiateMembersFromInstance(members, entryPoint);
            foreach (var value in InstanceByType.Values)
            {
                var instantiateValue = value.GetType().GetTypeInfo();
                var valueMembers = GetOrderedMembers(instantiateValue).ToArray();
                InstantiateMembersFromInstance(valueMembers, value);
            }
        }

        private static void InstantiateMembersFromInstance(
            MemberInfo[] members,
            object entryPoint)
        {
            foreach (var memberInfo in members)
            {
                var fieldTypeInfo = memberInfo.DeclaringType
                    .GetTypeInfo()
                    .DeclaredFields
                    .FirstOrDefault(df => df.Name == memberInfo.Name);
                var propertyInfo = memberInfo.DeclaringType
                    .GetTypeInfo()
                    .DeclaredProperties
                    .FirstOrDefault(df => df.Name == memberInfo.Name);
                var isSystemFieldType = fieldTypeInfo?.FieldType.FullName.StartsWith("System");
                var isSystemProperyType = propertyInfo?.PropertyType.FullName.StartsWith("System");
                if (isSystemFieldType.HasValue && !isSystemFieldType.Value)
                {
                    var fieldValue = fieldTypeInfo.GetValue(entryPoint);
                    if (!InstanceByType.ContainsKey(fieldTypeInfo.FieldType) && fieldValue != null)
                    {
                        InstanceByType.TryAdd(fieldTypeInfo.FieldType, fieldValue);
                    }
                    
                }
                else if (isSystemProperyType.HasValue && !isSystemProperyType.Value)
                {
                    var propertyValue = propertyInfo.GetValue(entryPoint);
                    if (!InstanceByType.ContainsKey(propertyInfo.PropertyType) && propertyValue != null)
                    {
                        InstanceByType.TryAdd(propertyInfo.PropertyType, propertyValue);
                    }
                }
            }
        }

        private static IOrderedEnumerable<MemberInfo> GetOrderedMembers(TypeInfo @class)
        {
            return @class.DeclaredMembers
                .OrderByDescending(dm => (dm.MemberType & MemberTypes.Field) != 0)
                .ThenByDescending(dm => (dm.MemberType & MemberTypes.Property) != 0)
                .ThenByDescending(dm => (dm.MemberType & MemberTypes.Method) != 0)
                .ThenByDescending(dm => (dm.MemberType & MemberTypes.Constructor) != 0)
                .ThenByDescending(dm => (dm.MemberType & MemberTypes.NestedType) != 0);
        }

        private static void GetTypesBySolutionLibraries(Assembly assemblyApplication, string mainNamespace)
        {
            var indexOfSolutionPath = assemblyApplication.Location.IndexOf(mainNamespace, StringComparison.Ordinal);
            var solutionLocation = assemblyApplication.Location.Substring(0, indexOfSolutionPath + mainNamespace.Length);
            solutionAssemblies = AssembliesFromDllPaths(DllsFromPath(solutionLocation))
                .Where(asm => asm.Location.Contains(mainNamespace)).ToArray();
            solutionTypes = solutionAssemblies.SelectMany(asm => asm.DefinedTypes).Distinct().ToArray();
        }

        private static IEnumerable<Assembly> AssembliesFromDllPaths(IEnumerable<string> dlls)
        {
            return dlls.Select(Assembly.LoadFile);
        }

        private static IEnumerable<string> DllsFromPath(string solutionLocation)
        {
            var solutionDirectories = GetDirectoriesFromPath(solutionLocation);
            var dllByPath = new Dictionary<string, string>();
            foreach (var directory in solutionDirectories)
            {
                var files = Directory.GetFiles(directory);
                foreach (var file in files)
                {
                    if (file.ToLower().EndsWith(".dll") || file.ToLower().EndsWith(".exe"))
                    {
                        var filePathParts = file.Split(new[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries); ;
                        var fileName = filePathParts[filePathParts.Length - 1];
                        if (!dllByPath.ContainsKey(fileName))
                        {
                            dllByPath.Add(fileName, file);
                        }
                    }
                }
            }

            return dllByPath.Select(dll => dll.Value);
        }

        private static HashSet<string> GetDirectoriesFromPath(string solutionPath)
        {
            var solutionDirectories = new HashSet<string> { solutionPath };
            var queue = new Queue<string>();
            queue.Enqueue(solutionPath);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var inlineDirectories = Directory.GetDirectories(current);
                foreach (var directory in inlineDirectories)
                {
                    if (!solutionDirectories.Contains(directory))
                    {
                        solutionDirectories.Add(directory);
                        queue.Enqueue(directory);
                    }
                }
            }

            return solutionDirectories;
        }
    }
}