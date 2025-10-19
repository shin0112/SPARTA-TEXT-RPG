using TEXT_RPG.Core;
using TEXT_RPG.Manager;

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
            ShowTitle();
            BattleManager.Instance.PlayerTurn();
            HandleSelections();

            // 몬스터 턴 
            foreach (var monster in monsters)
            {
                if (monster.IsDead) continue; // 죽은 몬스터인 경우 스킵
                ShowTitle();
                BattleManager.Instance.MonsterTurn(monster);
                HandleSelections();
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
