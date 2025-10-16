using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene.Battle
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
            if (select == 0)
            {
                GameManager.Instance.SceneInfo = SceneType.Start;
                BattleManager.Instance.Monsters.Clear();
                BattleManager.Instance.ResetIsVictory();
            }
        }
    }
}
