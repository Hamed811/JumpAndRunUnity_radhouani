using UnityEngine;

public class MovingFence : MonoBehaviour
{
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float moveSpeed = 2f;

    private bool shouldMove = false;

    private void Update()
    {
        if (!shouldMove)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
    }

    public void ActivateFence()
    {
        shouldMove = true;
    }
}