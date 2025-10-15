using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class DungeonSelectScene
    {
        string input;
        public void DungeonChoose()
        {
            Console.WriteLine("던전 선택");
            Console.WriteLine();
            Console.WriteLine("1. 취준하기");
            Console.WriteLine("2. 면접 보기");
            Console.WriteLine("3. 승진하기");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    //레벨 1 던전 취준
                    break;
                case "2":
                    //레벨 2 던전 면접
                    break;
                case "3":
                    //레벨 3 던전 승진
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
        }
    }
}
