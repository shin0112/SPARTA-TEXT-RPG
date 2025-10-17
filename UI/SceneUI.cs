using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.UI
{
    internal static class SceneCommonUI
    {
        public static void ShowTitle(string? title = null)
        {
            if (!string.IsNullOrEmpty(title))
            {
                Console.WriteLine($"{title}\n");
            }
        }
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

        public static void ShowMonsterInfo()
        {
            List<Monster> monsters = BattleManager.Instance.Monsters;

            for (int i = 0; i < monsters.Count; i++)
            {
                var monster = monsters[i];
                Console.Write($"{(GameManager.Instance.SceneInfo == SceneType.Battle ? "" : (i + 1).ToString() + ". ")}");
                Console.WriteLine($"Lv. {monster.Level} {monster.Name} | {(monster.IsDead ? "DEAD" : "HP " + monster.Stats.Hp)}");
            }
            Console.WriteLine();
        }
    }
}
