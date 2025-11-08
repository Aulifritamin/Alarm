using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    private Vector3 _moveDirection;
    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";

    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Vector3 newVelocity = new Vector3(
            _moveDirection.x * _speed,
            _rigidBody.velocity.y,
            _moveDirection.z * _speed);
        _rigidBody.velocity = newVelocity;
    }

    private void Move()
    {
        float moveX = Input.GetAxis(HorizontalInput);
        float moveZ = Input.GetAxis(VerticalInput);

        Vector3 localMove = new Vector3(moveX, 0, moveZ);
        _moveDirection = transform.TransformDirection(localMove);
    }
}
