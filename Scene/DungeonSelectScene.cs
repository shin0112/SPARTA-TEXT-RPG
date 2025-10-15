namespace TEXT_RPG.Scene
{
    internal class DungeonSelectScene
    {
        string input;
        string[] stages = { "취준하기", "면접 보기", "승진하기", "이직하기" };
        public void DungeonSelect()
        {
            Console.WriteLine("던전 선택");
            Console.WriteLine();
            //    for (int i = 0; i < stages.Length; i++)
            //    {
            //        if (플레이어 레벨이 n 이상일때)
            //        {
            //        Console.WriteLine($"{i + 1}. {stages[i]}");
            //    }
            //        else
            //    {
            //        Console.WriteLine($"{i + 1}. {stages[i]} (레벨 제한 {n})");
            //    }
            //}
            Console.WriteLine("1. 취준하기");
            Console.WriteLine("2. 면접 보기");
            Console.WriteLine("3. 승진하기");
            Console.WriteLine("4. 이직하기");
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
                    break;
                case "1":
                    //레벨 1 던전 취준
                    break;
                case "2":
                    //레벨 2 던전 면접
                    break;
                case "3":
                    //레벨 3 던전 승진
                    break;
                case "4":
                    //레벨 3 던전 이직
                    break;
                default:
                    Console.Clear();
                    DungeonSelect();
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
            //switch (input)
            //{
            //    case "1":
            //        //레벨 1 던전 취준
            //        break;
            //    case "2" when 캐릭터레벨 >= n:
            //        //레벨 2 던전 면접
            //        break;
            //    case "3" when 캐릭터레벨 >= n:
            //        //레벨 3 던전 승진
            //        break;
            //    case "4" when 캐릭터레벨 >= n:
            //        //레벨 3 던전 이직
            //        break;
            //    default:
            //        Console.WriteLine("잘못된 입력입니다.");
            //        break;
            //}
        }
    }
}
