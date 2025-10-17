using System;
using TEXT_RPG.Core;
using TEXT_RPG.Repository;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene
{


    internal class ShopBuyScene : ShopScene
    {
        private readonly ItemRepository itemRepository = new();

        public List<Item> ShopItem = [];
        public int ShopItemNumber { get; set; } = 0;

        public bool hasEnoughGold = false;

        string input;

        int i = 0;

        public string shopIntroText3 = @$"


구매할 아이템의 번호를 입력하세요. ex) ""2""입력 시 ""기계식 키보드""를 구매합니다.

0. 뒤로가기



멀뚱멀뚱 서서 뭐 하고 있어? 언넝 골라~"; // 아이템 리스트 변경 시 예시 체크 필요



        public Item? SelectBuyItem(string input)   // 함수값 저장할 변수 앞에도 Item?을 붙여줘야 한다.
        {
            this.input = input;
            int.TryParse(input, out int i);
            i -= 1;

            string inputBuyCheck;

            if(i < 0 || i >= ShopItem.Count)
            {
                Console.WriteLine("잘못된 입력입니다. 번호를 확인해주세요.");
                return null;
            }

            if (ShopItem[i].IsBuy == true)
            {
                Console.WriteLine("그 장비는 이미 판매되었다네!"); // 추후 구매화면에서 즉시 구매가 안 되게 처리하면 else문 삭제 예정
                return null;
            }

                if (ShopItem[i].Price > GameManager.Instance.Player.Gold)
            {
                Console.WriteLine("자네... 돈은 있지?");
            }

            Console.WriteLine("정말 구매하시겠습니까?");
            Console.WriteLine("1. 예.");
            Console.WriteLine("2. 조금만 더 고민해보자...");
            inputBuyCheck = Console.ReadLine();

            if (input != "1")
            {
                Console.WriteLine("아이템을 구매하지 않습니다.");
            }

            if (ShopItem[i].IsBuy == false)
            {
                ShopItem[i].IsBuy = true;
                Console.WriteLine("좋은 선택일세. 사회에서 마음껏 뛰놀게.");
            }

            return ShopItem[i]; // <- 객체 그대로 반환
        }

        string input;
        int i = 0;

        public void DisplayShopBuy()
        {
            Console.Clear();
            Console.WriteLine(shopIntroText1);
            ShopItemList();
            Console.WriteLine(shopIntroText2);
            Console.Write(">><< ");
            input = Console.ReadLine();
            int.TryParse(input, out i);
            SelectBuyItem(input);
        }




    }
}
