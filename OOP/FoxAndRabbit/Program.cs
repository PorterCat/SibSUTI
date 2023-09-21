namespace FoxesAndRabbits
{
    internal class Program
    {

        static void Main(string[] args)
        {

            //Задаём модель места действия
            int n = 5;
            int m = 5;
            Simulation model = new Simulation(n, m, 10, 1);

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
