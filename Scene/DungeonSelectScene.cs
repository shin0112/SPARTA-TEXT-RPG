using TEXT_RPG.Core;

namespace TEXT_RPG.Scene
{
    internal class DungeonSelectScene
    {
        string input;
        string[] stages = { "취준하기", "면접 보기", "승진하기", "이직하기" };
        public void DungeonSelect()
        {
            Console.Clear();
            Console.WriteLine("던전 선택");
            Console.WriteLine();
            for (int i = 0; i < stages.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {stages[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            Player player = new Player("Player", "백수"); //임시 플레이어. 추후 삭제

            while (true)
            {
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
                        //레벨 3 던전 이직
                        return;
                    default:
                        Console.WriteLine("올바른 입력이 아닙니다.");
                        break;
                }
            }
        }
    }
}
