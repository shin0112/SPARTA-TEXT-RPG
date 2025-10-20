using TEXT_RPG.Core;
using TEXT_RPG.Manager;
using TEXT_RPG.UI;

namespace TEXT_RPG.Scene.Inventory
{
    internal class InventoryScene
    {
        public void Inventory()
        {
            var invenManager = InventoryManager.Instance;
            List<Item> item = invenManager.InventoryItem;

            Console.Clear();
            UIHelper.ColorWriteLine("인벤토리", "Yellow");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[장비]\n");

            // 아이템 리스트 나열 반복문
            for (int i = 0; i < item.Count; i++)
            {
                if (item[i].Type == ItemType.Armor || item[i].Type == ItemType.Weapon)
                {
                    string itemString = invenManager.IventoryListShow(item[i]);
                    Console.WriteLine($" - {itemString}");
                }
            }

            Console.WriteLine("\n===============================================================================================================\n");
            Console.WriteLine("[소모품]\n");


            for (int i = 0; i < item.Count; i++)
            {
                if (item[i].Type == ItemType.HP || item[i].Type == ItemType.Stamina)
                {
                    string itemString = invenManager.IventoryListShow(item[i]);
                    Console.WriteLine($" - {itemString}");
                }
            }

            UIHelper.ColorWriteLine("\n1. 장착 관리\n2. 소모품 관리\n0. 나가기\n", "Cyan");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":
                    GameManager.Instance.SceneInfo = SceneType.Equip;
                    break;
                case "2":
                    GameManager.Instance.SceneInfo = SceneType.Consume;
                    break;
                case "0":
                    GameManager.Instance.SceneInfo = SceneType.Start;
                    break;
            }
        }
    }
}
