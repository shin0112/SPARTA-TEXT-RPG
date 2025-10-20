using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene
{
    internal class DungeonSelectScene
    {
        string input;

        string[] stages = {"취준 하기", "면접 보기", "승진하기", "이직하기" };
        int[] requiredLevel = { 1, 2, 3, 5 };
        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("취준던전 입장!");
                Console.WriteLine();
                for (int i = 0; i < stages.Length; i++)
                {
                    if (requiredLevel[i] <= GameManager.Instance.Player!.Level)
                    {
                        Console.WriteLine($"{i + 1}. {stages[i]}");
                        continue;
                    }
                    UIHelper.ColorWriteLine($"{i + 1}. {stages[i]} (권장 레벨: {requiredLevel[i]})", "DarkGray");
                }
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                input = Console.ReadLine();
                BattleManager.Instance.SelectDungeon(input);
                if (input != "0" && GameManager.Instance.Player!.IsDead) input = "-1";
                switch (input)
                {
                    case "0":
                        Console.Clear();
                        GameManager.Instance.SceneInfo = SceneType.Start;
                        return;
                    case "1":
                        Console.Clear();
                        GameManager.Instance.SceneInfo = SceneType.Battle;
                        return;
                    case "2":
                        if (GameManager.Instance.Player.Level < requiredLevel[1])
                        {
                            Console.WriteLine("플레이어의 레벨이 권장 레벨보다 낮습니다.");
                            break;
                        }
                        Console.Clear();
                        GameManager.Instance.SceneInfo = SceneType.Battle;
                        return;
                    case "3":
                        if (GameManager.Instance.Player.Level < requiredLevel[2])
                        {
                            Console.WriteLine("플레이어의 레벨이 권장 레벨보다 낮습니다.");
                            break;
                        }
                        Console.Clear();
                        GameManager.Instance.SceneInfo = SceneType.Battle;
                        return;
                    case "4":
                        if (GameManager.Instance.Player.Level < requiredLevel[3])
                        {
                            Console.WriteLine("플레이어의 레벨이 권장 레벨보다 낮습니다.");
                            break;
                        }
                        Console.Clear();
                        GameManager.Instance.SceneInfo = SceneType.Battle;
                        return;
                    case "-1":
                        Console.WriteLine("체력이 없어 던전을 돌지 못합니다.");
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
