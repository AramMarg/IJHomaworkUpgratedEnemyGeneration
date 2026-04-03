using UnityEngine;
using UnityEngine.Pool;

public class Spawner<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _maxSize = 5;

    protected ObjectPool<T> Pool;

    private void Awake()
    {
        Pool = new ObjectPool<T>
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
        return Pool.Get();
    }

    public void Return(T item)
    {
        Pool.Release(item);
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

