using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene
{
    public class StartScene
    {
        public void GameStart()
        {
            Console.Clear();
            UIHelper.ColorWriteLine("이제부터 시작이야!","DarkBlue");
            UIHelper.ColorWriteLine("강해져서 최고의 개발자가 되겠어","DarkBlue");
            Console.WriteLine();
            Console.WriteLine("1.스펙보기");
            Console.WriteLine("2.사회에 뛰어들기");
            Console.WriteLine("3.인벤토리");
            Console.WriteLine("4.상점 이동");
            Console.WriteLine("0.집으로 돌아간다..");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("스펙보기를 선택했습니다.");
                GameManager.Instance.SceneInfo = SceneType.Spec;
            }
            else if (input == "2")
            {
                Console.WriteLine("사회에 뛰어들기를 선택했습니다");
                GameManager.Instance.SceneInfo = SceneType.Battle;
            }
            else if (input == "3")
            {
                Console.WriteLine("인벤토리를 선택했습니다.");
                GameManager.Instance.SceneInfo = SceneType.Inven;
            }
            else if (input == "4")
            {
                Console.WriteLine("상점으로 이동합니다.");
                 //상점
            }
            else if (input == "0")
            {
                Console.WriteLine("벌써 돌아가시려구요?");
                Console.ReadKey();
                return;
            }
            else
            {
                UIHelper.ColorWriteLine("잘못 입력하셨습니다.", "Red");
                Console.ReadKey();
            }
        }
    }
}