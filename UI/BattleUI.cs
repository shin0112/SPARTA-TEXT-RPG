using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.UI
{
    internal static class BattleUI
    {
        public static void ShowPlayerInfo()
        {
            Player player = GameManager.Instance.Player!;
            Console.WriteLine("[내 정보]");
            Console.WriteLine($"Lv. {player.Level} {player.Name} ({player.Job})");
            Console.WriteLine($"체력 {player.Stats.Hp}/{player.Stats.MaxHp}\n");
        }
    }
}
