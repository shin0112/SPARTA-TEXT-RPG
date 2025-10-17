using ConsoleRPG;
using TEXT_RPG.Core;
using TEXT_RPG.Scene;
using TEXT_RPG.Scene.Battle;

namespace TEXT_RPG.Manager
{
    internal class GameManager
    {
        public Intro StartIntro = new();
        private static GameManager _instance = new();
        public static GameManager Instance => _instance;
        public Player? Player { get; set; } = new("아무개", "백수");
        public SceneType SceneInfo { get; set; } = SceneType.Start;

        // 모든 씬 생성하기
        // 씬이 추가될 때마다 여기에 추가해주세요.
        public StartScene StartScene { get; } = new();
        public SpecScene SpecScene { get; } = new();
        public ShopScene ShopScene { get; } = new();
        public ShopBuyScene ShopBuyScene { get; } = new();
        public ShopSellScene ShopSellScene { get; } = new();
        public MonsterSelectScene MonsterSelectScene { get; } = new();
        public InventoryScene InventoryScene { get; } = new();
        public EquipManagementScene EquipManagementScene { get; } = new();
        public BattleStartScene BattleStartScene { get; } = new();
        public MonsterSelectScene MonsterSelect { get; } = new();
        public PhaseScene PhaseScene { get; } = new();
        public ResultScene ResultScene { get; } = new();
        public DungeonSelectScene DungeonSelect { get; } = new();


        // 게임 시작하는 함수
        // 실행 로직을 변경하고 싶다면 이 함수를 수정해주세요.
        public void Run()
        {
            BattleManager.Instance.InitScenes(this);
            ShopScene.Init();
            //new Intro().StartIntro();
            while (true)
            {
                // 2. 1에서 저장된 정보가 아직 유지되고 있습니다!
                switch (SceneInfo)
                {
                    case SceneType.Start: // 시작
                        StartScene.GameStart();
                        break;
                    case SceneType.Battle: // 전투
                        BattleManager.Instance.Battle();
                        break;
                    case SceneType.Spec: // 스펙
                        SpecScene.Specification();
                        break;
                    case SceneType.Inven: // 인벤토리
                        InventoryScene.Inventory();
                        break;
                    case SceneType.Equip: // 장비 장착
                        EquipManagementScene.EquipManagement();
                        break;
                    case SceneType.Shop: // 상점
                        ShopScene.DisplayShop();
                        break;
                    case SceneType.ShopBuy: // 상점 아이템 구매
                        ShopBuyScene.DisplayShopBuy();
                        break;
                    case SceneType.ShopSell: // 상점 아이템 판매
                        ShopSellScene.DisplayShopSell();
                        break;
                    case SceneType.MonsterSelect:
                        MonsterSelect.Show();
                        break;
                    case SceneType.DungeonSelect:
                        DungeonSelect.Show();
                        break;
                }
                // 1. 각 Scene 안에서 변경된 SceneInfo 정보가 Gamemanager에 저장되어 있는 상태입니다.
            }
        }
    }

}
