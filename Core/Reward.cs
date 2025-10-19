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
                    DropItem.Add(InventoryManager.Instance.MonsterItem[index]);
                }
                else
                {
                }
            }
        }

        public void Add(Reward other)
        {
            Exp += other.Exp;
            Gold += other.Gold;
            DropItem.AddRange(other.DropItem);
        }

        public void Get(Player player)
        {
            player.GetExp(Exp);
            player.Gold += Gold;
            InventoryManager.Instance.EquipItem.AddRange(DropItem);

            Console.WriteLine($"{Exp} 경험치와 {Gold} G를 획득했습니다.");
            foreach (Item item in DropItem) 
            { 
                Console.WriteLine($"{item.Name} 을(를) 획득했습니다.");
            }
        }
    }
}
