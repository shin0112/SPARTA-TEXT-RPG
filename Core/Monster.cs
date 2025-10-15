namespace TEXT_RPG.Core
{
    public class Monster : IAttack, IAttackable
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Stats Stats { get; set; }

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

        public Monster(string name, int level, Stats stats)
        {
            Name = name;
            Level = level;
            IsDead = false;
            Stats = stats;
        }

        public void Attack(IAttackable target)
        {
            if (IsDead)
            {
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
                Stats.TakeDamage(damage);
                Console.WriteLine($"{Name} 이(가) {damage} 의 피해를 입었습니다.");
                IsDead = Stats.Hp <= 0;
            }
        }
    }
}
