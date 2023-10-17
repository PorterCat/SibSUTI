using CourseSAPD.NavigationSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSAPD.NavigationSystem.Modules
{
    public static class Render
    {
        public static Action IndexChanged;
        private static int _index;
        public static int Index
        {
            get => _index;
            private set
            {
                _index = value;
                IndexChanged?.Invoke();
            }
        }

        public static Enum SelectFromEnum(Enum someEnum, int index, Action callback = null)
        {
            var enumValues = someEnum.ExtractFromEnum();
            Index = index;
            
            while (true)
            {
                int t = 0;
                callback?.Invoke();
                Console.SetCursorPosition(t += (someEnum.GetFriendlyName().Length + 2), 23);
                for (int i = 0; i < enumValues.Length; i++)
                {
                    if (i == Index)
                    {
                        Console.BackgroundColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Black;
                    };
                    Console.Write(someEnum.SetValue(i).GetFriendlyName());
                    Console.SetCursorPosition(t += (someEnum.SetValue(i).GetFriendlyName().Length + 2), 23);
                    Console.ResetColor();
                }
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.RightArrow:
                        if (Index < enumValues.Length - 1)
                        {
                            Index++;
                        }
                        else
                        {
                            Index = enumValues.Length - Index - 1;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Index > 0)
                        {
                            Index--;
                        }
                        else
                        {
                            Index = enumValues.Length - 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return someEnum.SetValue(Index);
                }
            }
        }
    }
}
