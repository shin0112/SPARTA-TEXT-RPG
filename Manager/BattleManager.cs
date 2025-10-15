using TEXT_RPG.Core;
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

        private int _deadCount = 0;

        public event Action? OnAllMonsterDead;

        // Todo: plyaer 정보 담기

        // Todo: 던전에 따라서 다른 몬스터 스폰
        public void SpawnRandomMonsters()
        {
            Random random = new();
            int monsterCount = random.Next(1, 5); // 최대 4마리 스폰

            // 레벨 1 던전 몬스터
            for (int i = 0; i < monsterCount; i++)
            {
                Monsters.Add(monsterRepository.MonstersNo1[random.Next(3)]);
            }
            if (random.Next(1000) == 0) // Todo: 특수 몬스터 발생 확률 지정 (현재: 0.1%);
            {
                Monsters.Add(monsterRepository.SpecialMonsterNo1[random.Next(monsterRepository.SpecialMonsterNo1.Count)]);
            }

            foreach (var monster in Monsters)
            {
                monster.OnDeadChanged += OnMonsterDeadChanged;
            }
        }

        private void OnMonsterDeadChanged(bool isDead)
        {
            if (isDead) _deadCount++;
            else _deadCount--;

            if (_deadCount == Monsters.Count)
            {
                OnAllMonsterDead?.Invoke();
            }
        }
    }
}
