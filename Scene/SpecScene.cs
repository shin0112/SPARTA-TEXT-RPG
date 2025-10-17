using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene;

public class SpecScene
{
    public void Specification()
    {
        Console.Clear();
        Console.WriteLine("스펙 보기");
        Console.WriteLine("캐릭터의 스펙이 표시됩니다.");

        Console.WriteLine($"이름:{GameManager.Instance.Player?.Name}"); //캐릭터 스크립트랑 추후에 연결 후 코드 수정해야함
        Console.WriteLine($"직업:{GameManager.Instance.Player?.Job}");
        Console.WriteLine($"레벨:{GameManager.Instance.Player?.Level}");
        Console.WriteLine($"스텟:{GameManager.Instance.Player?.Stats}");
        Console.WriteLine($"골드:{GameManager.Instance.Player?.Gold}");
        Console.WriteLine($"경험치:{GameManager.Instance.Player?.Exp}");
        Console.WriteLine($"획득경험치{GameManager.Instance.Player?.RequiredExp}");
        
        
        Console.WriteLine("0. 나가기");
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.Write(">>");

        string input = Console.ReadLine();

        if (input == "1")
        {
            Console.Clear();
            //GameManager.Instance.SceneInfo = SceneType.
        }
        else if (input == "0")
        {
            Console.Clear();
            GameManager.Instance.SceneInfo = SceneType.Start;
            //스타트씬 스크립트와 연결
        }
    }
}