using System;

namespace FoxesAndRabbits
{
    internal class Rabbit : Animal
    {
        public Rabbit((int, int) poistion, Direction direction, int stable, Simulation model)
        {
            Age = 0; //Возраст по умолчанию 0
            Model = model;
        }

        public override void Move()
        {
            if(Stable == 0)
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
                    if (Position.X - 1 <= lowerBoundWidth)
                    {
                        Position = (upperBoundWidth - (lowerBoundWidth - (Position.X - 1)), Position.Y);
                    }
                    else
                    {
                        Position = (Position.X - 1, Position.Y);
                    }
                    break;
                case Direction.Right:
                    Position = ((Position.X + 1) % upperBoundWidth, Position.Y);
                    break;
                case Direction.Top:
                    if (Position.Y - 1 <= lowerBoundHeight)
                    {
                        Position = (Position.X, upperBoundHeight - (lowerBoundHeight - (Position.Y - 1)));
                    }
                    else
                    {
                        Position = (Position.X, Position.Y - 1);
                    }
                    break;
                case Direction.Bottom:
                    Position = (Position.X, (Position.Y + 1) % upperBoundHeight);
                    break;

            }
            Stable--;
        }
    }
}
