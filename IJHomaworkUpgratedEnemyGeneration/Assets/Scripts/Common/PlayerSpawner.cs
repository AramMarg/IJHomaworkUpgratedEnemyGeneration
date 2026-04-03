using Random = UnityEngine.Random;
using UnityEngine;

public class PlayerSpawner : Spawner<Player>
{
    [SerializeField] private Transform[] _wayPoints;

    protected override void OnGet(Player player)
    {
        base.OnGet(player);

        player.transform.position = GenerateSpawnPosition();

        player.Mover.SetWayPoints(_wayPoints);
    }

    private  Vector3 GenerateSpawnPosition()
    {
        int minForRandom = 0;
        int maxForRandom = _wayPoints.Length;

        return _wayPoints[Random.Range(minForRandom, maxForRandom)].position;
    }
}
