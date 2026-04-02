using Random = UnityEngine.Random;
using UnityEngine;

public class PlayerSpawner : Spawner<Player>
{
    [SerializeField] Transform[] _wayPoints;

    protected override void OnGet(Player player)
    {
        base.OnGet(player);

        player.Died += Return;

        player.transform.position = GetSpawnNextPosition();

        if (player.TryGetComponent(out PlayerMover playerMover))
        {
            playerMover.SetWayPoints(_wayPoints);
        }
    }

    protected override void OnRelease(Player player)
    {
        base.OnRelease(player);

        player.Died -= Return;
    }

    private  Vector3 GetSpawnNextPosition()
    {
        int minForRandom = 0;
        int maxForRandom = _wayPoints.Length;

        return _wayPoints[Random.Range(minForRandom, maxForRandom)].position;
    }
}
