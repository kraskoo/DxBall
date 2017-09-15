namespace DxBall.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.IO;

    public class SolutionTypes
    {
        private static readonly TypeInfo ThisType = typeof(SolutionTypes).GetTypeInfo();
        private Assembly[] solutionAssemblies;
        private TypeInfo[] solutionTypes;

        private SolutionTypes(Assembly assembly)
        {
            var projectNamespace = ThisType.Namespace?.Split('.')[0];
            this.GetTypesByProjectLibraries(assembly, projectNamespace);
        }

        public SolutionTypes() : this(Assembly.GetAssembly(typeof(SolutionTypes)))
        {
        }

        public TypeInfo[] Interfaces => this.solutionTypes.Where(type => type.IsInterface).ToArray();

        public TypeInfo[] Classes(bool? areAbstract = null)
        {
            if (areAbstract != null)
            {
                return this.solutionTypes
                    .Where(type => type.IsClass && type.IsAbstract == areAbstract)
                    .ToArray();
            }

            return this.solutionTypes.Where(type => type.IsClass).ToArray();
        }

        public bool IsThisInstanceOfThisBaseType(TypeInfo @this, TypeInfo @base)
        {
            return @this.IsInstanceOfType(@base);
        }

        private void GetTypesByProjectLibraries(Assembly assemblyApplication, string mainNamespace)
        {
            var indexOfProjectPath = assemblyApplication.Location.IndexOf(mainNamespace, StringComparison.Ordinal);
            var projectLocation = assemblyApplication.Location.Substring(0, indexOfProjectPath + mainNamespace.Length);
            this.solutionAssemblies = this.AssembliesFromDllPaths(this.DllsFromPath(projectLocation))
                .Where(asm => asm.Location.Contains(mainNamespace)).ToArray();
            this.solutionTypes = this.solutionAssemblies.SelectMany(asm => asm.DefinedTypes).Distinct().ToArray();
        }

        private IEnumerable<Assembly> AssembliesFromDllPaths(IEnumerable<string> dlls)
        {
            return dlls.Select(Assembly.LoadFile);
        }

        private IEnumerable<string> DllsFromPath(string projectLocation)
        {
            var projectDirectories = this.GetDirectoriesFromPath(projectLocation);
            var dllByPath = new Dictionary<string, string>();
            foreach (var directory in projectDirectories)
            {
                var files = Directory.GetFiles(directory);
                foreach (var file in files)
                {
                    if (file.ToLower().EndsWith(".dll"))
                    {
                        var filePathParts = file.Split(new[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries);;
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

        private HashSet<string> GetDirectoriesFromPath(string projectPath)
        {
            var projectDirectories = new HashSet<string> { projectPath };
            var queue = new Queue<string>();
            queue.Enqueue(projectPath);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var inlineDirectories = Directory.GetDirectories(current);
                foreach (var directory in inlineDirectories)
                {
                    if (!projectDirectories.Contains(directory))
                    {
                        projectDirectories.Add(directory);
                        queue.Enqueue(directory);
                    }
                }
            }

            return projectDirectories;
        }
    }
}