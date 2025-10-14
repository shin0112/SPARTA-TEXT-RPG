namespace TEXT_RPG;

public class Spec
{
    public void Specification()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("스펙 보기");
            Console.WriteLine("캐릭터의 스펙이 표시됩니다.");

            Console.WriteLine($"level"); //캐릭터 스크립트랑 추후에 연결 후 코드 수정해야함
            
            Console.WriteLine("0. 나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            
            string input = Console.ReadLine();

            if (input == "1")
            {
                //캐릭터 스크립트랑 연결
            }
            else if (input == "0")
            {
                Console.Clear();
                //스타트씬 스크립트와 연결
            }
            

        }
    }
}