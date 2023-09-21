using System;

namespace FoxesAndRabbits
{
    internal class Fox : Animal
    {
        public int Satiety { get; set; }

        public int Index { get; private set; }

        public Fox((int, int) poistion, Direction direction, int stable, Simulation model, int index)
        {
            Age = 0; //Возраст по умолчанию 0
            Position= poistion;
            Stable = stable;
            Direction = direction;
            Model = model;
            Index = index;
        }

        public override void Move() 
        {
            if (Stable == 0)
            {
                var rand = new Random();
                Direction = (Direction)rand.Next(0, 4);
                Stable = rand.Next(1, 10);
            }

            int lowerBoundHeight = 0;
            int lowerBoundWidth = 0;
            int upperBoundHeight = Model.Size.Height - 1;
            int upperBoundWidth = Model.Size.Width - 1;

            switch (Direction)
            {
                case Direction.Left:
                    if (Position.X - 2 <= lowerBoundWidth)
                    {
                        Position = (upperBoundWidth - (lowerBoundWidth - (Position.X - 2)), Position.Y);
                    }
                    else
                    {
                        Position = (Position.X - 2, Position.Y);
                    }
                    break;
                case Direction.Right:
                    Position = ((Position.X + 2) % upperBoundWidth, Position.Y);
                    break;
                case Direction.Top:
                    if (Position.Y - 2 <= lowerBoundHeight)
                    {
                        Position = (Position.X, upperBoundHeight - (lowerBoundHeight - (Position.Y - 2)));
                    }
                    else
                    {
                        Position = (Position.X, Position.Y - 2);
                    }
                    break;
                case Direction.Bottom:
                    Position = (Position.X, (Position.Y + 2) % upperBoundHeight);
                    break;

            }
            Stable--;
        }
    }
}
