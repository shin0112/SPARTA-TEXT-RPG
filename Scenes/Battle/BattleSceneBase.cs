namespace TEXT_RPG.Scenes.Battle
{
    internal abstract class BattleSceneBase : SceneBase
    {
        protected override string Title { get; } = "Battle!!";
        protected abstract void ShowMonsterInfo();

        public override void Show()
        {
            ShowTitle();
            ShowMonsterInfo();
            ShowPlayerInfo();
            HandleSelections();
        }

        protected virtual void ShowPlayerInfo()
        {
            // Todo: player 정보 가져오기 (임시 데이터)
            int level = 1;
            string name = "이름";
            string job = "직업";
            int currentHp = 100;
            int maxHp = 100;

            Console.WriteLine("[내 정보]");
            Console.WriteLine($"Lv. {level} {name} ({job})");
            Console.WriteLine($"체력 {currentHp}/{maxHp}\n");
        }
    }
}