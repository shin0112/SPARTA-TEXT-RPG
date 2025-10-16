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
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n\n");
            Console.WriteLine("[아이템 목록]\n");

            // 아이템 리스트 나열 반복문
            foreach (var item in ItemRepository.InventoryItem)
            {
                string isEquip = item.IsEquipped ? "[E] " : "    "; // 각 장비 장착 여부 표시
                Console.WriteLine($" - {isEquip}{item.Name}\t| {item.Type} +{item.Value}\t| {item.Description}");
            }

            Console.WriteLine("\n1. 장착 관리\n0. 나가기\n");
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
