using System.ComponentModel.DataAnnotations;

namespace TEXT_RPG.Core
{
    public class Stats
    {
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }

        public Stats(int atk, int def, int hp)
        {
            Atk = atk;
            Def = def;
            MaxHp = hp;
            Hp = hp;
        }

        public int TakeDamage(int damage)
        {
            int actualDamage = Math.Max(damage - Def, 0);
            Hp = Math.Max(Hp - actualDamage, 0);
            return actualDamage;
        }
    }
}
