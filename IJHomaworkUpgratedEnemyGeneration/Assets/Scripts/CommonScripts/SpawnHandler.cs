using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private List<EnemySpawner> _enemySpawners;

    private Coroutine _coroutine;

    private float _delay = 5f;

    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new(_delay);

        _coroutine = StartCoroutine(nameof(StartPooling));
    }    

    private IEnumerator StartPooling()
    {
        while (enabled)
        {
            foreach (var enemySpawner in _enemySpawners)
            {
                enemySpawner.SetPlayer(_playerSpawner.Create());
            }

            yield return _wait;
        }
    }
}
