using TEXT_RPG.Core;
using TEXT_RPG.Repository;

namespace TEXT_RPG.Manager
{
    internal class BattleManager
    {
        private static BattleManager _instance = new();
        public static BattleManager Instance { get; } = _instance;

        private readonly MonsterRepository monsterRepository = new();

        // 몬스터 리스트 정보
        public List<Monster> Monsters = [];
        public int MonsterNumber { get; set; } = 0;

        // 몬스터 사망 관리
        public event Action? OnAllMonsterDead;
        private int _deadCount = 0;

        // 전투 승리 처리
        public bool IsVictory { get; private set; } = false;
        public void ResetIsVictory() => IsVictory = false;

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

            if (random.Next(1000) > 900) // Todo: 특수 몬스터 발생 확률 지정 (현재: 0.1%);
            {
                if (monsterCount == 4) // 최대 몬스터 수 4마리 유지
                {
                    Monsters.RemoveAt(3);
                }
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

            // 모든 몬스터가 죽었는지 확인
            if (_deadCount == Monsters.Count)
            {
                IsVictory = true;
                _deadCount = 0;
                Monsters.Clear();
                OnAllMonsterDead?.Invoke();
            }
        }
    }
}
