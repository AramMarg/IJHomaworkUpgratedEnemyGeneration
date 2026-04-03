using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public PlayerMover Mover { get; private set; }

    private void Awake()
    {
        if (TryGetComponent(out PlayerMover playerMover))
        {
            Mover = playerMover;
        }
    }
}
