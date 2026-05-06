using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    [SerializeField] private MovingFence targetFence;

    [Header("Lever Rotation")]
    [SerializeField] private float activatedYRotation = -171.364f;

    private bool playerInRange = false;
    private bool isActivated = false;

    private void Update()
    {
        if (!isActivated &&
            playerInRange &&
            Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            ActivateLever();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
        {
            playerInRange = false;
        }
    }

    private void ActivateLever()
    {
        isActivated = true;

        Debug.Log("Lever activated!");

        Vector3 currentRotation = transform.localEulerAngles;

        transform.localEulerAngles = new Vector3(
            currentRotation.x,
            activatedYRotation,
            currentRotation.z
        );

        if (targetFence != null)
        {
            targetFence.ActivateFence();
        }
    }
}