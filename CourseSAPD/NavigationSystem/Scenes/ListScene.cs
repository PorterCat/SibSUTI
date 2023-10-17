using CourseSAPD.NavigationSystem.Enums;
using CourseSAPD.NavigationSystem.Interface;
using CourseSAPD.NavigationSystem.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CourseSAPD.NavigationSystem.Scenes
{
    internal class ListScene : IScene
    {
        private MyQueue<Note> _notes;
        private int _top = 0;
        private int _bottom = 20;
        private int _index = 0;
        private bool _isShown = true;

        public ListScene(MyQueue<Note> notes)
        {
            _notes = notes;
        }

        public void ShowScene(out SceneType returnScene, out MyQueue<Note> returnNotes)
        {
            returnScene = default;
            ActionPoints selectedPoint = default;
            Action action;
            while (true)
            {
                if(_isShown)
                {
                    action = () => ShowList(_top, _bottom);
                }
                else
                {
                    action = null;
                }

                selectedPoint = (ActionPoints)Render.SelectFromEnum(selectedPoint, _index, action);
                switch (selectedPoint)
                {
                    case ActionPoints.Next:
                        if(_bottom != 4000)
                        {
                            _top += 20;
                            _bottom += 20;
                        }
                        else
                        {
                            _top = 0;
                            _bottom = 20;
                        }
                        _index = 1;
                        break;
                    case ActionPoints.Previous:
                        if (_top != 0)
                        {
                            _top -= 20;
                            _bottom -= 20;
                        }
                        else
                        {
                            _top = 3980;
                            _bottom = 4000;
                        }
                        _index = 0;
                        break;

                    case ActionPoints.HideOrShow:
                        if(_isShown)
                        {
                            _isShown = false;
                        }    
                        else
                        {
                            _isShown = true;
                        }
                        _index = 2;
                        break;

                    case ActionPoints.Sort:
                        _notes.DigitalSort(ref _notes);
                        _index = 3;
                        break;

                    case ActionPoints.Searсh:
                        _index = 0;
                        returnNotes = _notes;
                        returnScene = SceneType.ListSearch;
                        return;
                }
                Console.Clear();
            }
        }

        private void ShowList(int top, int bottom)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Список базы данных:");

            for (int i = top; i < bottom; i++)
            {
                Console.Write($"{i + 1}. ");
                _notes[i].Show();
            }

        }
    }
}
