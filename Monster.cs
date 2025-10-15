namespace TEXT_RPG
{
    public class Monster : IAttack, IAttackable
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

        public void Attack(IAttackable target)
        {
            if (isDead)
            {
                return;
            }
            else
            {
                target.TakeDamage(Stats.Atk);
            }
        }
        public void TakeDamage(int damage)
        {
            if (isDead)
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
            else
            {
                Stats.TakeDamage(damage);
                Console.WriteLine($"{Name} 이(가) {damage} 의 피해를 입었습니다.");
            }
        }
    }
}
