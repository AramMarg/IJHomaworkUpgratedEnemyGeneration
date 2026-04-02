using UnityEngine;
using UnityEngine.Pool;

public class Spawner<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _maxSize = 5;

    protected ObjectPool<T> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>
        (
        createFunc: () => Instantiate(_prefab),
        actionOnGet: (item) => OnGet(item),
        actionOnRelease: OnRelease,
        actionOnDestroy: (item) => Destroy(item),
        collectionCheck: true,
        defaultCapacity: _poolCapacity,
        maxSize: _maxSize
        );
    }

    public T Create()
    {
        return _pool.Get();
    }

    public void Return(T item)
    {
        _pool.Release(item);
    }

    protected virtual void OnGet(T item)
    {
        item.gameObject.SetActive(true);
    }

    protected virtual void OnRelease(T item)
    {
        item.gameObject.SetActive(false);
    }
}

