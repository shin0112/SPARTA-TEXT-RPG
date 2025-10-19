using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene;

public class SpecScene
{
    void WriteColoredStat(string label, string? value, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(label);
        Console.ResetColor();
        Console.WriteLine(value);
    }

    void WriteMenuOption(string number, string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(number);
        Console.ResetColor();
        Console.WriteLine(" " + text);
    }
    
    public void Specification()
    {
        Console.Clear();
        UIHelper.ColorWriteLine("스펙 보기", "DarkGreen");
        UIHelper.ColorWriteLine("캐릭터의 스펙이 표시됩니다.","DarkGreen");
        Console.WriteLine("");

        var player = GameManager.Instance.Player;
        
        Console.WriteLine("==============");

        int equipAtk = InventoryManager.Instance.equipValue(ItemType.Weapon);
        int equipDef = InventoryManager.Instance.equipValue(ItemType.Armor);

        WriteColoredStat("이름:", player?.Name,ConsoleColor.DarkGreen); 
        WriteColoredStat("직업:", player?.Job,ConsoleColor.DarkGreen);
        WriteColoredStat("레벨:", player?.Level.ToString(),ConsoleColor.DarkGreen);
        WriteColoredStat("체력:", player?.Stats.Hp.ToString(),ConsoleColor.Cyan);
        WriteColoredStat("공격력:",$"{(player?.Stats.Atk + equipAtk).ToString()} (+{equipAtk})",ConsoleColor.Cyan);
        WriteColoredStat("방어력:", $"{(player?.Stats.Def + equipDef).ToString()} (+{equipDef})",ConsoleColor.Cyan);
        
        Console.WriteLine("==============");
        Console.WriteLine();
        WriteColoredStat("경험치:", player?.Exp.ToString(),ConsoleColor.DarkCyan);
        WriteColoredStat("획득경험치:", player?.RequiredExp.ToString(),ConsoleColor.DarkCyan);
        WriteColoredStat("골드:", player?.Gold.ToString(),ConsoleColor.Yellow);
        Console.WriteLine();
        Console.WriteLine("==============");
        
        
        
        Console.WriteLine();
        WriteMenuOption("0","나가기",ConsoleColor.DarkCyan);
        
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.Write(">>");

        string input = Console.ReadLine();

        if (input == "0")
        {
            Console.Clear();
            GameManager.Instance.SceneInfo = SceneType.Start;
        }
       
    }
}