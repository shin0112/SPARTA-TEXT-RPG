using TEXT_RPG.Repository;

namespace TEXT_RPG.Manager
{
    internal class BattleManager
    {
        private static BattleManager _instance = new();
        public static BattleManager Instance { get; } = _instance;

        public List<Monster> Monsters = [];
        private readonly MonsterRepository monsterRepository = new();

        public int MonsterNumber { get; set; } = 0;
        // Todo: plyaer 정보 담기

        // Todo: 던전에 따라서 다른 몬스터 스폰
        public void SpawnRandomMonsters()
        {
            Random random = new();
            int monsterCount = random.Next(1, 4);

            for (int i = 0; i < monsterCount; i++)
            {
                Monsters.Add(monsterRepository.MonstersNo1[random.Next(0, 3)]);
            }
        }
    }
}
