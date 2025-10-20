using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene
{
    internal class TrainingScene : SceneBase
    {
        protected override string Title => "스펙 쌓기";
        protected override string[] Selections => ["나가기", "C# 문법 강의 듣기", "AI와 모의 면접하기"];
        private int[] _trainExp = [0, 4, 7];
        private int[] _requiredSp = [0, 5, 10];

        public override void Enter()
        {
            ShowTitle();
            Console.WriteLine($"스펙을 쌓기 위한 훈련! (현재 스테미나: {GameManager.Instance.Player!.Stats.Sp})\n");
            ProcessSelection();
        }

        protected override void ShowSelections()
        {
            for (int i = 1; i < Selections.Length; i++)
            {
                Console.WriteLine($"{i}. {Selections[i]} | 필요 스테미나: {_requiredSp[i]}");
            }
            Console.WriteLine();
            Console.WriteLine($"0. {Selections[0]}");
        }

        protected override void HandleInput(int select)
        {
            switch (select)
            {
                case 0:
                    GameManager.Instance.SceneInfo = SceneType.Start;
                    ResetWarnOutput();
                    break;
                default:
                    Train(select);
                    break;
            }
        }

        private void Train(int select)
        {
            Player player = GameManager.Instance.Player!;
            if (player.Stats.Sp - _requiredSp[select] < 0)
            {
                WarnOutput = "스테미너가 부족합니다.";
                return;
            }
            player.Stats.SpendSp(_requiredSp[select]);
            player.GetExp(_trainExp[select]);
        }
    }
}
