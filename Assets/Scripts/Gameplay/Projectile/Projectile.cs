using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour
{
    [SerializeField] float lifeTime = 3f;

    float _speed;
    float _timer;

    IMemoryPool _pool;

    public void SetPool(IMemoryPool pool) => _pool = pool;

    public void Init(float speed)
    {
        _speed = speed;
        _timer = lifeTime;
        gameObject.SetActive(true);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        _timer -= Time.deltaTime;

        if (_timer <= 0f)
            _pool.Despawn(this);
    }
}