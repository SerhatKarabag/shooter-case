using Zenject;
using UnityEngine;

public class ProjectilePool : MonoMemoryPool<Vector3, Quaternion, float, Projectile>
{
    protected override void OnCreated(Projectile item)
    {
        item.SetPool(this);
        item.gameObject.SetActive(false);
    }

    protected override void Reinitialize(Vector3 pos, Quaternion rot, float speed, Projectile item)
    {
        item.transform.SetPositionAndRotation(pos, rot);
        item.Init(speed);
    }

    protected override void OnDespawned(Projectile item)
    {
        item.gameObject.SetActive(false);
    }
}