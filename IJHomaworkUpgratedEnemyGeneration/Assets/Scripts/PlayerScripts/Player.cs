using System;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public event Action<Player> Died;

    public void Die()
    {
        Died?.Invoke(this);
    }
}
