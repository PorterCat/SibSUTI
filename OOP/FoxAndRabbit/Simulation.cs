namespace FoxesAndRabbits
{
    internal class Simulation
    {
        public (int Height, int Width) Size;
        private int _steps = 0;

        private int _foxesCurrentIndex = 0;

        private List<Fox> _foxes = new List<Fox>();
        private List<Rabbit> _rabbits = new List<Rabbit>();

        private (List<Fox> foxes, List<Rabbit> rabbits)[,] _field;

        public Simulation(int n, int m, int foxesCount, int rabbitsCount)
        {
            Size = (n, m);
            _steps = 0;
            _foxes = new List<Fox>();
            _rabbits = new List<Rabbit>();

            _field = new (List<Fox> foxes, List<Rabbit> rabbits)[n, m];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    _field[i, j].foxes = new List<Fox>();
                    _field[i, j].rabbits = new List<Rabbit>();
                }
            }

            var rand = Random.Shared;

            for(int i = 0; i< foxesCount; i++)
            {
                CreateFox((rand.Next(0, n-1), rand.Next(0, m-1)), (Direction)rand.Next(0, 4), rand.Next(0, 3), _foxesCurrentIndex);
                _foxesCurrentIndex++;
            }

            for (int i = 0; i < rabbitsCount; i++)
            {
                CreateRabbit((rand.Next(0, n - 1), rand.Next(0, m - 1)), (Direction)rand.Next(0, 4), rand.Next(0, 3));
            }
        }

        public Rabbit CreateRabbit((int x, int y) position, Direction direction, int stable)
        {
            var rabbit = new Rabbit(position, direction, stable, this);
            _field[position.x, position.y].rabbits.Add(rabbit);
            _rabbits.Add(rabbit);
            return rabbit;
        }

        public Fox CreateFox((int x, int y) position, Direction direction, int stable, int index)
        {
            var fox = new Fox(position, direction, stable, this, index);
            _field[position.x, position.y].foxes.Add(fox);
            _foxes.Add(fox);
            return fox;
        }

        public void Step()
        {
            Move();
            Eating();
            GrowAge();
            Reproduction();
            Dying();
            Render();
            _steps++;
            Thread.Sleep(1000);
        }

        private void Move()
        {
            ChangeField();
            foreach (var f in _foxes)
            {
                f.Move();
                _field[f.Position.X, f.Position.Y].foxes.Add(f);
            }
            foreach (var r in _rabbits)
            {
                r.Move();
                _field[r.Position.X, r.Position.Y].rabbits.Add(r);
            }

        }

        private void ChangeField()
        {
            for (int i = 0; i < Size.Height; i++)
            {
                for (int j = 0; j < Size.Width; j++)
                {
                    _field[i, j].foxes.Clear();
                    _field[i, j].rabbits.Clear();
                }
            }
        }

        private void GrowAge()
        {
            _foxes.ForEach(f => f.GrowAge());
            _rabbits.ForEach(r => r.GrowAge());
        }

        private void Reproduction()
        {
            for (int i = 0; i < _foxes.Count; i++)
            {
                Fox? fox = _foxes[i];
                if (fox.Satiety >= 2)
                {
                    fox.Satiety = 0;
                    var babyFox = CreateFox(fox.Position, fox.Direction, fox.Stable, fox.Index);
                    _foxes.Add(babyFox);
                }
            }
            for (int i = 0; i < _rabbits.Count; i++)
            {
                Rabbit? rabbit = _rabbits[i];
                if (rabbit.Age == 5 || rabbit.Age == 10)
                {
                    var babyRabbit = CreateRabbit(rabbit.Position, rabbit.Direction, rabbit.Stable);
                    _rabbits.Add(babyRabbit);
                }
            }
        }

        private void Eating()
        {
            for (int i = 0; i < Size.Height; i++)
            {
                for (int j = 0; j < Size.Width; j++)
                {
                    var rabbits = _field[i, j].rabbits;
                    var foxes = _field[i, j].foxes;
                    if (foxes.Count > 0 && rabbits.Count > 0)
                    {
                        var elderFox = foxes
                            .OrderBy(f => f.Age)
                            .ThenBy(f => f.Index)
                            .ToArray()[0];

                        elderFox.Satiety += rabbits.Count;
                        for (int g = 0; g < rabbits.Count; g++)
                        {
                            Rabbit? rabbit = rabbits[g];
                            rabbits.Remove(rabbit);
                            _rabbits.Remove(rabbit);
                        }
                    }
                }
            }

        }

        private void Dying()
        {
            for (int i = 0; i < _foxes.Count; i++)
            {
                Fox? fox = _foxes[i];
                if (fox.Age >= 15)
                {
                    _foxes.Remove(fox);
                }
            }
            for (int i = 0; i < _rabbits.Count; i++)
            {
                Rabbit? rabbit = _rabbits[i];
                if (rabbit.Age >= 10)
                {
                    _rabbits.Remove(rabbit);
                }

            }
        }

        private void Render()
        {
            for (int i = 0; i < Size.Height; i++)
            {
                for (int j = 0; j < Size.Width; j++)
                {
                    if (_field[i, j].foxes.Count > 0)
                    {
                        string str = '-' + _field[i, j].foxes.Count.ToString();
                        Console.Write(str.PadLeft(3));
                    }
                    else if(_field[i, j].rabbits.Count > 0)
                    {
                        Console.Write(_field[i, j].rabbits.Count.ToString().PadLeft(3));
                    }
                    else
                    {
                        Console.Write("*".PadLeft(3));
                    }
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
