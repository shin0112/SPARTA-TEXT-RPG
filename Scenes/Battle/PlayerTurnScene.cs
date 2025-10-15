using TEXT_RPG.Manager;

namespace TEXT_RPG.Scenes.Battle
{
    internal class PlayerTurnScene : BattleSceneBase
    {
        public override void Show()
        {
            Console.WriteLine("Battle!!\n");

            base.Show();
        }


        protected override void HandleInput(int select)
        {
            // 입력 처리
        }


        protected override void ShowMonsterInfo()
        {
            List<object> monsters = BattleManager.Instance.Monsters;

            for (int i = 0; i < monsters.Count; i++)
            {
                Console.WriteLine($"{i + 1} {monsters[i]}");
            }
            Console.WriteLine();
        }
    }
}
