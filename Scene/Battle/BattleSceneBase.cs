using TEXT_RPG.UI;

namespace TEXT_RPG.Scene.Battle
{
    internal abstract class BattleSceneBase : SceneBase
    {
        protected override string Title { get; } = "Battle!!";
        protected abstract void ShowMonsterInfo();

        public override void Show()
        {
            ShowTitle();
            ShowMonsterInfo();
            BattleSceneUI.ShowPlayerInfo();

            //BattleManager.Instance.BattleInfo();

            HandleSelections();
        }
    }
}