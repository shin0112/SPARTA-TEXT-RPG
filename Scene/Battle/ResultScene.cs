using TEXT_RPG.Core;
using TEXT_RPG.Manager;
using TEXT_RPG.UI;

namespace TEXT_RPG.Scene.Battle
{
    internal class ResultScene : BattleSceneBase
    {
        protected override string Title { get; } = $"Battle!! - Result";
        protected override string[] Selections { get; } = ["나가기"];

        public override void Enter()
        {
            ShowTitle();
            Console.WriteLine($"{(BattleManager.Instance.IsVictory ? "Victory" : "You Lose")}\n");
            BattleSceneUI.ShowBattleResult();
            BattleSceneUI.ShowPlayerInfo();
            ProcessSelection();
        }

        protected override void HandleInput(int select)
        {
            if (select == 0)
            {
                GameManager.Instance.SceneInfo = SceneType.DungeonSelect;
            }
        }
    }
}
