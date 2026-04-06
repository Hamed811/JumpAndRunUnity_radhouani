using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    [SerializeField] private MovingFence targetFence;

    private bool playerInRange = false;
    private bool isActivated = false;

    private void FixedUpdate()
    {
        if (!isActivated && playerInRange && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
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

        if (targetFence != null)
        {
            targetFence.ActivateFence();
        }
    }
}