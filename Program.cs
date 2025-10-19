using TEXT_RPG.Manager;

namespace TEXT_RPG
{
    internal class Program
    {
        // Main: 프로그램에 단 1개만 있어야하는 함수
        // 수정하면 큰일날 수도 있습니다ㅜㅜ
        static void Main()
        {
            GameManager.Instance.Run();
        }
    }
}
