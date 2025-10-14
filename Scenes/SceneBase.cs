namespace TEXT_RPG.Scenes
{
    internal abstract class SceneBase
    {
        public virtual void Show() { }
        protected virtual void HandleInput(int select) { }
    }
}
