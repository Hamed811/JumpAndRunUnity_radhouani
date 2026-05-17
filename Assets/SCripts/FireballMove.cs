using UnityEngine;

public class FireballMove : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private int damage = 50;

    private Vector3 target;
    private bool hasTarget = false;
    private bool hasHitPlayer = false;

    public void SetTarget(Vector3 targetPosition)
    {
        target = targetPosition;
        hasTarget = true;
    }

    private void Update()
    {
        if (!hasTarget)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        TryDamagePlayer(other);
    }

    private void OnTriggerStay(Collider other)
    {
        TryDamagePlayer(other);
    }

    private void TryDamagePlayer(Collider other)
    {
        if (hasHitPlayer)
        {
            return;
        }

        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health == null)
        {
            health = other.GetComponentInParent<PlayerHealth>();
        }

        if (health != null)
        {
            hasHitPlayer = true;
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}