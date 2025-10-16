
using TEXT_RPG.Core;
using TEXT_RPG.Repository;

namespace TEXT_RPG.Scene
{
    internal class ShopBuyScene : ShopScene
    {
        private readonly ItemRepository itemRepository = new();

        public List<Item> ShopItem = [];
        public int ShopItemNumber { get; set; } = 0;


        public Item SelectBuyItem(string input)
        {
            if (ShopItem[i].IsBuy == false)
            {
                ShopItem[i].IsBuy = true;
                Console.WriteLine("좋은 선택일세. 사회에서 마음껏 뛰놀게.");
            }
            else
            {
                Console.WriteLine("그 장비는 이미 판매되었다네!"); // 추후 구매화면에서 즉시 구매가 안 되게 처리하면 else문 삭제 예정
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
