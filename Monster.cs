namespace TEXT_RPG
{
    public class Monster
    {
        public string name;
        public int level;
        public int atk;
        public int def;
        public int hp;
        public bool isDead;

        public Monster(string name, int level)
        {
            this.name = name;
            this.level = level;
            this.atk = level * 3;
            this.def = 0;
            this.hp = level * 5;
            this.isDead = false;
        }

        public void Attack()
        {

        }
    }
}
