using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.UI
{
    internal class SceneCommonUI
    {
    }

    internal static class BattleSceneUI
    {
        public static void ShowPlayerInfo(Player? player = null, TextWriter? output = null)
        {
            player ??= GameManager.Instance.Player;
            output ??= Console.Out;

            if (player is null)
            {
                output.WriteLine("[내 정보]");
                output.WriteLine("플레이어 정보가 없습니다.\n");
                return;
            }

            output.WriteLine("[내 정보]");
            output.WriteLine($"Lv. {player.Level} {player.Name} ({player.Job})");
            output.WriteLine($"체력 {player.Stats.Hp}/{player.Stats.MaxHp}\n");
        }
    }
}
