using UnityEngine;

public class FPSInput : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _mouseSensivity = 2;

    private Transform _cameraTransformPosition;
    private Rigidbody _rb;

    private void Start()
    {
        SetUpCamera();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerMovement();
        CameraRotation();
    }

    private void SetUpCamera()
    {
        _cameraTransformPosition = GetComponentInChildren<Camera>().transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }
    
    private void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movementForward = _cameraTransformPosition.forward;
        movementForward.y = 0;
        Vector3 movementRight = _cameraTransformPosition.right;
        movementRight.y = 0;

        Vector3 movement = movementForward.normalized * vertical + movementRight.normalized * horizontal;
        movement = new Vector3(movement.x, _rb.velocity.y, movement.z);

        _rb.velocity = Vector3.ClampMagnitude(movement, 1) * _speed;
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float newAngleX = _cameraTransformPosition.rotation.eulerAngles.x - mouseY * _mouseSensivity;

        if (newAngleX > 180)
        {
            newAngleX = newAngleX - 360;
        }

        newAngleX = Mathf.Clamp(newAngleX, -80, 80);
        _cameraTransformPosition.rotation = Quaternion.Euler(_cameraTransformPosition.rotation.eulerAngles.x - mouseY * _mouseSensivity, _cameraTransformPosition.rotation.eulerAngles.y, _cameraTransformPosition.rotation.eulerAngles.z);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseX * _mouseSensivity, transform.rotation.eulerAngles.z);
    }
}
