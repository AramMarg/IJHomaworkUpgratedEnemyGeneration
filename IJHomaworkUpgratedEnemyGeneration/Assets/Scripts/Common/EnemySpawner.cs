using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private Transform _spawnPoint;

    protected override void OnGet(Enemy enemy)
    {
        base.OnGet(enemy);

        enemy.PlayerCatched += Return;

        enemy.transform.position = _spawnPoint.position;
    }

    protected override void OnRelease(Enemy enemy)
    {
        base.OnRelease(enemy);

        enemy.PlayerCatched -= Return;
    }
}
