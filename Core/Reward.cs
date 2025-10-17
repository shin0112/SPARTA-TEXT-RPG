using TEXT_RPG.Repository;

namespace TEXT_RPG.Core
{
    internal class Reward
    {
        public int Exp { get; private set; }
        public int Gold { get; private set; }
        public List<Item> DropItem { get; private set; }

        public Reward(int exp, int gold, List<Item> drop)
        {
            Exp = exp;
            Gold = gold;
            DropItem = drop;
        }

        public void Add(Reward other)
        {
            Exp += other.Exp;
            Gold += other.Gold;
            
        }

        public void Get(Player player)
        {

        }
    }
}
