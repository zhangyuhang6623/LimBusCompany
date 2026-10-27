public abstract class AttackState
{
    protected Attack nowAttack;
    protected Attributs sineAttribute;
    public abstract void  Enter(Attack attack);
    public abstract void LogicUpdate();
    public abstract void Exit();
}
