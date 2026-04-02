using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] Transform _spawnPoint;

    private Player _target;

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

    public void SetPlayer(Player player)
    {
        _target = player;

         Enemy enemy = Create();

        if (enemy.TryGetComponent(out EnemyMover enemyMover))
        {
            enemyMover.SetTarget(_target);
        }
    }
}
