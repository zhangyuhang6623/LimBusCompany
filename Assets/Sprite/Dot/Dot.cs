public abstract class Dot 
{
    public int dotLevel;
    protected float dotHurt;
    protected int maxDotLenel;
    protected float dotDuration;
    protected float dotTimeInterval;
    public abstract void DotAchive(Character character);
    public abstract void DotApply(int level);
    public abstract void Timer();
}
