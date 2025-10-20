using TEXT_RPG.Manager;
using TEXT_RPG.Repository;

namespace TEXT_RPG.Core
{
    internal class Reward
    {
        public int Exp { get; private set; }
        public int Gold { get; private set; }
        public List<Item> DropItem { get; private set; }

        public Reward(int exp, int gold, List<int> dropIndex)
        {
            Exp = exp;
            Gold = gold;
            DropItem = new List<Item>();

            foreach (int index in dropIndex)
            {
                if (index >= 0 && index < InventoryManager.Instance.MonsterItem.Count)
                {
                    DropItem.Add(InventoryManager.Instance.MonsterItem[index].Clone());
                }
            }
        }
        public void Add(Reward other)
        {
            Exp += other.Exp;
            Gold += other.Gold;
            DropItem.AddRange(other.DropItem);
        }
    }
}
