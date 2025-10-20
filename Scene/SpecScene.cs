using System.Text;
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
        
        UIHelper.ColorWriteLine($"{GameManager.Instance.Player?.Name}의 스펙이 표시됩니다.", "DarkGreen");
        Console.OutputEncoding = Encoding.UTF8;
        string asciiArt = @"
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⢷⣷⣣⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⢏⣿⣿⡵⡀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⣠⣮⣷⣿⣿⣿⣿⣷⣄⣄⠀⠀⠀⠀⠈⢞⣿⣿⡵⡀⠀⠀⠀⠀⠀가라아앗=!
 ⠀⠀⡠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣏⢦⣤⡀⠀⠀⠀⠫⣻⣿⣾⢄⠀⠀⠀   돌격이다!!!
 ⠀⣔⣿⣿⣿⣿⣿⣿⠿⣿⠻⢟⣿⣿⣿⣿⣿⡆⠀⠀⠀⠑⡿⣿⣯⢆⠀⠀
 ⢰⣸⢿⣻⢟⠃⠉⠉⠀⡠⠤⠸⣸⣿⣿⣿⡳⠁⠀⠀⠀⠀⡨⠺⠿⠇⢓⡄
 ⠧⠊⠁⠘⣖⣳⠠⣶⣋⡹⠁⠀⠛⣩⢻⠋⠀⠀⠀⠀⠀⢀⠇⠀⠀⠀⠀⢾⠀
⠀⠀⢠⠂⠁⠓⠒⠊⠀⡠⠤⡀⢠⠀⠚⠀⠀⠀⠀⠀⡠⠊⢀⠤⡤⣔⠩⠼⡀
⠀⠀⢇⠀⠀⢀⡠⢔⣪⠠⠖⠇⡘⠀⠀⠀⢀⠄⠒⠉⢀⠔⠁⠀⣧⢞⠮⠭⠵⡀
⠀⠀⠘⠒⠉⣾⣀⣀⠀⣀⣀⠦⠗⠹⠙⠃⠁⠀⡠⠔⡡⠔⠒⠉⡨⢴⢹⣿⣏⡆
⠀⠀⠀⠀⡸⠉⠀⠀⠁⠀⠀⠀⠀⣇⡠⡄⡶⠯⠔⠈⠀⠀⡠⠊⠀⠀⡿⣿⣿⡇
⠀⠀⠀⢀⠇⠀⠀⠀⠀⢀⣀⠤⡤⠵⠊⢸⠀⡠⠤⠤⠐⠉⠀⠀⠀⠀⣷⣿⢿⡇
⠀⠀⢀⠃⠀⢀⣀⣀⣀⣠⣀⣀⣿⠉⠉⠉⠉
";

        Console.WriteLine(asciiArt);
        
        var player = GameManager.Instance.Player;

        int equipAtk = InventoryManager.Instance.EquipValue(ItemType.Weapon);
        int equipDef = InventoryManager.Instance.EquipValue(ItemType.Armor);

        Console.WriteLine("=========================================================================");

        WriteColoredStat("이름:", GameManager.Instance.Player?.Name, ConsoleColor.DarkGreen);
        WriteColoredStat("직업:", GameManager.Instance.Player?.Job, ConsoleColor.DarkGreen);
        WriteColoredStat("레벨:", GameManager.Instance.Player?.Level.ToString(), ConsoleColor.DarkGreen);
        Console.WriteLine();

        WriteColoredStat("체력:", GameManager.Instance.Player?.Stats.Hp.ToString(), ConsoleColor.Cyan);
        WriteColoredStat("공격력:", $"{(player?.Stats.Atk + equipAtk).ToString()} (+{equipAtk})", ConsoleColor.Cyan);
        WriteColoredStat("방어력:", $"{(player?.Stats.Def + equipDef).ToString()} (+{equipDef})", ConsoleColor.Cyan);
        Console.WriteLine();

        WriteColoredStat("경험치:", GameManager.Instance.Player?.Exp.ToString(), ConsoleColor.DarkCyan);
        WriteColoredStat("획득경험치:", GameManager.Instance.Player?.RequiredExp.ToString(), ConsoleColor.DarkCyan);
        WriteColoredStat("골드:", GameManager.Instance.Player?.Gold.ToString(), ConsoleColor.Yellow);

        Console.WriteLine("=========================================================================");




        Console.WriteLine();
        WriteMenuOption("0", "나가기", ConsoleColor.DarkCyan);

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