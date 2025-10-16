namespace TEXT_RPG.Scenes.Battle
{
    internal class VictoryScene : BattleSceneBase
    {
        protected override string Title { get; } = "Battle!! - Result\n\nVictory";
        protected override string[] Selections => ["나가기"];

        protected override void ShowMonsterInfo()
        {
        }

        protected override void HandleInput(int select)
        {
            if (select == 0) return;
        }
    }
}
