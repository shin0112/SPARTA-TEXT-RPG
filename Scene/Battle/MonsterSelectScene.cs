using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene.Battle
{
    internal class MonsterSelectScene : BattleSceneBase
    {
        protected override string[] Selections { get; } = ["도망가기"];
        protected override int SelectionCount => Selections.Length + BattleManager.Instance.Monsters.Count;
        private bool _battleEnded = false;

        public MonsterSelectScene()
        {
            BattleManager.Instance.OnAllMonsterDead += EndBattle;
        }

        private void EndBattle() => _battleEnded = true;

        protected override int SelectAct()
        {
            while (true)
            {
                Console.WriteLine("대상을 선택해주세요.");
                (bool flowControl, int value) = GetSelectInput();
                if (value == 0) return value;
                if (!flowControl && !BattleManager.Instance.Monsters[value - 1].IsDead)
                {
                    return value;
                }
                Console.Write("잘못된 대상입니다. 다른 ");
            }
        }

        public override void Show()
        {
            while (!_battleEnded)
            {
                base.Show();
            }

            if (BattleManager.Instance.IsVictory)
            {
                GameManager.Instance.VictoryScene.Show();
                BattleManager.Instance.ResetIsVictory();
            }
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
                    GameManager.Instance.SceneInfo = SceneType.Start;
                    break;
                default:
                    GameManager.Instance.PhaseScene.Show();
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
