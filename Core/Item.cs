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

        public Item(string name, int value, ItemType type, string description, int price, bool isEquipped = false)
        {
            Name = name;
            Value = value;
            Type = type;
            Description = description;
            Price = price;
            IsEquipped = isEquipped;
        }
    }
}

