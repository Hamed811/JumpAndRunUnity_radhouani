using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int damage = 20;

    private bool canDamage = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!canDamage)
        {
            return;
        }

        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.TakeDamage(damage);

            canDamage = false;

            Invoke(nameof(ResetDamage), 1f);
        }
    }

    private void ResetDamage()
    {
        canDamage = true;
    }
}