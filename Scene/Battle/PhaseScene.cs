using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene.Battle
{
    internal class PhaseScene : BattleSceneBase
    {
        protected override string[] Selections { get; } = ["다음"];

        public override void Enter()
        {
            Player player = GameManager.Instance.Player!;

            // 플레이어 턴
            ShowTitle();
            BattleManager.Instance.PlayerTurn();
            ProcessSelection();

            // 몬스터 턴 
            foreach (var monster in BattleManager.Instance.Monsters)
            {
                if (player.IsDead) return; // 플레이어가 죽었을 경우 return
                if (monster.IsDead) continue; // 죽은 몬스터인 경우 스킵
                ShowTitle();
                BattleManager.Instance.MonsterTurn(monster);
                ProcessSelection();
            }

            // 한 턴 종료
            BattleManager.Instance.TurnEnd();
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
