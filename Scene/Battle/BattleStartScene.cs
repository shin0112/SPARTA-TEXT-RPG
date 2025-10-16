using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene.Battle
{
    internal class BattleStartScene : BattleSceneBase
    {
        protected override string[] Selections => ["나가기", "싸우기"];

        public override void Show()
        {
            // todo: 몬스터 리스트
            BattleManager.Instance.SpawnRandomMonsters();

            base.Show();
        }

        protected override void HandleInput(int select)
        {
            switch (select)
            {
                case 1:
                    new MonsterSelectScene().Show();
                    break;
                default:
                    break;
            }
            BattleManager.Instance.Monsters.Clear();
        }

        protected override void ShowMonsterInfo()
        {
            List<Monster> monsters = BattleManager.Instance.Monsters;

            for (int i = 0; i < monsters.Count; i++)
            {
                var monster = monsters[i];
                Console.WriteLine($"Lv. {monster.Level} {monster.Name} | {(monster.IsDead ? "DEAD" : "HP " + monster.Stats.Hp)}");
            }
            Console.WriteLine();
        }
    }
}
