using System.Reflection.Metadata.Ecma335;
using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene
{
    internal class ShopSellScene : ShopScene
    {
        string input;
        int i = 0;

        public string shopSellText = @$"
판매할 아이템의 번호를 입력하세요. ex) '2' 입력 시 '수학의 정석'을(를) 판매합니다.

0. 뒤로가기

""쓸만한 걸 가져왔겠지? 아무거나 사주진 않는다고~""
"; // 아이템 리스트 변경 시 예시 체크 필요


        public void SelectSellItem(string input)   // 함수값 저장할 변수 앞에도 Item?을 붙여줘야 한다.
        {
            this.input = input;
            int.TryParse(input, out int i);
            i -= 1;
            int sellQuantity = 1;

            if (i < 0 || i >= InventoryItem.Count)
            {
                Console.WriteLine("잘못된 입력입니다. 번호를 확인해주세요.\n");
                return;
            }

            int itemPrice = InventoryItem[i].Price; //입력값이 리스트 숫자보다 크면 예외로 에러가 나서 확인 코드 아래에서 선언했습니다.

            if (InventoryItem[i].Type == ItemType.HP || InventoryItem[i].Type == ItemType.Stamina) //소비 아이템일 경우 몇 개 팔지 입력
            {
                sellQuantity = 1; //1;은 주석처리한 함수 살리고 이걸로 교체 SellItemQuantity_Consume();
            }

            Console.WriteLine($"정말 판매하시겠습니까? 판매할 수량: {sellQuantity} 총 판매 금액: {(int)Math.Ceiling(InventoryItem[i].Price * 0.8f * sellQuantity)}\n");
            Console.WriteLine("1. 예");
            Console.WriteLine("2. 조금만 더 고민해보자...");
            string inputSellCheck;
            inputSellCheck = Console.ReadLine();

            if (inputSellCheck != "1")
            {
                Console.WriteLine("아이템을 판매하지 않습니다.\n");
                return;
            }
            else
            {
                if (InventoryItem[i].IsEquipped == true)
                {
                    InventoryItem[i].IsEquipped = false;
                }

            }
            //인벤토리에서 아이템 하나 빠지는 코드 필요
            GameManager.Instance.Player.Gold += (int)Math.Ceiling((itemPrice * 0.8f) * sellQuantity);
            Console.WriteLine("\"이건 내가 사가도록 하지. 값은 제대로 쳐 준 거라고!\"\n");
            InventoryItem.RemoveAt(i);
        }


        //public int SellItemQuantity_Consume()
        //{
        //    string inputQuantity;

        //    Console.WriteLine($"몇 개 판매하시겠습니까? 현재 보유 수량: {InventoryItem[i].remaining}");
        //    while (true)
        //    {
        //        Console.Write(">> ");
        //        inputQuantity = Console.ReadLine();
        //        int.TryParse(inputQuantity, out int sellQuantity);

        //        if (InventoryItem[i].remaining < sellQuantity || sellQuantity < 1) //0개 이하 입력이나 보유 개수 이상 입력 시 재입력
        //        {
        //            Console.WriteLine("잘못된 입력입니다. 보유 개수를 확인하세요.");
        //        }
        //        else
        //        {
        //            return sellQuantity;
        //        }
        //    }
        //}


        public void DisplayShopSell()
        {
            ToggleBuyingScene();

            while (true)
            {
                Console.Clear();
                Init();
                Console.WriteLine(shopIntroText1);
                InventoryItemList();
                Console.WriteLine(shopSellText);
                Console.Write(">> ");
                input = "0";
                input = Console.ReadLine();
                int.TryParse(input, out i);
                if (i == 0)
                {
                    break;
                }
                SelectSellItem(input);
                Console.WriteLine("아무 키나 입력하면 계속합니다.");
                Console.ReadKey();
            }
            ToggleBuyingScene();
            GameManager.Instance.SceneInfo = SceneType.Shop;
        }
    }
}
