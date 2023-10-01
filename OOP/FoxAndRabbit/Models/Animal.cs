using System;

namespace FoxesAndRabbits
{
    abstract class Animal
    {
        public int Age { get; protected set;}
        public Direction Direction { get; protected set;}
        public (int X, int Y) Position { get; protected set; }
        public int Stable{ get; protected set;}
        protected Simulation? Model;

        public abstract void Move(); //Движение

        public void GrowAge()
        {
            Age++;
        }
    }
}
