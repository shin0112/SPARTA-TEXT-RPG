namespace TEXT_RPG.Manager
{
    internal class GameManager
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance ?? new GameManager();
    }
}
