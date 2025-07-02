using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PowerUpController : IInitializable
{
    public event Action<PowerUpConfig> OnSelected;
    public event Action OnLimitReached;

    const int MAX_SELECTION = 3;

    readonly Shooter _player;
    readonly ShooterPool _shooterPool;
    readonly PatternBuilder _builder;

    readonly List<PowerUpConfig> _chosen = new();
    bool LimitReached => _chosen.Count >= MAX_SELECTION;

    [Inject]
    public PowerUpController(Shooter player, ShooterPool pool)
    {
        _player = player;
        _shooterPool = pool;
        _builder = new PatternBuilder(_player);
    }

    public void Initialize() => _chosen.Clear();

    public void Select(PowerUpConfig cfg)
    {
        if (LimitReached || _chosen.Contains(cfg)) return;

        _chosen.Add(cfg);

        bool spawnCloneRequested = cfg.effects.Any(e => e.kind == EffectKind.Clone);

        ApplyInstantStats(cfg);

        RebuildPattern();

        if (spawnCloneRequested)
            SpawnClone();

        OnSelected?.Invoke(cfg);
        if (LimitReached) OnLimitReached?.Invoke();
    }

    void ApplyInstantStats(PowerUpConfig cfg)
    {
        foreach (ShootingEffect e in cfg.effects)
        {
            if (e.kind == EffectKind.FireRateMul)
                _player.OverrideFireRate(_player.CurrentFireRate * e.value);

            else if (e.kind == EffectKind.SpeedMul)
                _player.MultiplySpeed(e.value);
        }
    }

    void RebuildPattern()
    {
        IShootingPattern pattern = _builder.Build(_chosen);
        _player.SetPattern(pattern);
    }

    void SpawnClone()
    {
        Vector3 pos = ComputeSpawnPos();
        Quaternion rot = _player.transform.rotation;

        Shooter clone = _shooterPool.Spawn(pos, rot);
        clone.CopyStateFrom(_player);
    }

    Vector3 ComputeSpawnPos()
    {
        const float MIN = 5f, MAX = 10f, HALF_FOV = 60f;

        Vector3 dir = Camera.main.transform.forward; dir.y = 0; dir.Normalize();
        float angle = UnityEngine.Random.Range(-HALF_FOV, HALF_FOV);
        dir = Quaternion.Euler(0, angle, 0) * dir;
        float dist = UnityEngine.Random.Range(MIN, MAX);

        return _player.transform.position + dir * dist;
    }
}