using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    public PlayerMover Mover { get; private set; }

    private void Awake()
    {
       Mover = GetComponent<PlayerMover>();
    }
}
