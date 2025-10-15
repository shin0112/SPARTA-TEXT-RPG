namespace TEXT_RPG.Manager
{
    internal class BattleManager
    {
        private static BattleManager _instance = new();
        public static BattleManager Instance { get; } = _instance;

        public List<object> Monsters = [];
        public int MonsterNumber { get; set; } = 0;
        // Todo: plyaer 정보 담기

        public void SpawnRandomMonsters()
        {
            Random random = new();
            int monsterCount = random.Next(1, 5);

            // 몬스터 랜덤으로 가져오기 (임시 데이터 사용)
            for (int i = 0; i < monsterCount; i++)
            {
                Monsters.Add(new object());
            }
        }
    }
}
