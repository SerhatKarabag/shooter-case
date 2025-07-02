using UnityEngine;

[CreateAssetMenu(menuName = "Shoot/Shooter Settings")]
public class ShooterSettings : ScriptableObject
{
    public float baseFireRate = 2f;
    public float baseProjectileSpeed = 8f;
    public IShootingPattern defaultPattern = new SingleShotPattern();
}