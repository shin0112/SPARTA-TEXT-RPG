namespace TEXT_RPG.Manager
{
    internal class BattleManager
    {
        private static BattleManager _instance;
        public static BattleManager Instance { get; } = _instance ??= new BattleManager();

        public List<object> Monsters = [];
    }
}
