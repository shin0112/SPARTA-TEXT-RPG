using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scenes.Battle
{
    internal class MonsterSelectScene : BattleSceneBase
    {
        private bool _battleEnded = false;

        public MonsterSelectScene()
        {
            BattleManager.Instance.OnAllMonsterDead += EndBattle;
        }

        private void EndBattle() => _battleEnded = true;

        public override void Show()
        {
            while (!_battleEnded)
            {
                Console.WriteLine("Battle!!\n");
                base.Show();
            }
        }

        protected override void ShowSelections()
        {
            Console.WriteLine("0. 도망가기");
        }

        protected override void HandleInput(int select)
        {
            // 선택한 몬스터 정보 저장하기
            BattleManager battleManager = BattleManager.Instance;
            battleManager.MonsterNumber = select;

            switch (select)
            {
                case 0:
                    EndBattle();
                    break;
                default:
                    new PhaseScene().Show();
                    break;
            }
        }

        protected override void ShowMonsterInfo()
        {
            List<Monster> monsters = BattleManager.Instance.Monsters;

            for (int i = 0; i < monsters.Count; i++)
            {
                var monster = monsters[i];
                Console.WriteLine($"{i + 1}. Lv. {monster.Level} {monster.Name} | {(monster.IsDead ? "DEAD" : "HP " + monster.Stats.Hp)}");
            }
            Console.WriteLine();
        }
    }
}
