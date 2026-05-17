using UnityEngine;

public class FogZoneDamage : MonoBehaviour
{
    [SerializeField] private int damagePerTick = 5;
    [SerializeField] private float tickRate = 1f;

    private float timer;

    private void OnTriggerStay(Collider other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health == null)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= tickRate)
        {
            health.TakeDamage(damagePerTick);
            timer = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            timer = 0f;
        }
    }
}