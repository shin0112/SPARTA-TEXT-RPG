using TEXT_RPG.Scenes.Battle;

namespace TEXT_RPG.Scene
{
    public class StartScene
    {
        public void GameStart()
        {
            while (true)
            {
                Console.WriteLine("지금부터 취업준비를 해볼까?");
                Console.WriteLine("무사히 취업 할 수 있을까..");

                Console.WriteLine("1.스펙보기");
                Console.WriteLine("2.사회에 뛰어들기");
                Console.WriteLine("3.인벤토리");
                Console.WriteLine("4.상점 이동");

                Console.WriteLine("0.집으로 돌아간다..");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    
                    new SpecScene().Specification();
                }
                else if (input == "2")
                {
                    new BattleStartScene().Show();
                }
                else if (input == "3")
                {
                    Console.WriteLine("인벤토리를 선택했습니다.");
                    new InventoryScene().Inventory();
                }
                else if (input == "4")
                {
                    Console.WriteLine("상점으로 이동합니다.");
                    //ShopScene 주석처리 사라지면 그때 이어붙이기
                }
                else if (input == "0")
                {
                    Console.WriteLine("집이 아직 없습니다.");
                }
                else
                {
                    Console.WriteLine("잘못 입력하셨습니다.");
                    Console.Clear();
                }
                //여기
            }
        }
    }
}
