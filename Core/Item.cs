namespace TEXT_RPG.Core
{
    internal class Item
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public ItemType Type { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool IsEquipped { get; set; }
        public bool IsBuy { get; set; }

        public Item(string name, int value, ItemType type, string description, int price, bool isEquipped = false, bool isBuy = false)
        {
            Name = name;
            Value = value;
            Type = type;
            Description = description;
            Price = price;
            IsEquipped = isEquipped;
            IsBuy = isBuy;
        }

        // 깊은 복사 메서드
        public Item Clone()
        {
            return new Item(Name, Value, Type, Description, Price, IsEquipped, IsBuy);
        }
    }
}

