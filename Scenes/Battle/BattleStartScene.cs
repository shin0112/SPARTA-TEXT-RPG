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


        protected override void HandleInput(int select)
        {
            switch (select)
            {
                case 1:
                    new PlayerTurnScene().Show();
                    break;
                default:
                    break;
            }
        }


        protected override void ShowMonsterInfo()
        {
            List<object> monsters = BattleManager.Instance.Monsters;

            for (int i = 0; i < monsters.Count; i++)
            {
                Console.WriteLine($"{monsters[i]}");
            }
            Console.WriteLine();
        }
    }
}
