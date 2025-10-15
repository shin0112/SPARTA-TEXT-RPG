namespace TEXT_RPG.Scenes.Battle
{
    internal class BattleStartScene : BattleSceneBase
    {
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


        protected override void ShowMonsterInfo(List<object> monsters)
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                Console.WriteLine($"{monsters[i]}");
            }
            Console.WriteLine();
        }
    }
}
