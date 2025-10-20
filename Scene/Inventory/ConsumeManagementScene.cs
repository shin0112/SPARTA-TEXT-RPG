using TEXT_RPG.Core;
using TEXT_RPG.Manager;
using TEXT_RPG.UI;

namespace TEXT_RPG.Scene.Inventory
{
    internal class ConsumeManagementScene
    {
        public void ConsumeManagement()
        {
            var invenManager = InventoryManager.Instance;
            var player = GameManager.Instance.Player;
            List<Item> inventory = invenManager.InventoryItem;
            List<Item> consumeList = new();

            Console.Clear();
            UIHelper.ColorWriteLine("인벤토리 - 소모품 관리", "Yellow");
            Console.WriteLine("소모품을 사용하세요.\n");
            Console.WriteLine("[플레이어 상태]");
            Console.WriteLine($"체력     {player.Stats.Hp} / {player.Stats.MaxHp}");
            Console.WriteLine($"스태미나 {player.Stats.Sp} / {Stats.MaxSp}\n");
            Console.WriteLine("[아이템 목록]\n");

            // 각 장비 나열
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].Type == ItemType.HP || inventory[i].Type == ItemType.Stamina)
                {
                    string itemString = invenManager.IventoryListShow(inventory[i]);
                    consumeList.Add(inventory[i]);
                    UIHelper.ColorWriteLine($"{consumeList.Count}. {itemString}", "Cyan");
                }
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
                else if (intCheck && 1 <= number && number <= consumeList.Count)
                {
                    int i = number - 1;
                    int value = consumeList[i].Value;
                    int max;

                    if (consumeList[i].Type == ItemType.HP)
                    {
                        max = player.Stats.MaxHp;
                        player.Stats.HPUp(value, max);
                    }
                    else if (consumeList[i].Type == ItemType.Stamina)
                    {
                        max = Stats.MaxSp;
                        player.Stats.SPUp(value, max);
                    }

                    inventory.Remove(consumeList[i]);
                }
            }
        }
    }
}
