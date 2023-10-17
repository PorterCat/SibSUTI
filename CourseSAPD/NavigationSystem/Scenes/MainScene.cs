using CourseSAPD.NavigationSystem.Enums;
using CourseSAPD.NavigationSystem.Interface;
using System;

namespace CourseSAPD.NavigationSystem.Scenes
{
    public class MainScene
    {
        private IScene _currentScene;
        private SceneType _currentSceneType = SceneType.ListScene;

        public MyQueue<Note> ListDB;

        public MainScene(MyQueue<Note> list)
        {
            ListDB = list;
        }

        public void Start()
        {
            while (true)
            {
                switch (_currentSceneType)
                {
                    case SceneType.ListScene:
                        Console.Clear();
                        _currentScene = new ListScene(ListDB);
                        _currentScene.ShowScene(out _currentSceneType, out ListDB);
                        break;
                    case SceneType.ListSearch:
                        Console.Clear();
                        _currentScene = new SearchScene(ListDB);
                        _currentScene.ShowScene(out _currentSceneType, out ListDB);
                        break;
                }
            }
        }
    }
}
