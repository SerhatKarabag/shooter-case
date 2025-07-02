using UnityEngine;
using Zenject;

public class Shooter : MonoBehaviour, IInitializable, ITickable, IPoolable<Vector3, Quaternion, IMemoryPool>
{
    [SerializeField] private ShooterSettings settings;

    float _fireRate;
    float _projectileSpeed;
    float _timer;

    IShootingPattern _pattern;
    IProjectileFactory _factory;

    [Inject] TickableManager _tickMgr;

    [Inject]
    void Construct(IProjectileFactory factory, IShootingPattern defaultPattern)
    {
        _factory = factory;
        _pattern = defaultPattern;
    }

    public void Initialize()
    {
        _fireRate = settings.baseFireRate;
        _projectileSpeed = settings.baseProjectileSpeed;
    }

    public void OnSpawned(Vector3 pos, Quaternion rot, IMemoryPool _)
    {
        transform.SetPositionAndRotation(pos, rot);
        ResetTimer();
    }

    public void OnDespawned() => _tickMgr.Remove(this);

    public void ResetTimer()
    {
        _timer = 0f;
        _tickMgr.Add(this);
    }

    public void Tick()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            _pattern.Fire(transform.position, transform.rotation, _projectileSpeed, _factory);
            _timer = _fireRate;
        }
    }

    public void AddPatternDecorator(System.Func<IShootingPattern, IShootingPattern> wrap)
        => _pattern = wrap(_pattern);
    public void CopyStateFrom(Shooter src)
    {
        _pattern = src._pattern;
        _fireRate = src._fireRate;
        _projectileSpeed = src._projectileSpeed;
        _timer = 0f;
    }
    public void OverrideFireRate(float seconds)
    {
        float ratio = seconds / _fireRate;
        _fireRate = seconds;
        _timer *= ratio;
    }
    public void SetPattern(IShootingPattern p) => _pattern = p;
    public void MultiplySpeed(float multiplier) => _projectileSpeed *= multiplier;
    public float CurrentFireRate => _fireRate;
    public float CurrentProjectileSpeed => _projectileSpeed;
    public float BaseFireRate => settings.baseFireRate;
}