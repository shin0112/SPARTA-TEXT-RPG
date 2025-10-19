using TEXT_RPG.UI;

namespace TEXT_RPG.Scene.Battle
{
    internal abstract class BattleSceneBase : SceneBase
    {
        protected override string Title { get; } = "Battle!!";

        public override void Enter()
        {
            ShowTitle();
            BattleSceneUI.ShowMonsterInfo();
            BattleSceneUI.ShowPlayerInfo();

            //BattleManager.Instance.BattleInfo();

            ProcessSelection();
        }
    }
}