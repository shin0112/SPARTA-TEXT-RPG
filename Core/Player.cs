namespace TEXT_RPG.Core
{
    public class Player : IAttack, IAttackable
    {
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
            target.TakeDamage(Stats.Atk);
        }
        public void TakeDamage(int damage)
        {
            Stats.TakeDamage(damage);
            Console.WriteLine($"{Name} 이(가) {damage} 의 피해를 입었습니다.");
        }
    }
}
