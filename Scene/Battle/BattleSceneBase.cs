using TEXT_RPG.Core;
using TEXT_RPG.Manager;

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
            ShowPlayerInfo();

            //BattleManager.Instance.BattleInfo();

            HandleSelections();
        }

        protected virtual void ShowPlayerInfo()
        {
            // Todo: player 정보 가져오기 (임시 데이터)
            Player player = GameManager.Instance.Player ??= new("아무개", "백수");

            Console.WriteLine("[내 정보]");
            Console.WriteLine($"Lv. {player.Level} {player.Name} ({player.Job})");
            Console.WriteLine($"체력 {player.Stats.Hp}/{player.Stats.MaxHp}\n");
        }
    }
}