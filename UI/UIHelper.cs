namespace TEXT_RPG.UI
{
    internal class UIHelper
    {
        //텍스트 패딩 메서드
        public static string GetPaddedString(string text, int totalWidth)
        {
            int displaywidth = GetDisplayWidth(text);
            int padding = Math.Max(0, totalWidth - displaywidth);
            return text + new string(' ', padding);
        }

        //텍스트 넓이 구하는 메서드
        private static int GetDisplayWidth(string text)
        {
            int width = 0;
            foreach (char c in text)
            {
                width += c >= 0xAC00 && c <= 0xD7A3 ? 2 : 1; // 한글 탐지
            }
            return width;
        }

        // 색상 텍스트 메서드
        public static void ColorWriteLine(string text, string colorName)
        {
            if (Enum.TryParse(colorName, true, out ConsoleColor color))
            {
                var prev = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.WriteLine(text);
                Console.ForegroundColor = prev;
            }
        }

        // 색상 텍스트 메서드 (줄바꿈 X)
        public static void ColorWrite(string text, string colorName)
        {
            if (Enum.TryParse(colorName, true, out ConsoleColor color))
            {
                var prev = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.WriteLine(text);
                Console.ForegroundColor = prev;
            }
        }
    }
}
