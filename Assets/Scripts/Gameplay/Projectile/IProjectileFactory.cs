using UnityEngine;

public interface IProjectileFactory
{
    Projectile Spawn(Vector3 position, Quaternion rotation, float speed);
}