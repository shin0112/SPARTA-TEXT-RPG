using TEXT_RPG.Core;
using TEXT_RPG.Manager;
using TEXT_RPG.Repository;

namespace TEXT_RPG.Scene
{
    internal class ShopScene
    {
        public List<Item> ShopItem = InventoryManager.Instance.ShopItem;
        public List<Item> InventoryItem = InventoryManager.Instance.InventoryItem;

        public bool isBuyingScene = false;

        int _itemNumber = 1;

        public string shopIntroText1;

        public string shopIntroText2 = @$"

1. 아이템 구매
2. 아이템 판매
0. 나가기

""멀뚱멀뚱 서서 뭐 하고 있어? 언넝 골라~""";

        public void Init()
        {
            shopIntroText1 = @$"       
[상점]
인자한 모습의 할아버지가 미소 지으며 반겨준다. 
""사는 게 쉽지 않지? 와서 박카스나 한 잔 마시고 해.  ...뭐해 돈 안 내고? 세상에 공짜가 어딨나?""

[보유 골드]
{GameManager.Instance.Player.Gold} G

[아이템 목록]";
        }


        public bool ToggleBuyingScene()
        {
            isBuyingScene = !isBuyingScene;
            _itemNumber = 1;
            return isBuyingScene;
        }


        public void ShopItemList()
        {
            string ability = "오류";
            string isPercent = "";
            _itemNumber = 1;

            foreach (var item in ShopItem)
            {
                string remaining = item.IsBuy ? "[Sold Out]" : "[남은 수량: 1]"; //foreach 밖에 놓는 방법 찾기

                switch (item.Type)
                {
                    case ItemType.Weapon:
                        ability = "공격력";
                        isPercent = "";
                        break;

                    case ItemType.Armor:
                        ability = "방어력";
                        isPercent = "";
                        break;
                    case ItemType.HP:
                        ability = "체력 회복";
                        isPercent = "%";
                        remaining = "";
                        break;
                    case ItemType.Stamina:
                        ability = "스태미너 회복";
                        isPercent = "";
                        remaining = "";
                        break;
                    default:
                        Console.WriteLine("오류 발생 확인 필요");
                        break;
                }

                switch (item.Name)
                {
                    case "열공 머리띠":
                    case "천하장사 소시지":
                    case "빠워에이드":
                        Console.WriteLine();
                        break;
                }

                Console.WriteLine($"- {DisplayItemNumber()}{remaining} {item.Name} | {ability} + {item.Value}{isPercent} | {item.Price} G | {item.Description}");
            }
        }


        public string DisplayItemNumber()
        {
            if (isBuyingScene == true)
            {
                this._itemNumber++;
                return $"{_itemNumber - 1}번 | ";
            }
            else
            {
                return "";
            }
        }

        public void ShopSceneSelect() // 이동 방식 결정에 따라 코드 수정
        {
            int inputInt = -1;
            string inputStr;

            while (inputInt != 1 || inputInt != 2 || inputInt != 0)
            {
                inputStr = Console.ReadLine();
                int.TryParse(inputStr, out inputInt);
                if (inputInt == 1 || inputInt == 2 || inputInt == 0)
                {
                    break;
                }
                Console.WriteLine("잘못된 입력입니다. 숫자를 확인해주세요.\n>> ");
            }

            if (inputInt == 1)
            {
                //아이템 구매로 이동
                GameManager.Instance.SceneInfo = SceneType.ShopBuy;
            }
            else if (inputInt == 2)
            {
                //아이템 판매로 이동
                GameManager.Instance.SceneInfo = SceneType.ShopSell;
            }
            else if (inputInt == 0)
            {
                //메인 화면으로 이동
                GameManager.Instance.SceneInfo = SceneType.Start;
            }

        }
        // 오늘의 추천 메뉴 추후 추가
        //public void RandomRecommend()  
        //{
        //    Random random = new();

        //    string randomFood = "";

        //    Console.WriteLine("오늘은 이걸 먹어보는 게 어떻겠나?");
        //    Console.WriteLine($">> {randomFood} <<");
        //}

        public void DisplayShop()
        {
            Console.Clear();
            Init();
            Console.WriteLine(shopIntroText1);
            ShopItemList();
            Console.WriteLine(shopIntroText2);
            Console.Write(">> ");
            ShopSceneSelect();
        }
    }
}
