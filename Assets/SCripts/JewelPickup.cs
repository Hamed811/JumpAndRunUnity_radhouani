using UnityEngine;

public class JewelPickup : MonoBehaviour
{
    [SerializeField] private VictoryManager victoryManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            victoryManager.ShowVictory();
        }
    }
}