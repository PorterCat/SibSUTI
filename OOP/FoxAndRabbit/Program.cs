namespace FoxesAndRabbits
{
    internal class Program
    {

        static void Main(string[] args)
        {

            //Задаём модель места действия
            Console.WriteLine("Enter the size (NxM numbers):");
            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the num of foxes:");
            int f = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the num of rabbits:");
            int r = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            Simulation model = new Simulation(n, m, f, r);
            model.CreateFox((1,1), Direction.Top, 2, 1);

            //ХОД ДЕЙСТВИЯ
            for (int i = 0; i < 100; i++)
            {
                model.Step();
            }

            
        }
    }

    public enum Direction
    {
        Left,
        Right,
        Top,
        Bottom
    }
}
