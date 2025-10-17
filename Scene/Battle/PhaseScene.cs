using TEXT_RPG.Core;
using TEXT_RPG.Manager;
using TEXT_RPG.UI;

namespace TEXT_RPG.Scene.Battle
{
    internal class PhaseScene : BattleSceneBase
    {
        // Todo: Monster 정보 저장하기 (임시 데이터)
        private List<Monster> monsters = BattleManager.Instance.Monsters;
        protected override string[] Selections { get; } = ["다음"];

        public override void Show()
        {
            Player player = GameManager.Instance.Player!;

            // 플레이어 턴
            PlayerTurn(player);

            // 몬스터 턴 
            foreach (var monster in monsters)
            {
                if (monster.IsDead) continue; // 죽은 몬스터인 경우 스킵
                if (player.IsDead) // 플레이어 죽는 경우 패배 처리
                {
                    BattleManager.Instance.Defeat();
                    return;
                }
                MonsterTurn(monster, player);
            }

            // 한 턴 종료
            BattleManager.Instance.TurnEnd();
        }

        private void PlayerTurn(Player player)
        {
            ShowTitle();
            Monster monster = monsters[BattleManager.Instance.MonsterNumber - 1];

            Console.WriteLine($"{player.Name}의 공격!");
            Console.WriteLine($"Lv. {monster.Level} {monster.Name} 을(를) 맞췄습니다.\n");

            ShowMonsterInfo();
            HandleSelections();
        }

        private void MonsterTurn(Monster monster, Player player)
        {
            ShowTitle();
            Console.WriteLine($"Lv. {monster.Level} {monster.Name}의 공격!");

            int actualDamage = monster.Stats.Atk - player.Stats.Def;
            if (actualDamage < 0) actualDamage = 0;

            Console.WriteLine($"{player.Name} 을(를) 맞췄습니다. [데미지:{actualDamage}]");

            monster.Attack(player);

            Console.WriteLine();
            BattleSceneUI.ShowPlayerInfo();
            HandleSelections();
        }

        protected override void HandleInput(int select)
        {
            if (BattleManager.Instance.IsVictory || BattleManager.Instance.IsDefeat)
            {
                GameManager.Instance.SceneInfo = SceneType.Result;
            }
        }
    }
}
