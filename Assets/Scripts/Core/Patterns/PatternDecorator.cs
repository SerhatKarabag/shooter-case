using UnityEngine;

public abstract class PatternDecorator : IShootingPattern
{
    protected readonly IShootingPattern Inner;
    protected PatternDecorator(IShootingPattern inner) => Inner = inner;
    public abstract void Fire(Vector3 o, Quaternion r, float s, IProjectileFactory f);
}