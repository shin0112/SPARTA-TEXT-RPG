namespace TEXT_RPG.Scenes.Battle
{
    internal abstract class BattleSceneBase : SceneBase
    {
        protected abstract void ShowMonsterInfo();

        public override void Show()
        {

            ShowMonsterInfo();
            ShowPlayerInfo();

            ShowSelections();

            int select = SelectAct();

            HandleInput(select);
        }

        protected virtual void ShowPlayerInfo()
        {
            // Todo: player 정보 가져오기 (임시 데이터)
            int level = 1;
            string name = "이름";
            string job = "직업";
            int currentHp = 100;
            int maxHp = 100;

            Console.WriteLine("[내 정보]");
            Console.WriteLine($"Lv. {level} {name} ({job})");
            Console.WriteLine($"체력 {currentHp}/{maxHp}\n");
        }

        public int SelectAct()
        {
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                bool isNumber = int.TryParse(Console.ReadLine(), out int select);

                // Todo: 선택지에서 벗어난 숫자 입력 시에도 예외 처리하기

                if (!isNumber)
                {
                    Console.WriteLine("숫자를 입력해주세요.");
                }
                else
                {
                    return select;
                }
            }
        }
    }
}