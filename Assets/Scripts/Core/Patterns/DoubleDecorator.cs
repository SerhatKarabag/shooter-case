using UnityEngine;

public class DoubleDecorator : ObserverDecorator
{
    private const float OFFSET = 0.4f;

    public DoubleDecorator(IShootingPattern inner) : base(inner) { }

    protected override void OnProjectileSpawned(Vector3 pos, Quaternion rot, float speed, IProjectileFactory realFactory)
    {
        Vector3 dupPos = pos + rot * Vector3.forward * OFFSET;
        realFactory.Spawn(dupPos, rot, speed);
    }
}