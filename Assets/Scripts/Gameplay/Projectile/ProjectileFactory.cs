using UnityEngine;

public class ProjectileFactory : IProjectileFactory
{
    readonly ProjectilePool _pool;

    public ProjectileFactory(ProjectilePool pool)
    {
        _pool = pool;
    }

    public Projectile Spawn(Vector3 position, Quaternion rotation, float speed)
    {
        return _pool.Spawn(position, rotation, speed);
    }
}