using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene.Inventory
{
    internal class ConsumeManagementScene
    {
        public void ConsumeManagement()
        {
            Console.Clear();
            UIHelper.ColorWriteLine("인벤토리 - 소모품 관리", "Yellow");
            Console.WriteLine("소모품을 사용하세요.\n");
            Console.WriteLine("[아이템 목록]\n");

            var invenManager = InventoryManager.Instance;
            List<Item> item = invenManager.ConsumeItem;

            // 각 장비 나열
            for (int i = 0; i < item.Count; i++)
            {
                string itemString = invenManager.IventoryListShow(item[i], i);

                UIHelper.ColorWriteLine($"{i + 1}. {itemString}", "Cyan");
            }

            UIHelper.ColorWriteLine("\n0. 나가기\n", "Cyan");
            Console.WriteLine("숫자를 입력해 소모품을 사용하세요.");
            Console.Write(">> ");

            string input = Console.ReadLine() ?? "";
            bool intCheck = int.TryParse(input, out int number); // string to int
            if (intCheck)
            {
                if (number == 0) // 나가기
                {
                    GameManager.Instance.SceneInfo = SceneType.Inven;
                }
                else if (true)
                {
                    
                }
            }
        }
    }
}
