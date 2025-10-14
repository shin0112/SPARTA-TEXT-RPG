using TEXT_RPG.Manager;

namespace TEXT_RPG.Scenes.Battle
{
    internal abstract class BattleSceneBase : SceneBase
    {
        protected abstract void ShowMonsterInfo(List<object> monsters);


        public override void Show()
        {
            // player 정보 가져오기 (임시 데이터)
            int level = 1;
            string name = "이름";
            string job = "직업";
            int currentHp = 100;
            int maxHp = 100;

            Console.WriteLine("Battle!!\n");

            // todo: 몬스터 리스트
            BattleManager battleManager = BattleManager.Instance;
            battleManager.SpawnRandomMonsters();
            ShowMonsterInfo(battleManager.Monsters);

            Console.WriteLine("[내 정보]");
            Console.WriteLine($"Lv. {level} {name} ({job})");
            Console.WriteLine($"체력 {currentHp}/{maxHp}\n");

            Console.WriteLine("1. 공격");
            Console.WriteLine();

            int select = SelectAct();

            switch (select)
            {
                case 1:
                    // player 공격화면으로 넘어가기
                    break;
                default:
                    break;
            }
        }


        public int SelectAct()
        {
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                bool isNumber = int.TryParse(Console.ReadLine(), out int select);

                try
                {
                    if (!isNumber)
                    {
                        throw new Exception("숫자를 입력해주세요.");
                    }
                    else
                    {
                        return select;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
