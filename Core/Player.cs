namespace TEXT_RPG.Core
{
    public class Player : IAttack, IAttackable
    {
        Random random = new();
        private int[] requiredExpList = { 0, 10, 35, 65, 100 };

        public string Name { get; set; }
        public string Job { get; set; }
        public int Level { get; set; }
        public Stats Stats { get; set; }
        public int Gold { get; set; }
        public int Exp { get; set; }
        public int RequiredExp { get; set; }

        public Player(string name, string job)
        { 
            Name = name;
            Job = job;
            Level = 1;
            Stats = new Stats(10, 5, 100);
            Gold = 1000;
            Exp = 0;
            RequiredExp = requiredExpList[1];
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
            int evadeRate = random.Next(0, 100);
            if (evadeRate <= 10)
            {
                Console.WriteLine("공격이 빗나갔습니다.");
                return;
            }
            int actualDamage = Stats.TakeDamage(damage);
            Console.WriteLine($"{Name} 이(가) {actualDamage} 의 피해를 입었습니다.");
        }
        public void GetExp(int exp)
        {
            Exp += exp;
            while (Exp >= RequiredExp)
            {
                if(Level < requiredExpList.Length)
                {
                    LevelUp();
                }
            }
        }
        private void LevelUp()
        {
            Level++;
            Exp -= RequiredExp;
            if (Exp < 0) { Exp = 0; }
            RequiredExp = requiredExpList[Level];

            Stats.Atk += Level;
            Stats.Def += Level;
            Stats.Hp = Stats.MaxHp;
        }
    }
}
