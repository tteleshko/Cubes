using UnityEngine;

public class FPSDrop : MonoBehaviour
{
    [SerializeField]private float _distance = 5;
    [SerializeField]private Transform _objectPosition;
    [SerializeField] private Transform _rayOrigin;
    [SerializeField]private bool _isTaken;
    [SerializeField] private float _throwForce = 500;

    private Rigidbody _rb;

    private void Start()
    {
        _rayOrigin = GetComponentInChildren<Camera>().transform;
    }

    public void Push()
    {
        _isTaken = false;
        _rb.isKinematic = false;
        _rb.useGravity = true;
        _rb.AddForce(_rayOrigin.transform.forward * _throwForce);
    }

    public void TakeItem()
    {
        _isTaken = true;
        _rb.isKinematic = true;
        _rb.MovePosition(_objectPosition.position);
    }

    private void Update()
    {       
        RaycastHit hit;
        if (Physics.Raycast(_rayOrigin.position,_rayOrigin.forward, out hit, _distance) && hit.collider.tag == "Cube" )
        {
            _rb = hit.collider.gameObject.GetComponent<Rigidbody>();
            if (Input.GetKeyDown(KeyCode.E) && _isTaken == false)
            {
                TakeItem();
            }
            else if (Input.GetKeyDown(KeyCode.E) && _isTaken == true)
            {
                Push();
            }     
        }
    }

    void FixedUpdate()
    {
        if (_rb !=null)
        {
            if(_rb.isKinematic != false)
            _rb.gameObject.transform.position = _objectPosition.position;
        }
    }

}
