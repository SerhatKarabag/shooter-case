using UnityEngine;

public interface IShootingPattern
{
    void Fire(Vector3 origin, Quaternion rot, float projSpeed, IProjectileFactory factory);
}