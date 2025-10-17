using TEXT_RPG.Core;
using TEXT_RPG.Repository;

namespace TEXT_RPG.Manager
{
    internal class InventoryManager
    {
        // 싱글톤
        private static InventoryManager _instance = new();
        public static InventoryManager Instance => _instance;


        // 리포지터리 복제
        private readonly ItemRepository itemRepository = new();

        public List<Item> InventoryItem;
        public List<Item> ShopItem;

        private InventoryManager()
        {
            InventoryItem = itemRepository.InventoryItem;
            ShopItem = itemRepository.ShopItem;
        }

        // 각 타입별로 하나씩만 장착할 수 있는 슬롯
        public Dictionary<ItemType, int> equippedItems = new();

        // 아이템 장착
        public void Equip(Item item, int number)
        {
            if (equippedItems.ContainsKey(item.Type) && equippedItems[item.Type] == number)
            {
                equippedItems.Remove(item.Type);
            }
            else
            {
                equippedItems[item.Type] = number;
            }
        }
    }
}
