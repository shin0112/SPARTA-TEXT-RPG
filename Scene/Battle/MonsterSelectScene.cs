using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene.Battle
{
    internal class MonsterSelectScene : BattleSceneBase
    {
        protected override string[] Selections { get; } = ["도망가기"];
        protected override int SelectionCount => Selections.Length + BattleManager.Instance.Monsters.Count;

        protected override int SelectAct()
        {
            while (true)
            {
                Console.WriteLine("대상을 선택해주세요.");
                (bool flowControl, int value) = GetSelectInput();

                if (flowControl) continue; // 잘못된 입력

                if (value == 0) return value; // 도망가기

                var monsters = BattleManager.Instance.Monsters;
                if (!monsters[value - 1].IsDead)
                    return value;
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
                    GameManager.Instance.SceneInfo = SceneType.DungeonSelect;
                    break;
                default:
                    GameManager.Instance.SceneInfo = SceneType.Phase;
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
