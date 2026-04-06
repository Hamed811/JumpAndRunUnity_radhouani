using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float platformSpeed = 1f;
    [SerializeField] private Vector3 start;
    [SerializeField] private Vector3 end;

    private Vector3 lastPosition;
    private Vector3 velocity;

    private void Start()
    {
        transform.localPosition = start;
        lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        float pingPong = Mathf.PingPong(Time.fixedTime * platformSpeed, 1.0f);
        Vector3 newPosition = Vector3.Lerp(start, end, pingPong);

        transform.localPosition = newPosition;

        velocity = (transform.position - lastPosition) / Time.fixedDeltaTime;
        lastPosition = transform.position;
    }

    public Vector3 GetVelocity()
    {
        return velocity;
    }
}