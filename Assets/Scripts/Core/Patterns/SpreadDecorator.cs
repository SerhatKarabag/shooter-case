using UnityEngine;

public class SpreadDecorator : PatternDecorator
{
    const float ANGLE = 45f;
    public SpreadDecorator(IShootingPattern inner) : base(inner) { }
    public override void Fire(Vector3 o, Quaternion r, float s, IProjectileFactory f)
    {
        Inner.Fire(o, r, s, f);
        f.Spawn(o, r * Quaternion.Euler(0, ANGLE, 0), s);
        f.Spawn(o, r * Quaternion.Euler(0, -ANGLE, 0), s);
    }
}