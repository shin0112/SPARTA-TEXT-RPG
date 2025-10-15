namespace TEXT_RPG.Scene
{
    public class StartScene
    {
        static void Main()
        {
            new StartScene().GameStart();
        }

        public void GameStart()
        {
            while (true)
            {
                Console.WriteLine("거친 정글에 뛰어든 건 나지만 힘들다..");
                Console.WriteLine("나..무사히 취업 할 수 있는거냐..");

                Console.WriteLine("1.스펙보기");
                Console.WriteLine("2.사회에 뛰어들기");
                Console.WriteLine("3.인벤토리");
                Console.WriteLine("4.상점 이동");

                Console.WriteLine("0.집으로 돌아간다..");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("스펙보기를 선택했습니다.");
                }
                else if (input == "2")
                {
                    Console.WriteLine("사회에 뛰어들기를 선택했습니다");
                }
                else if (input == "3")
                {
                    Console.WriteLine("인벤토리를 선택했습니다.");
                }
                else if (input == "4")
                {
                    Console.WriteLine("상점으로 이동합니다.");
                }
                else
                {
                    Console.WriteLine("잘못 입력하셨습니다.");
                }
            }
        }
    }
}
