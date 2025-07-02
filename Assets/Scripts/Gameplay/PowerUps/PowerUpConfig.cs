using UnityEngine;

[CreateAssetMenu(menuName = "Shoot/PowerUp Config")]
public class PowerUpConfig : ScriptableObject
{
    public string displayName = "New Power";
    public int priority;
    public ShootingEffect[] effects;
}