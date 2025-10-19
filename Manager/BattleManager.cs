using TEXT_RPG.Core;
using TEXT_RPG.Repository;
using TEXT_RPG.Scene.Battle;
using TEXT_RPG.UI;

namespace TEXT_RPG.Manager
{
    internal class BattleManager
    {
        private static BattleManager _instance = new();
        public static BattleManager Instance => _instance;

        private readonly MonsterRepository monsterRepository = new();

        // 몬스터 리스트 정보
        public List<Monster> Monsters = [];
        public int MonsterNumber { get; set; } = 0;
        private int _dungeonNumber = 0;

        // 몬스터 사망 관리
        public event Action? OnAllMonsterDead;
        private int _deadCount = 0;

        // 전투 승리 처리
        public bool IsVictory { get; private set; } = false;
        public bool IsDefeat { get; private set; } = false;
        public void ResetIsVictory() => IsVictory = false;
        public event Action? OnDefeat;

        public SceneType CurrentScene => GameManager.Instance.SceneInfo;

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
                // 화면 관리
                if (CurrentScene == SceneType.Start) break;
                else if (CurrentScene == SceneType.DungeonSelect) break;

                // 플레이어 사망 체크
                if (GameManager.Instance.Player!.IsDead)
                {
                    Defeat();
                }

                // 승리/패배 체크
                if (CheckVictoryAndDefeat())
                {
                    GameManager.Instance.SceneInfo = SceneType.Result;
                }

                _battleScenes[CurrentScene].Show();
            }
            BattleEnd();
        }

        public void SelectDungeon(string? input)
        {
            bool isNumber = int.TryParse(input, out int dungeonNumber);

            if (isNumber)
            {
                _dungeonNumber = dungeonNumber;
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

            int actualDamage = Math.Max(monster.Stats.Atk - player.Stats.Def, 0);


            Console.WriteLine($"Lv. {monster.Level} {monster.Name}의 공격!");
            Console.WriteLine($"{player.Name} 을(를) 맞췄습니다. [데미지:{actualDamage}]\n");

            monster.Attack(player);

            Console.WriteLine();
            BattleSceneUI.ShowPlayerInfo();
        }

        private bool CheckVictoryAndDefeat()
        {
            bool flag = IsVictory || IsDefeat;

            if (flag)
            {
                GameManager.Instance.SceneInfo = SceneType.Result;
            }

            return flag;
        }

        private void SpawnRandomMonsters()
        {
            List<List<Monster>> monsters;
            try
            {
                // monsters[0] : 일반 몬스터, monsters[1] : 특수 몬스터
                monsters = monsterRepository.DungeonMonsters[_dungeonNumber];
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("던전 정보를 찾을 수 없습니다.");
                GameManager.Instance.SceneInfo = SceneType.DungeonSelect;
                return;
            }

            Random random = new();
            int monsterCount = random.Next(1, 5); // 최대 4마리 스폰

            // 던전 일반 몬스터 스폰 
            for (int i = 0; i < monsterCount; i++)
            {
                Monsters.Add(monsters[0][random.Next(monsters[0].Count)].Clone());
            }

            if (random.Next(1000) == 777) // Todo: 특수 몬스터 발생 확률 지정 (현재: 0.1%);
            {
                if (monsterCount == 4) // 최대 몬스터 수 4마리 유지
                {
                    Monsters.RemoveAt(3);
                }
                Monsters.Add(monsters[1][random.Next(monsters[1].Count)].Clone());
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

        private void Defeat()
        {
            if (IsDefeat) return;
            IsDefeat = true;
            OnDefeat?.Invoke();
        }

        private void BattleEnd()
        {
            Monsters.Clear();
            MonsterNumber = 0;
            IsVictory = false;
            IsDefeat = false;
            _deadCount = 0;
        }

        public void TurnEnd()
        {
            GameManager.Instance.SceneInfo = SceneType.MonsterSelect;
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
