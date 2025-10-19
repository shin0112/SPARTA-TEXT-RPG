using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene.Inventory
{
    internal class EquipManagementScene
    {
        public void EquipManagement()
        {
            Console.Clear();
            UIHelper.ColorWriteLine("인벤토리 - 장착 관리", "Yellow");
            Console.WriteLine("장비를 장착 또는 해제하세요.\n");
            Console.WriteLine("[아이템 목록]\n");

            var invenManager = InventoryManager.Instance;
            List<Item> item = invenManager.EquipItem;

            // 각 장비 나열
            for (int i = 0; i < item.Count; i++)
            {
                string itemString = invenManager.IventoryListShow(item[i], i);

                UIHelper.ColorWriteLine($"{i + 1}. {itemString}", "Cyan");
            }

            UIHelper.ColorWriteLine("\n0. 나가기\n", "Cyan");
            Console.WriteLine("숫자를 입력해 아이템을 장착하세요.");
            Console.Write(">> ");

            string input = Console.ReadLine() ?? "";
            bool intCheck = int.TryParse(input, out int number); // string to int
            if (intCheck)
            {
                if (number == 0) // 나가기
                {
                    GameManager.Instance.SceneInfo = SceneType.Inven;
                }
                else if (intCheck && 1 <= number && number <= item.Count) // 장비 장착 또는 해제
                {
                    invenManager.Equip(item[number - 1], number - 1);
                }
            }
        }
    }
}
