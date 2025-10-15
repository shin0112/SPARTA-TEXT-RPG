using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scenes.Battle
{
    internal class BattleStartScene : BattleSceneBase
    {
        public override void Show()
        {
            Console.WriteLine("Battle!!\n");

            // todo: 몬스터 리스트
            BattleManager.Instance.SpawnRandomMonsters();

            base.Show();
        }

        protected override void ShowSelections()
        {
            Console.WriteLine("1. 싸우기");
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
