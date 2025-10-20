namespace TEXT_RPG.Core
{
    public class Monster : IAttack, IAttackable
    {
        Random random = new();

        public string Name { get; set; }
        public int Level { get; set; }
        public Stats Stats { get; set; }
        internal Reward Reward { get; set; }
        public MonsterType MonsterType { get; private set; }

        public event Action<bool>? OnDeadChanged;
        private bool _isDead;
        public bool IsDead
        {
            get => _isDead;
            set
            {
                if (_isDead != value)
                {
                    _isDead = value;
                    OnDeadChanged?.Invoke(_isDead);
                }
            }
        }

        internal Monster(string name, int level, Stats stats, Reward reward, MonsterType monsterType = MonsterType.Normal)
        {
            Name = name;
            Level = level;
            IsDead = false;
            Stats = stats;
            Reward = reward;
            MonsterType = monsterType;
        }

        public void Attack(IAttackable target)
        {
            if (IsDead)
            {
                return;
            }
            int evadeRate = random.Next(0, 100);
            if (evadeRate <= 10)
            {
                Console.WriteLine("공격이 빗나갔습니다.");
                return;
            }
            target.TakeDamage(Stats.Atk);
        }
        public void TakeDamage(int damage)
        {
            if (IsDead)
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
            else
            {
                int actualDamage = Math.Max(damage - Stats.Def, 0);
                Stats.Hp = Math.Max(Stats.Hp - actualDamage, 0);
                Console.WriteLine($"{Name} 이(가) {actualDamage} 의 피해를 입었습니다.");
                IsDead = Stats.Hp <= 0;
            }
        }

        public Monster Clone()
        {
            return new Monster(Name, Level, new Stats(Stats.Atk, Stats.Def, Stats.Hp), Reward);
        }
    }
}
