using UnityEngine;

public class SawTrap : MonoBehaviour
{
    [SerializeField] private int damage = 20;
    [SerializeField] private AudioSource hitAudioSource;

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

            if (hitAudioSource != null)
            {
                hitAudioSource.Play();
                hitAudioSource.SetScheduledEndTime(
                    AudioSettings.dspTime + 0.3f
                );
            }

            canDamage = false;
            Invoke(nameof(ResetDamage), 1f);
        }
    }

    private void ResetDamage()
    {
        canDamage = true;
    }
}