namespace DxBall.Entities.Interfaces
{
    using Modules.DrawModule.Enums;

    public interface IEntity
    {
        Position Position { get; }

        ColorType Color { get; }

        int InitialLive { get; }

        bool IsAlive { get; }
    }
}