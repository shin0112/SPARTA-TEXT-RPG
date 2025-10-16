using TEXT_RPG.Core;
using TEXT_RPG.Manager;
using TEXT_RPG.Repository;

namespace TEXT_RPG.Scene
{
    internal class InventoryScene
    {
        public void Inventory()
        {
            Console.Clear();
            UIHelper.ColorWriteLine("인벤토리", "Yellow");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n\n");
            Console.WriteLine("[아이템 목록]\n");

            // 아이템 리스트 나열 반복문
            foreach (var item in ItemRepository.InventoryItem)
            {
                string prefix = item.IsEquipped ? "[E] " : "";
                string displayName = prefix + item.Name;

                string statType = item.Type switch
                {
                    ItemType.Weapon => "공격력 +",
                    ItemType.Armor => "방어력 +",
                    ItemType.HP => "체력회복 +",
                    ItemType.Stamina => "스태미너 +",

                    _ => ""
                };
                string displayStat = statType + item.Value;

                string paddedName = UIHelper.GetPaddedString(displayName, 24);
                string paddedStat = UIHelper.GetPaddedString(displayStat, 12);

                Console.WriteLine($" - {paddedName} | {paddedStat} | {item.Description}");
            }

            UIHelper.ColorWriteLine("\n1. 장착 관리\n0. 나가기\n", "Cyan");
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
