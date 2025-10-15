namespace TEXT_RPG
{
    public class Stats
    {
        public int Atk {  get; set; }
        public int Def {  get; set; }
        public int Hp { get; set; }

        public Stats(int atk, int def, int hp)
        {
            Atk = atk;
            Def = def;
            Hp = hp;
        }

        public void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(damage - Def, 0);
            Hp = Math.Max(Hp - actualDamage, 0);
        }
    }
}
