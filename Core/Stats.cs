using System.ComponentModel.DataAnnotations;
using TEXT_RPG.Manager;

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

        public void Heal(int value, int max)
        {
            Hp += value;
            Hp = Math.Min(Hp, max);
        }
    }
}
