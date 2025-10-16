using TEXT_RPG.Core;
using TEXT_RPG.Scene.Battle;

namespace TEXT_RPG.Scene
{
    internal class DungeonSelectScene
    {
        string input;
        Player player = new Player("Player", "백수"); //임시 플레이어. 추후 삭제

        string[] stages = { "취준하기", "면접 보기", "승진하기", "이직하기" };
        int[] requiredLevel = { 0, 5, 10, 15 };
        public void DungeonSelect()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("던전 선택");
                Console.WriteLine();
                for (int i = 0; i < stages.Length; i++)
                {
                    if (requiredLevel[i] <= player.Level)
                    {
                        Console.WriteLine($"{i + 1}. {stages[i]}");
                        continue;
                    }
                    Console.WriteLine($"{i + 1}. {stages[i]} (권장 레벨: {requiredLevel[i]})");
                }
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Console.Clear();
                        return;
                    case "1":
                        Console.Clear();
                        new BattleStartScene().Show();
                        return;
                    case "2":
                        if (player.Level <= requiredLevel[1])
                        {
                            Console.WriteLine("플레이어의 레벨이 권장 레벨보다 낮습니다.");
                            break;
                        }
                        Console.Clear();
                        new BattleStartScene().Show();
                        return;
                    case "3":
                        if (player.Level <= requiredLevel[2])
                        {
                            Console.WriteLine("플레이어의 레벨이 권장 레벨보다 낮습니다.");
                            break;
                        }
                        Console.Clear();
                        new BattleStartScene().Show();
                        return;
                    case "4":
                        if (player.Level <= requiredLevel[3])
                        {
                            Console.WriteLine("플레이어의 레벨이 권장 레벨보다 낮습니다.");
                            break;
                        }
                        Console.Clear();
                        new BattleStartScene().Show();
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
