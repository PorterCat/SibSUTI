namespace CourseSAPD.NavigationSystem.Interface
{
    internal interface IScene
    {
        void ShowScene(out Enums.SceneType returnScene, out MyQueue<Note> Notes);
    }
}
