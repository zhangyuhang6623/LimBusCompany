public abstract class CharacterState
{
    protected Character nowState;
    public abstract void Enter(Character character);
    public abstract void LogicUpdate();
    public abstract void Exit();
}
