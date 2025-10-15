using TEXT_RPG.Manager;

namespace TEXT_RPG.Scenes.Battle
{
    internal class PhaseScene : BattleSceneBase
    {
        // Todo: Monster 정보 저장하기 (임시 데이터)
        private object monster = BattleManager.Instance.Monsters[BattleManager.Instance.MonsterNumber - 1];

        public override void Show()
        {
            Console.WriteLine("Battle!\n");

            // Todo: player 정보 넣기
            Console.WriteLine($"{"플레이어"}의 공격!");
            Console.WriteLine($"Lv. {3} {"공허충"} 을(를) 맞췄습니다.\n");


        }

        protected override void ShowSelections()
        {
            Console.WriteLine("0. 다음");
        }

        protected override void HandleInput(int select)
        {

        }

        protected override void ShowMonsterInfo()
        {
            Console.WriteLine($"Lv. {3} {"공허충"}");

            // Todo: monster의 isDead로 변경
            // Todo: 실제 monster 체력으로 변경
            bool isDead = true;
            if (isDead)
            {
                Console.WriteLine($"HP {10} → Dead");
            }
            else
            {
                Console.WriteLine($"HP {10} → {"나중 체력"}");
            }
        }
    }
}
