using TEXT_RPG.UI;

namespace TEXT_RPG.Scene
{
    internal abstract class SceneBase
    {
        protected virtual string Title { get; } = "";
        protected virtual string[] Selections { get; } = [];
        protected virtual int SelectionCount => Selections.Length;
        protected string? WarnOutput = null;
        public void ResetWarnOutput() => WarnOutput = null;

        public abstract void Enter();
        protected abstract void HandleInput(int select);

        protected virtual void ShowSelections()
        {
            for (int i = 1; i < Selections.Length; i++)
            {
                Console.WriteLine($"{i}. {Selections[i]}");
            }
            Console.WriteLine();
            Console.WriteLine($"0. {Selections[0]}");
        }

        protected void ShowTitle()
        {
            Console.Clear();
            SceneCommonUI.ShowTitle(Title);
        }

        protected virtual void ProcessSelection()
        {
            ShowSelections();
            Console.WriteLine();
            int select = GetSelection();
            HandleInput(select);
        }

        protected virtual int GetSelection()
        {
            while (true)
            {
                if (WarnOutput != null) Console.WriteLine(WarnOutput);
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                (bool flowControl, int value) = ValidateSelectionInput();
                if (!flowControl)
                {
                    return value;
                }
            }
        }

        protected (bool flowControl, int value) ValidateSelectionInput()
        {
            Console.Write(">> ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int select);

            // Todo: 선택지에서 벗어난 숫자 입력 시에도 예외 처리하기

            if (!isNumber || select < 0 || SelectionCount <= select)
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
            else
            {
                return (flowControl: false, value: select);
            }

            return (flowControl: true, value: default);
        }
    }
}
