using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Vector3 pointA;
    [SerializeField] private Vector3 pointB;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float turnSpeed = 10f;

    private Vector3 targetPoint;

    private void Start()
    {
        transform.position = pointA;
        targetPoint = pointB;
    }

    private void Update()
    {
        Vector3 direction = targetPoint - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                turnSpeed * Time.deltaTime
            );
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPoint,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetPoint) < 0.05f)
        {
            targetPoint = targetPoint == pointA ? pointB : pointA;
        }
    }
}