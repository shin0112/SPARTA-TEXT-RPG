namespace TEXT_RPG
{
    public class Monster : IAttack
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public bool isDead { get; set; }

        public Monster(string name, int level)
        {
            Name = name;
            Level = level;
            isDead = false;
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
