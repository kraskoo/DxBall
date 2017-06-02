namespace DxBall.Entities
{
    using Modules.DrawModule.Enums;
    using Interfaces;

    public class Entity : IEntity
    {
        private int lives;

        public Entity(Position position, ColorType color, int initialLive)
        {
            this.Position = position;
            this.Color = color;
            this.InitialLive = this.lives = initialLive;
        }

        public Position Position { get; }

        public ColorType Color { get; }

        public int InitialLive { get; }

        public bool IsAlive => this.lives > 0;
    }
}