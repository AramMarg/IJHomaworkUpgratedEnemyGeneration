using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 6;

    public Player Target { get; private set; } 

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position,
                _speed * Time.deltaTime);
    }

    public void SetTarget(Player target)
    {
        Target = target;
    }

    public void ResetTarget()
    {
        Target = null;
    }
}
