using UnityEngine;

public class SingleShotPattern : IShootingPattern
{
    public void Fire(Vector3 o, Quaternion r, float s, IProjectileFactory f)
        => f.Spawn(o, r, s);
}