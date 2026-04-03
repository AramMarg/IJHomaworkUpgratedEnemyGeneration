using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private List<EnemySpawner> _enemySpawners;

    private List<Player> _targets = new();

    private int _indexTarget = 0;

    private Coroutine _coroutine;

    private float _delay = 10f;

    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new(_delay);

        foreach (var enemySpawner in _enemySpawners)
        {
            _targets.Add(_playerSpawner.Create());
        }

        _coroutine = StartCoroutine(nameof(EnemyPooling));
    }    

    private IEnumerator EnemyPooling()
    {
        while (enabled)
        {
            foreach (var enemySpawner in _enemySpawners)
            {
                if (enemySpawner.Create().TryGetComponent(out EnemyMover enemyMover))
                {
                    enemyMover.SetTarget(_targets[_indexTarget++]);
                }
            }

            _indexTarget = 0;

            yield return _wait;
        }
    }
}
