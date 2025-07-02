using UnityEngine;
using Zenject;

public class ShooterPool : MonoMemoryPool<Vector3, Quaternion, Shooter>
{
    protected override void Reinitialize(Vector3 pos, Quaternion rot, Shooter item)
    {
        item.transform.SetPositionAndRotation(pos, rot);
        item.ResetTimer();
    }
}