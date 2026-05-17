using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float spawnInterval = 2f;

    private void Start()
    {
        Debug.Log("FireballSpawner started");
        InvokeRepeating(nameof(SpawnFireball), 1f, spawnInterval);
    }

    private void SpawnFireball()
    {
        Debug.Log("Spawning fireball");

        GameObject fireball = Instantiate(
            fireballPrefab,
            pointA.position,
            Quaternion.identity
        );

        FireballMove move = fireball.GetComponent<FireballMove>();

        if (move == null)
        {
            Debug.LogError("FireballMove fehlt auf dem Fireball Prefab!");
            return;
        }

        move.SetTarget(pointB.position);
    }
}