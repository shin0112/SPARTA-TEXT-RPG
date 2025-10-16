using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene.Battle
{
    internal class PhaseScene : BattleSceneBase
    {
        // Todo: Monster 정보 저장하기 (임시 데이터)
        private List<Monster> monsters = BattleManager.Instance.Monsters;
        protected override string[] Selections { get; } = ["다음"];

        public override void Show()
        {
            PlayerTurn();
            foreach (var monster in monsters)
            {
                if (monster.IsDead) continue;
                MonsterTurn(monster);
            }
        }

        private void PlayerTurn()
        {
            ShowTitle();
            // Todo: player 정보 넣기
            Monster monster = monsters[BattleManager.Instance.MonsterNumber - 1];

            Console.WriteLine($"{"플레이어"}의 공격!");
            Console.WriteLine($"Lv. {monster.Level} {monster.Name} 을(를) 맞췄습니다.\n");

            ShowMonsterInfo();
            HandleSelections();
        }

        private void MonsterTurn(Monster monster)
        {
            ShowTitle();
            Console.WriteLine($"Lv. {monster.Level} {monster.Name}의 공격!");
            Console.WriteLine($"{"플레이어"} 을(를) 맞췄습니다. [데미지:{monster.Stats.Atk}]");

            ShowPlayerInfo();
            HandleSelections();
        }

        protected override void HandleInput(int select)
        {
        }

        protected override void ShowMonsterInfo()
        {
            Monster monster = monsters[BattleManager.Instance.MonsterNumber - 1];
            Console.WriteLine($"Lv. {monster.Level} {monster.Name}");

            // Todo: 플레이어 공격력 가져오기
            int playerAtk = 10;
            int beforeHp = monster.Stats.Hp;

            monster.TakeDamage(playerAtk);

            if (monster.IsDead)
            {
                Console.WriteLine($"HP {beforeHp} → Dead\n");
            }
            else
            {
                Console.WriteLine($"HP {beforeHp} → {monster.Stats.Hp}\n");
            }
        }
    }
}
