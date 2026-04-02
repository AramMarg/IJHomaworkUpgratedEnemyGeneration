using System;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    public EnemyMover EnemyMover { get; private set; }

    public event Action<Enemy> PlayerCatched;

    private void Awake()
    {
        EnemyMover = GetComponent<EnemyMover>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = EnemyMover.Target;

        if (player != null)
        {
            if (collision.gameObject == EnemyMover.Target.gameObject)
            {
                PlayerCatched?.Invoke(this);

                player.Die();

                EnemyMover.ResetTarget();
            }
        }
    }    
}
