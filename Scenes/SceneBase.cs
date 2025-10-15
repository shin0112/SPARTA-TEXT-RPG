namespace TEXT_RPG.Scenes
{
    internal abstract class SceneBase
    {
        public abstract void Show();
        protected abstract void ShowSelections();
        protected abstract void HandleInput(int select);

        protected virtual void HandleSelections()
        {
            ShowSelections();
            Console.WriteLine();
            int select = SelectAct();
            HandleInput(select);
        }

        protected virtual int SelectAct()
        {
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                (bool flowControl, int value) = GetSelectInput();
                if (!flowControl)
                {
                    return value;
                }
            }
        }

        protected (bool flowControl, int value) GetSelectInput()
        {
            Console.Write(">> ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int select);

            // Todo: 선택지에서 벗어난 숫자 입력 시에도 예외 처리하기

            if (!isNumber)
            {
                Console.WriteLine("숫자를 입력해주세요.");
            }
            else
            {
                return (flowControl: false, value: select);
            }

            return (flowControl: true, value: default);
        }
    }
}
