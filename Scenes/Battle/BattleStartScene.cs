namespace TEXT_RPG.Scenes.Battle
{
    internal class BattleStartScene : BattleSceneBase
    {
        protected override void HandleInput(int select)
        {
            switch (select)
            {
                case 1:
                    // 플레이어 턴으로 이동함
                    break;
                default:
                    break;
            }
        }
    }
}
