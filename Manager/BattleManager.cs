using TEXT_RPG.Core;
using TEXT_RPG.Repository;
using TEXT_RPG.Scene.Battle;
using TEXT_RPG.UI;

namespace TEXT_RPG.Manager
{
    internal class BattleManager
    {
        private readonly static BattleManager _instance = new();
        public static BattleManager Instance => _instance;

        private readonly MonsterRepository _monsterRepository = new();

        // 몬스터 & 던전 관련 정보
        public List<Monster> Monsters { get; private set; } = [];
        public int MonsterNumber { get; set; } = 0;
        public Player? BeforePlayer { get; private set; } = null;
        private int _currentDungeonId = 0;
        public Reward Reward { get; private set; } = new(0, 0, []);
        private readonly int[] _bossStages = [2, 4];

        // 전투 승리 처리
        public bool IsVictory { get; private set; } = false;
        public bool IsDefeat { get; private set; } = false;
        private int _deadMonsterCount = 0;

        // 이벤트
        public event Action? OnAllMonstersDead;
        public event Action? OnDefeat;

        // Scene 관련
        public SceneType CurrentScene => GameManager.Instance.SceneInfo;

        private Dictionary<SceneType, BattleSceneBase> _battleScenes = [];

        // 초기화
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
            OnAllMonstersDead += () =>
            {
                IsVictory = true;
                GameManager.Instance.Player!.Get(Reward);
                GameManager.Instance.SceneInfo = SceneType.Result;
            };
        }

        public void StartBattle()
        {
            SaveBeforePlayerInfo();
            SpawnRandomMonsters();  // 랜덤 몬스터  스폰
            CalculateTotalRewards(); // 보상 정보 정리

            while (true)
            {
                // 화면 관리
                if (CurrentScene is SceneType.Start or SceneType.DungeonSelect) break;

                // 플레이어 사망 체크
                if (GameManager.Instance.Player!.IsDead)
                {
                    Defeat();
                    break;
                }

                if (HasBattleEnded())
                {
                    GameManager.Instance.SceneInfo = SceneType.Result;
                }

                _battleScenes[CurrentScene].Enter();
            }

            EndBattle();
        }

        public void ResetVictoryFlag() => IsVictory = false;

        public void SelectDungeon(string? input)
        {
            bool isNumber = int.TryParse(input, out int dungeonNumber);

            if (isNumber)
            {
                _currentDungeonId = dungeonNumber;
            }
        }

        public void PlayerTurn()
        {
            Monster monster = Monsters[MonsterNumber - 1];
            Player player = GameManager.Instance.Player!;

            int beforeHp = monster.Stats.Hp;

            // 몬스터 공격하기
            player.Attack(monster);

            Console.WriteLine();
            Console.WriteLine($"Lv. {monster.Level} {monster.Name}");
            Console.WriteLine($"HP {beforeHp} →  {(monster.IsDead ? "Dead" : monster.Stats.Hp)}\n");
        }

        public void MonsterTurn(Monster monster)
        {
            Player player = GameManager.Instance.Player!;

            if (player.IsDead)
            {
                Defeat();
                return;
            }

            int actualDamage = Math.Max(monster.Stats.Atk - (player.Stats.Def + InventoryManager.Instance.EquipValue(ItemType.Armor)), 0);

            Console.WriteLine($"Lv. {monster.Level} {monster.Name}의 공격!");
            Console.WriteLine($"{player.Name} 을(를) 맞췄습니다. [데미지:{actualDamage}]\n");

            monster.Attack(player);

            Console.WriteLine();
            BattleSceneUI.ShowPlayerInfo();
        }

        private bool HasBattleEnded() => IsVictory || IsDefeat;

        private void SpawnRandomMonsters()
        {
            List<List<Monster>> monsters;
            try
            {
                // monsters[0] : 일반 몬스터, monsters[1] : 특수 몬스터
                monsters = _monsterRepository.DungeonMonsters[_currentDungeonId];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("던전 정보를 찾을 수 없습니다.");
                GameManager.Instance.SceneInfo = SceneType.DungeonSelect;
                return;
            }

            Random random = new();
            int monsterCount = 0; // 일반 스테이지: 최대 4마리 스폰 | 보스 스테이지:: 3마리 고정 (보스 1, 일반 2)

            if (_bossStages.Contains(_currentDungeonId))
            {
                AddSpawnMonster(monsters[0][0]); // Add 보스 몬스터

                monsterCount = 2;

                for (int i = 0; i < monsterCount; i++)
                {
                    AddSpawnMonster(monsters[0][random.Next(1, monsters[0].Count)]);
                }
            }
            else
            {
                monsterCount = random.Next(1, 5);

                // 던전 일반 몬스터 스폰 
                for (int i = 0; i < monsterCount; i++)
                {
                    AddSpawnMonster(monsters[0][random.Next(monsters[0].Count)]);
                }

                if (random.Next(1000) == 777) // Todo: 특수 몬스터 발생 확률 지정 (현재: 0.1%);
                {
                    if (monsterCount == 4) // 최대 몬스터 수 4마리 유지
                    {
                        Monsters.RemoveAt(3);
                    }
                    AddSpawnMonster(monsters[1][random.Next(monsters[1].Count)]);
                }
            }

            foreach (var monster in Monsters)
            {
                monster.OnDeadChanged += OnMonsterDeadChanged;
            }
        }

        private void AddSpawnMonster(Monster monster) => Monsters.Add(monster.Clone());

        private void CalculateTotalRewards()
        {
            Monsters.ForEach(m => Reward.Add(m.Reward));
        }

        private void SaveBeforePlayerInfo()
        {
            BeforePlayer = GameManager.Instance.Player!.Clone();
        }

        private void OnMonsterDeadChanged(bool isDead)
        {
            if (isDead) _deadMonsterCount++;

            // 모든 몬스터가 죽었는지 확인
            if (_deadMonsterCount == Monsters.Count)
            {
                IsVictory = true;
                OnAllMonstersDead?.Invoke();
            }
        }

        private void Defeat()
        {
            if (IsDefeat) return;
            IsDefeat = true;
            OnDefeat?.Invoke();
        }

        private void EndBattle()
        {
            Monsters.Clear();
            MonsterNumber = 0;
            Reward = new(0, 0, []);
            _currentDungeonId = -11;
            _deadMonsterCount = 0;
            BeforePlayer = null;
            IsVictory = false;
            IsDefeat = false;
        }

        public void TurnEnd()
        {
            GameManager.Instance.SceneInfo = SceneType.MonsterSelect;
        }
    }
}
