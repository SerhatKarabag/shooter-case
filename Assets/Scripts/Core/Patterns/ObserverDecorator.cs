using UnityEngine;

public abstract class ObserverDecorator : PatternDecorator
{
    protected ObserverDecorator(IShootingPattern inner) : base(inner) { }

    public override void Fire(Vector3 origin, Quaternion rot, float speed, IProjectileFactory realFactory)
    {
        ProxyFactory proxy = new ProxyFactory(this, realFactory);
        Inner.Fire(origin, rot, speed, proxy);
    }

    protected abstract void OnProjectileSpawned(Vector3 pos, Quaternion rot, float speed, IProjectileFactory realFactory);

    private class ProxyFactory : IProjectileFactory
    {
        readonly ObserverDecorator _observer;
        readonly IProjectileFactory _real;

        public ProxyFactory(ObserverDecorator observer, IProjectileFactory real)
        {
            _observer = observer;
            _real = real;
        }

        public Projectile Spawn(Vector3 pos, Quaternion rot, float spd)
        {
            Projectile p = _real.Spawn(pos, rot, spd);
            _observer.OnProjectileSpawned(pos, rot, spd, _real);
            return p;
        }
    }
}