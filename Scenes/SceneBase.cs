namespace TEXT_RPG.Scenes
{
    internal abstract class SceneBase
    {
        public abstract void Show();
        protected abstract void HandleInput(int select);
    }
}
