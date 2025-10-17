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
        public List<Item> MonsterItem;
        // 각 타입별로 하나씩만 장착할 수 있는 슬롯
        public Dictionary<ItemType, int> equippedItems = new();

        private InventoryManager()
        {
            InventoryItem = itemRepository.InventoryItem;
            ShopItem = itemRepository.ShopItem;
            MonsterItem = itemRepository.MonsterItem;
        }

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

        public int equipValue(ItemType type)
        {
            int equipValue = 0;
            bool EquipCheck = equippedItems.ContainsKey(type);
            
            if (EquipCheck)
            {
                int i = equippedItems[type];
                equipValue = InventoryItem[i].Value;
            }

            return equipValue;
        }

        public string IventoryListShow(Item item, int i)
        {
            string prefix = equippedItems.ContainsValue(i) ? "[E] " : ""; //아이템 장착 여부 확인
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

            return $"{ paddedName} | { paddedStat} | { item.Description}";
        }
    }
}
