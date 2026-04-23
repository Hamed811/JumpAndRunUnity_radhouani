using UnityEngine;

public class EnemyStompZone : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("StompZone hit by: " + other.name);

        if (other.CompareTag("Player"))
        {
            if (enemy != null)
            {
                enemy.DefeatEnemy();
            }
        }
    }
}