using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound;

    private CoinManager coinManager;
    private bool collected = false;

    private void Start()
    {
        coinManager = FindFirstObjectByType<CoinManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;
        if (!other.CompareTag("Player")) return;

        collected = true;

        if (coinManager != null)
        {
            coinManager.AddCoin();
        }

        if (coinSound != null)
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
        }

        gameObject.SetActive(false);
    }

    public void ResetCoin()
    {
        collected = false;
        gameObject.SetActive(true);
    }
}