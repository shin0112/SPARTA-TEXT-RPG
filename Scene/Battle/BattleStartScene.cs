using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene.Battle
{
    internal class BattleStartScene : BattleSceneBase
    {
        protected override string[] Selections { get; } = ["나가기", "싸우기"];

        protected override void HandleInput(int select)
        {
            switch (select)
            {
                case 1:
                    GameManager.Instance.SceneInfo = SceneType.MonsterSelect; // 몬스터 선택 화면
                    break;
                default:
                    GameManager.Instance.SceneInfo = SceneType.DungeonSelect; // 던전 선택 화면
                    break;
            }
        }

        protected override void ShowMonsterInfo()
        {
            List<Monster> monsters = BattleManager.Instance.Monsters;

            for (int i = 0; i < monsters.Count; i++)
            {
                var monster = monsters[i];
                Console.WriteLine($"Lv. {monster.Level} {monster.Name} | {(monster.IsDead ? "DEAD" : "HP " + monster.Stats.Hp)}");
            }
            Console.WriteLine();
        }
    }
}
