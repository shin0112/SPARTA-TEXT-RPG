using System.Text;
using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace ConsoleRPG
{
    public class Intro
    {
        public void StartIntro()
        {
            Console.OutputEncoding = Encoding.UTF8;
            //콘솔 유니코드 깨짐 방지!


            string logo = @"⠄⠄⠄⠄⢀⢠⡠⠖⢚⣽⣋⡥⠤⠤⣀
⠄⠄⡀⠄⡎⠞⠄⠄⠞⠋⠁⠄⠄⠄⠈⠑⠶⠤⣄
⠄⠄⢓⡶⠗⠄⠄⠄⠄⠄⠄⡀⠄⠄⠄⠄⠄⠄⠄⠑⣄
⠄⢀⠎⠄⠄⠄⢀⣠⢾⢀⣶⠄⢀⠄⠄⠄⠄⠄⠄⠄⠉⠤⣀⣤
⢤⡾⢴⠄⠄⢠⠞⠁⢸⡎⠙⣄⡿⠓⢴⣄⡀⢀⠄⠄⠁⢶⠊⠄
⠄⠄⢆⡠⠄⡞⠄⠄⠘⠄⠄⠈⢶⠄⠈⠏⠳⢎⣆⠄⠄⣈⡷⠤
⠄⠊⢹⣧⢀⠃⠄⢉⣉⡁⠄⠄⠄⠄⢉⣉⡉⠈⠸⠄⣷⡧⠄
⠄⠄⠘⡟⣎⡀⠐⠁⣾⡎⠄⠄⠄⠄⢱⣶⠌⠂⢠⣼⠙⠄
⠄⠄⠄⠳⡡⢡⠄⠄⠉⠄⠄⠄⠄⠄⠄⠉⠄⠄⡎⢌⠞
⠄⠄⠄⠄⠙⠺⡄⠄⠄⣄⡀⠈⠄⢀⢠⠄⠄⢰⠗⠉
⠄⠄⠄⠄⠄⠄⠄⠢⡀⠄⠄⠐⠒⠈⠄⣀⠔⠋
⠄⠄⠄⠄⠄⠄⠄⠄⠈⡖⠤⣀⣀⠤⢢⠁
⠄⠄⠄⠄⢀⣠⢤⠞⡟⠁⠄⠄⠄⠄⠘⡖⢢⠤⣄⡀
⠄⠠⠲⠈⠉⣧⠐⠄⠹⡀⠄⠄⠄⠄⡰⢁⠌⠰⡏⠉⡶⠢⠄
⠄⠄⠄⠁⠄⠁⠂⠄⠄⠄⠂⠄⠄⠄⠁⠄⠄⠁⠄⠄";


            foreach (char emoticon in logo)
            {
                Console.Write(emoticon);
                Thread.Sleep(7); //char string 흘러가는 속도
            }

            Thread.Sleep(500);


            Console.Clear();
            Console.WriteLine("\n\n취준하러 오셨나요?");
            Thread.Sleep(2000);
            Console.WriteLine("험난한 여정일텐데 괜찮으시겠어요?");
            Thread.Sleep(3000);
            Console.WriteLine("각오가 되었다니 좋습니다.");


            Console.WriteLine("우선 당신의 정보를 입력해주세요.");

            Console.Write("이름:");
            string inputName = Console.ReadLine();
            Console.Write("직업:");
            string inputJob = Console.ReadLine();

            GameManager.Instance.Player = new Player(inputName, inputJob);

            Console.WriteLine($"아하! {inputJob}이시군요. 멋진데요? 좋습니다 {inputName}님. 이제 모든 준비가 끝났습니다.");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey(true);

            Console.Clear();
        }

    }


}
