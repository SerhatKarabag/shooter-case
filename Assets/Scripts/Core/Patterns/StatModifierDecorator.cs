using UnityEngine;

public class StatModifierDecorator : PatternDecorator
{
    readonly float _speedMul;

    public StatModifierDecorator(IShootingPattern inner, float speedMul = 1f) : base(inner)
    {
        _speedMul = speedMul;
    }

    public override void Fire(Vector3 origin, Quaternion rot, float speed, IProjectileFactory fac)
    {
        Inner.Fire(origin, rot, speed * _speedMul, fac);
    }
}