using ConsoleRPG;
using TEXT_RPG.Core;
using TEXT_RPG.Scene;

namespace TEXT_RPG.Manager
{
    internal class GameManager
    {
        public Intro StartIntro = new();
        private static GameManager _instance = new();
        public static GameManager Instance => _instance;
        public Player? Player { get; set; }

        // 게임 시작하는 함수
        // 실행 로직을 변경하고 싶다면 이 함수를 수정해주세요.
        public void Run()
        {
            new Intro().StartIntro();
            new StartScene().GameStart();
        }
    }
}
