namespace TEXT_RPG
{
    public class Monster : IAttack
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public bool isDead { get; set; }
        public Stats Stats { get; set; }

        public Monster(string name, int level, Stats stats)
        {
            Name = name;
            Level = level;
            isDead = false;
            Stats = stats;
        }

        public void Attack(IAttack target)
        {
            if (isDead)
            {
                return;
            }
            else
            {
                
            }
        }
    }
}
