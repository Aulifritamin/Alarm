using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    private Vector3 _moveDirection;
    private string _horizontalInput = "Horizontal";
    private string _verticalInput = "Vertical";

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
        float moveX = Input.GetAxis(_horizontalInput);
        float moveZ = Input.GetAxis(_verticalInput);

        Vector3 localMove = new Vector3(moveX, 0, moveZ);
        _moveDirection = transform.TransformDirection(localMove);
    }
}
