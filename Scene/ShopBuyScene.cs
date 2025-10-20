using System;
using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene
{
    internal class ShopBuyScene : ShopScene
    {
        string input;
        int i = 0;

        public string shopBuyText = $@"
구매할 아이템의 번호를 입력하세요. ex) '2' 입력 시 '기계식 키보드'을(를) 구매합니다.

0. 뒤로가기

""멀뚱멀뚱 서서 뭐 하고 있어? 언넝 골라~"""; // 아이템 리스트 변경 시 예시 체크 필요
        
        
        
        


        public void SelectBuyItem(string input)   // 함수값 저장할 변수 앞에도 Item?을 붙여줘야 한다.
        {

            this.input = input;
            bool isParsed = int.TryParse(input, out int i);
            i -= 1;

            if (i < 0 || i >= ShopItem.Count || isParsed == false)
            {
                Console.WriteLine("잘못된 입력입니다. 번호를 확인해주세요.");
                return;
            }

            Item newItem = ShopItem[i]; //입력값이 리스트 숫자보다 크면 예외로 에러가 나서 확인 코드 아래에서 선언했습니다.

            if (ShopItem[i].IsBuy == true)
            {
                Console.WriteLine("\"그 장비는 이미 판매되었다네!\"\n");
                return;
            }

            if (ShopItem[i].Price > GameManager.Instance.Player.Gold)
            {
                Console.WriteLine("\"자네... 돈은 있지? 아니, 이걸로 되겠어? 참.\"");
                Console.WriteLine("돈을 더 벌어오자.\n");
                return;
            }

            Console.WriteLine("정말 구매하시겠습니까?\n");
            Console.WriteLine("1. 예");
            Console.WriteLine("2. 조금만 더 고민해보자...\n");
            string inputBuyCheck;
            inputBuyCheck = Console.ReadLine();
            isParsed = int.TryParse(inputBuyCheck, out int inputBuyCheckTryParse);

            if (isParsed == false)
            {
                Console.WriteLine("숫자를 입력하십시오.\n");
                return;
            }
            else if (inputBuyCheckTryParse != 1 )
            {
                Console.WriteLine("아이템을 구매하지 않습니다.\n");
                return;
            }


            if (ShopItem[i].IsBuy == false)
            {
                string inputQuantity = "";

                if (ShopItem[i].Type is 0 or (ItemType)1)
                {
                    ShopItem[i].IsBuy = true;
                    GameManager.Instance.Player.Gold -= ShopItem[i].Price;

                    Console.WriteLine("\"좋은 선택일세. 사회에 나가 꿈을 펼쳐보게나.\"\n");
                    InventoryItem.Add(newItem.Clone());
                }
                else
                {
                    Console.WriteLine("몇 개 사시겠습니까?");
                    Console.Write(">> ");
                    inputQuantity = Console.ReadLine();
                    isParsed = int.TryParse(inputQuantity, out int buyQuantity);
                    if (isParsed == false)
                    {
                        Console.WriteLine("숫자를 입력하십시오.");
                        return;
                    }
                    else if (buyQuantity < 1 )
                    {
                        Console.WriteLine("1개 이상 구매하십시오.");
                        return;
                    }

                    if (GameManager.Instance.Player.Gold < ShopItem[i].Price * buyQuantity)
                    {
                        Console.WriteLine("\"자네... 돈은 있지? 아니, 이걸로 되겠어? 참.\"");
                        Console.WriteLine("돈을 더 벌어오자.\n");
                        return;
                    }

                    GameManager.Instance.Player.Gold -= ShopItem[i].Price * buyQuantity;

                    if (buyQuantity > 4)
                    {
                        Console.WriteLine("\"자네, 그거 정말 다 먹을 수 있나..?\"");
                    }
                    Console.WriteLine("\"맛있게 먹게나.\"\n");

                    for (int quantity = 1; quantity <= buyQuantity; quantity++)
                    {
                        InventoryItem.Add(newItem.Clone());
                    }
                }
            }
        }


        public void DisplayShopBuy()
        {
            ToggleBuyingScene();

            while (true)
            {
                Console.Clear();
                Init();
                Console.WriteLine(shopIntroText1);
                ShopItemList();
                Console.WriteLine(shopBuyText);
                Console.Write(">> ");
                input = "0";
                input = Console.ReadLine();
                int.TryParse(input, out i);
                if (int.TryParse(input, out i) == false)
                {
                    Console.WriteLine ("잘못된 입력입니다. 숫자를 입력해주세요.");
                }
                else if (i == 0)
                {
                    break;
                }
                else
                {
                    SelectBuyItem(input);
                }
                    Console.WriteLine("아무 키나 입력하면 계속합니다.");
                    Console.ReadKey();
            }
            ToggleBuyingScene();
            GameManager.Instance.SceneInfo = SceneType.Shop;
        }
    }
}
