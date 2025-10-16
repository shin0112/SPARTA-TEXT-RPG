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
            HandleSelections();
        }

        protected virtual void ShowPlayerInfo()
        {
            // Todo: player 정보 가져오기 (임시 데이터)
            Player player = GameManager.Instance.Player!;

            Console.WriteLine("[내 정보]");
            Console.WriteLine($"Lv. {player.Level} {player.Name} ({player.Job})");
            // Todo: 플레이어 레벨 업 hp 확정하기
            // 1 레벨업 당 hp 가 0 늘어난다고 가정
            Console.WriteLine($"체력 {player.Stats.Hp}/{100 + (player.Level - 1) * 5}\n");
        }
    }
}