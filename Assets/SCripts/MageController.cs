using UnityEngine;
using UnityEngine.InputSystem;

public class MageController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float jumpHeight = 1.2f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float raycastDistance = 1.3f;

    [SerializeField] private AudioSource footstepAudioSource;
    [SerializeField] private AudioSource jumpAudioSource;

    [SerializeField] private Animator animator;

    private CharacterController controller;
    private InputAction moveAction;
    private InputAction jumpAction;

    private Vector3 velocity;
    private Vector3 platformVelocity;

    private bool isGrounded;
    private bool isJumping;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    private void FixedUpdate()
    {
        if (controller == null || cameraTransform == null || moveAction == null)
        {
            return;
        }

        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
            isJumping = false;
        }

        Vector2 input = moveAction.ReadValue<Vector2>();

        bool isMoving = Mathf.Abs(input.x) > 0.1f || Mathf.Abs(input.y) > 0.1f;
        bool isSprinting = isMoving && Keyboard.current != null && Keyboard.current.leftShiftKey.isPressed;

        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 characterMovement = (camForward * input.y + camRight * input.x) * currentSpeed * Time.fixedDeltaTime;

        GetPlatformVelocity();

        UpdateAnimations(isMoving, isSprinting);

        if (isMoving && isGrounded)
        {
            if (footstepAudioSource != null && !footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Play();
            }
        }
        else
        {
            if (footstepAudioSource != null && footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Stop();
            }
        }

        if (jumpAction != null && jumpAction.WasPressedThisFrame() && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isJumping = true;

            if (jumpAudioSource != null)
            {
                jumpAudioSource.Play();
            }
        }

        Vector3 combinedMovement = characterMovement;

        if (!isJumping)
        {
            combinedMovement += platformVelocity * Time.fixedDeltaTime;
        }

        controller.Move(combinedMovement);

        velocity.y += gravity * Time.fixedDeltaTime;
        controller.Move(velocity * Time.fixedDeltaTime);
    }

    private void UpdateAnimations(bool isMoving, bool isSprinting)
    {
        if (animator == null)
        {
            return;
        }

        animator.SetBool("isWalking", isMoving && isGrounded && !isSprinting);
        animator.SetBool("isRunning", isMoving && isGrounded && isSprinting);
        animator.SetBool("isJumping", !isGrounded);
    }

    private void GetPlatformVelocity()
    {
        platformVelocity = Vector3.zero;

        int platformLayerMask = LayerMask.GetMask("Platforms");
        Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;

        if (Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, raycastDistance, platformLayerMask))
        {
            MovingPlatform movingPlatform = hit.collider.GetComponent<MovingPlatform>();

            if (movingPlatform != null)
            {
                platformVelocity = movingPlatform.GetVelocity();
            }
        }
    }
}