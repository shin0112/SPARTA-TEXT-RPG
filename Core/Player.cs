namespace TEXT_RPG.Core
{
    public class Player : IAttack, IAttackable
    {
        Random random = new Random();

        public string Name { get; set; }
        public string Job { get; set; }
        public int Level { get; set; }
        public Stats Stats { get; set; }
        public int Gold { get; set; }
        public int Exp { get; set; }

        public Player(string name, string job)
        { 
            Name = name;
            Job = job;
            Level = 1;
            Stats = new Stats(10, 5, 100);
            Gold = 1000;
            Exp = 0;
        }

        public void Attack(IAttackable target)
        {
            Console.WriteLine($"{Name}의 공격!");
            int criticalRate = random.Next(0, 100);
            if (criticalRate <= 15)
            {
                Console.WriteLine("치명타 발생!");
                target.TakeDamage((int)Math.Ceiling(Stats.Atk * 1.6f));
                return;
            }
            target.TakeDamage(Stats.Atk);
        }
        public void TakeDamage(int damage)
        {
            Stats.TakeDamage(damage);
            Console.WriteLine($"{Name} 이(가) {damage} 의 피해를 입었습니다.");
        }
    }
}
