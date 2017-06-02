namespace DxBall.Entities
{
    public struct Position
    {
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public void MoveOn(int newX, int newY)
        {
            this.X = newX;
            this.Y = newY;
        }
    }
}