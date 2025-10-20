namespace TEXT_RPG.Core
{
    public interface IAttack
    {
        void Attack(IAttackable target);
    }

    public interface IAttackable
    {
        void TakeDamage(int damage);
    }
}
