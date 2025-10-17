using TEXT_RPG.Core;
using TEXT_RPG.Repository;
using TEXT_RPG.Scene.Battle;

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
        public bool IsDefeat { get; private set; } = false;
        public void ResetIsVictory() => IsVictory = false;
        public event Action? OnDefeat;

        public SceneType CurrentBattleScene => GameManager.Instance.SceneInfo;

        private Dictionary<SceneType, BattleSceneBase> _battleScenes = new();

        public void InitScenes(GameManager game)
        {
            _battleScenes = new()
            {
                { SceneType.Battle, game.BattleStartScene },
                { SceneType.MonsterSelect, game.MonsterSelect },
                { SceneType.Phase, game.PhaseScene },
                { SceneType.Result, game.ResultScene }
            };

            OnDefeat += () =>
            {
                GameManager.Instance.SceneInfo = SceneType.Result;
            };
            OnAllMonsterDead += () =>
            {
                IsVictory = true;
                GameManager.Instance.SceneInfo = SceneType.Result;
            };
        }

        public void Battle()
        {
            SpawnRandomMonsters();
            while (true)
            {
                if (GameManager.Instance.SceneInfo == SceneType.Start) break;
                else if (GameManager.Instance.SceneInfo == SceneType.DungeonSelect) break;
                _battleScenes[CurrentBattleScene].Show();
            }
            BattleEnd();
        }

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

        public void BattleEnd()
        {
            Monsters.Clear();
            MonsterNumber = 0;
            IsVictory = false;
            _deadCount = 0;
        }

        public void BattleInfo()
        {
            Console.WriteLine("=== 전투 정보 ===");
            Console.WriteLine($"총 몬스터 수: {Monsters.Count}");
            Console.WriteLine($"죽은 몬스터 수: {_deadCount}");
            Console.WriteLine($"승리 상태: {IsVictory}");

            Console.WriteLine();
        }
    }
}
