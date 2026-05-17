using UnityEngine;

public class SawRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 600f;

    private void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}