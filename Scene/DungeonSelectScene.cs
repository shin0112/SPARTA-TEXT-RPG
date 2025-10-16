using TEXT_RPG.Core;

namespace TEXT_RPG.Scene
{
    internal class DungeonSelectScene
    {
        string input;
        Player player = new Player("Player", "백수"); //임시 플레이어. 추후 삭제

        string[] stages = { "취준하기", "면접 보기", "승진하기", "이직하기" };
        int[] recommenedLevel = { 0, 5, 10, 15 };
        public void DungeonSelect()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("던전 선택");
                Console.WriteLine();
                for (int i = 0; i < stages.Length; i++)
                {
                    if (recommenedLevel[i] <= player.Level)
                    {
                        Console.WriteLine($"{i + 1}. {stages[i]}");
                        continue;
                    }
                    Console.WriteLine($"{i + 1}. {stages[i]} (권장 레벨: {recommenedLevel[i]})");
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
                        //레벨 1 던전 취준
                        return;
                    case "2":
                        if (player.Level <= 5)
                        {
                            Console.WriteLine("플레이어의 레벨이 권장 레벨보다 낮습니다.");
                            break;
                        }
                        //레벨 2 던전 면접
                        return;
                    case "3":
                        if (player.Level <= 10)
                        {
                            Console.WriteLine("플레이어의 레벨이 권장 레벨보다 낮습니다.");
                            break;
                        }
                        //레벨 3 던전 승진
                        return;
                    case "4":
                        if (player.Level <= 15)
                        {
                            Console.WriteLine("플레이어의 레벨이 권장 레벨보다 낮습니다.");
                            break;
                        }
                        //레벨 4 던전 이직
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
