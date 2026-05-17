using UnityEngine;

public class SawMovement : MonoBehaviour
{
    [SerializeField] private Vector3 pointA;
    [SerializeField] private Vector3 pointB;
    [SerializeField] private float moveSpeed = 2f;

    private Vector3 target;

    private void Start()
    {
        target = pointB;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == pointA ? pointB : pointA;
        }
    }
}