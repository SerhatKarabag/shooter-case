using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [Header("Prefabs")]
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Shooter playerPrefab;

    public override void InstallBindings()
    {
        InstallProjectilePool();
        InstallProjectileFactory();
        InstallShooterAndPools();
        InstallPatterns();
        InstallPowerUps();
    }

    void InstallProjectilePool()
    {
        Container.BindMemoryPool<Projectile, ProjectilePool>()
                 .WithInitialSize(32)
                 .FromComponentInNewPrefab(projectilePrefab)
                 .UnderTransformGroup("ProjectilePool");
    }

    void InstallProjectileFactory()
    {
        Container.Bind<IProjectileFactory>()
                 .To<ProjectileFactory>()
                 .AsSingle();
    }

    void InstallShooterAndPools()
    {
        Container.BindInterfacesAndSelfTo<Shooter>()
                 .FromComponentInNewPrefab(playerPrefab)
                 .AsSingle()
                 .NonLazy();

        Container.BindMemoryPool<Shooter, ShooterPool>()
                 .WithInitialSize(4)
                 .FromComponentInNewPrefab(playerPrefab)
                 .UnderTransformGroup("ShooterPool");
    }

    void InstallPatterns()
    {
        Container.Bind<IShootingPattern>()
                 .To<SingleShotPattern>()
                 .AsSingle();
    }

    void InstallPowerUps()
    {
        Container.BindInterfacesAndSelfTo<PowerUpController>()
                 .AsSingle();
    }
}