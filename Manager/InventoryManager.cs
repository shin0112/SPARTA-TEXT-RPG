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

    }
}
