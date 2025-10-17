using TEXT_RPG.Core;
using TEXT_RPG.Manager;
using TEXT_RPG.Repository;

namespace TEXT_RPG.Scene
{
    internal class EquipManagementScene
    {
        public void EquipManagement()
        {
            Console.Clear();
            UIHelper.ColorWriteLine("인벤토리 - 장착 관리", "Yellow");
            Console.WriteLine("장비를 장착 또는 해제하거나, 소모품을 사용하세요.\n");
            Console.WriteLine("[아이템 목록]\n");

            List<Item> item = ItemRepository.InventoryItem;

            // 각 장비 나열
            for (int i = 0; i < item.Count; i++)
            {
                string prefix = item[i].IsEquipped ? "[E] " : "";
                string displayName = prefix + item[i].Name;

                string statType = item[i].Type switch
                {
                    ItemType.Weapon => "공격력 +",
                    ItemType.Armor => "방어력 +",
                    ItemType.HP => "체력회복 +",
                    ItemType.Stamina => "스태미너 +",

                    _ => ""
                };
                string displayStat = statType + item[i].Value;

                string paddedName = UIHelper.GetPaddedString(displayName, 24);
                string paddedStat = UIHelper.GetPaddedString(displayStat, 12);

                UIHelper.ColorWriteLine($"{i + 1}. {paddedName} | {paddedStat} | {item[i].Description}", "Cyan");
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
                else if (intCheck && (1 <= number && number <= item.Count)) // 장비 장착 또는 해제
                {
                    item[number - 1].IsEquipped = !item[number - 1].IsEquipped;
                }
            }
        }
    }
}
