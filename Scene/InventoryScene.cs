using TEXT_RPG.Core;
using TEXT_RPG.Manager;
using TEXT_RPG.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TEXT_RPG.Scene
{
    internal class InventoryScene
    {
        public void Inventory()
        {
            Console.Clear();
            UIHelper.ColorWriteLine("인벤토리", "Yellow");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]\n");

            List<Item> item = InventoryManager.Instance.InventoryItem;
            // 아이템 리스트 나열 반복문
            for (int i = 0; i < item.Count; i++)
            {
                string itemString = InventoryManager.Instance.IventoryListShow(item[i], i);

                Console.WriteLine($" - {itemString}");
            }

            UIHelper.ColorWriteLine("\n1. 아이템 관리\n0. 나가기\n", "Cyan");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>> ");

            string input = Console.ReadLine() ?? "";

            if (input == "1")
            {
                GameManager.Instance.SceneInfo = SceneType.Equip;
            }
            else if (input == "0")
            {
                GameManager.Instance.SceneInfo = SceneType.Start;
            }
        }
    }
}
