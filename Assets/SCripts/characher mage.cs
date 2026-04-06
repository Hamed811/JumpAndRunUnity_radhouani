using UnityEngine;
using UnityEngine.InputSystem;
public class charachermage : MonoBehaviour
{
   private CharacterController controller;




    private InputAction moveAction;

    [SerializeField]
    private float charackterspeed ;
    [SerializeField]
    private Transform cameraTransform ;



    private Vector3 charachtermovment;



    private void Start()
    {
        this.controller = this.GetComponent<CharacterController>();
        this.moveAction = InputSystem.actions.FindAction("Move");
    }

    private void FixedUpdate()
    {
        var inputMovement = this.moveAction.ReadValue<Vector2>();

        var inputRightDirection = this.cameraTransform.right;
        var inputForwardDirection = this.cameraTransform.forward;

        inputRightDirection.y = 0.0f;
        inputForwardDirection.y = 0.0f;
        inputRightDirection.Normalize();
        inputForwardDirection.Normalize();

        this.charachtermovment += inputRightDirection * inputMovement.x * this.charackterspeed * Time.fixedDeltaTime;
        this.charachtermovment += inputForwardDirection * inputMovement.y * this.charackterspeed * Time.fixedDeltaTime;

        this.controller.Move(this.charachtermovment);
    }
}
