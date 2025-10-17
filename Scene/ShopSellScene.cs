using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene
{
    internal class ShopSellScene : ShopScene
    {
        public List<Item> InventoryItem = InventoryManager.Instance.InventoryItem; //ShopItem이 아니라 Inventory로 바꿔야 합니다. 구조만 가져왔어요.

        string input;
        int i = 0;

        public string shopIntroText3 = @$"


판매할 아이템의 번호를 입력하세요. ex) '2' 입력 시 '수학의 정석'을(를) 판매합니다.

0. 뒤로가기



""쓸만한 걸 가져왔겠지? 아무거나 사주진 않는다고~"""; // 아이템 리스트 변경 시 예시 체크 필요


        public Item? SelectSellItem(string input)   // 함수값 저장할 변수 앞에도 Item?을 붙여줘야 한다.
        {
            this.input = input;
            int.TryParse(input, out int i);
            i -= 1;

            string inputSellCheck;

            if (i < 0 || i >= InventoryItem.Count) //인벤토리 리스트로 변경 필요
            {
                Console.WriteLine("잘못된 입력입니다. 번호를 확인해주세요.");
                return null;
            }

            Console.WriteLine("정말 판매하시겠습니까?");
            Console.WriteLine("1. 예");
            Console.WriteLine("2. 조금만 더 고민해보자...");
            inputSellCheck = Console.ReadLine();

            if (inputSellCheck != "1")
            {
                Console.WriteLine("아이템을 판매하지 않습니다.");
                return null;
            }
            else
            {
                //인벤토리에서 아이템 하나 빠지는 코드 필요
                Console.WriteLine("\"이건 내가 사가도록 하지. 값은 제대로 쳐준 거라고!\"");
            }

            return ShopItem[i]; //골드 반환 코드 필요
        }

        public void DisplayShopSell()
        {
            ToggleBuyingScene();

            Console.Clear();
            Console.WriteLine(shopIntroText1);
            ShopItemList();
            Console.WriteLine(shopIntroText3);
            Console.Write(">> ");
            while (true)
            {
                input = "0";
                input = Console.ReadLine();
                int.TryParse(input, out i);
                if (i == 0)
                {
                    break;
                }
                SelectSellItem(input);
            }
            ToggleBuyingScene();
            GameManager.Instance.SceneInfo = SceneType.Shop;
        }
    }
}
