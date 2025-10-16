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
            Player player = GameManager.Instance.Player!;
            PlayerTurn(player);
            foreach (var monster in monsters)
            {
                if (monster.IsDead) continue;
                MonsterTurn(monster, player);
            }
        }

        private void PlayerTurn(Player player)
        {
            ShowTitle();
            Monster monster = monsters[BattleManager.Instance.MonsterNumber - 1];

            Console.WriteLine($"{player.Name}의 공격!");
            Console.WriteLine($"Lv. {monster.Level} {monster.Name} 을(를) 맞췄습니다.\n");

            ShowMonsterInfo();
            HandleSelections();
        }

        private void MonsterTurn(Monster monster, Player player)
        {
            ShowTitle();
            Console.WriteLine($"Lv. {monster.Level} {monster.Name}의 공격!");

            int actualDamage = monster.Stats.Atk - player.Stats.Def;
            if (actualDamage < 0) actualDamage = 0;

            Console.WriteLine($"{player.Name} 을(를) 맞췄습니다. [데미지:{actualDamage}]");

            monster.Attack(player);

            Console.WriteLine();
            ShowPlayerInfo();
            HandleSelections();
        }

        protected override void HandleInput(int select)
        {
        }

        protected override void ShowMonsterInfo()
        {
            // 몬스터 정보 가져오기
            Monster monster = monsters[BattleManager.Instance.MonsterNumber - 1];
            Console.WriteLine($"Lv. {monster.Level} {monster.Name}");

            int playerAtk = GameManager.Instance.Player!.Stats.Atk;
            int beforeHp = monster.Stats.Hp;

            // 몬스터 공격하기
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
