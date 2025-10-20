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
                Console.WriteLine(
                    $"Lv. {monster.Level} {(monster.MonsterType == MonsterType.Boss ? " [Boss]" : "")} {monster.Name} " +
                    $"| {(monster.IsDead ? "DEAD" : "HP " + monster.Stats.Hp)}");
            }
            Console.WriteLine();
        }

        public static void ShowBattleResult()
        {
            var manager = BattleManager.Instance;
            Dictionary<string, int> monsterCount = [];

            if (manager.IsVictory)
            {
                Console.WriteLine("=== 해치운 몬스터 ===");
                manager.Monsters.ForEach(m => monsterCount[m.Name] = monsterCount.GetValueOrDefault(m.Name) + 1);
                Console.WriteLine($"[ {string.Join(", ", monsterCount.Select(m => $"{m.Key} - {m.Value}마리"))} ]\n");

                Console.WriteLine("=== 얻은 보상 ===");
                string items = $"Items: [ {string.Join(", ", manager.Reward.DropItem.Select(item => $"{item.Name}"))} ]";
                Console.WriteLine($"[ Exp: {manager.Reward.Exp}, Gold: {manager.Reward.Gold}, {items} ]\n");
            }
        }

        public static void ShowPlayerInfoAfterBattle()
        {
            var beforePlayer = BattleManager.Instance.BeforePlayer!;
            var afterPlayer = GameManager.Instance.Player!;

            Console.WriteLine("[내 정보]");
            Console.WriteLine($"Lv. {beforePlayer.Level} -> {afterPlayer.Level}, {beforePlayer.Name}, ({beforePlayer.Job})");
            Console.WriteLine($"체력 {beforePlayer.Stats.Hp}/{afterPlayer.Stats.MaxHp} -> {afterPlayer.Stats.Hp}/{afterPlayer.Stats.MaxHp}\n");
        }
    }
}
