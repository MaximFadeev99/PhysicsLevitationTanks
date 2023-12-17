using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stabilizer : MonoBehaviour
{
    [SerializeField] private float _stabilizationDotThreshold;
    [SerializeField] private float _stabilizingForce;
    [SerializeField] private float _dampingForce;

    private Rigidbody _rigidbody;
    private Transform _transform;
    private Vector3 _localUp;
    private Vector3 _rotationAxis;
    private float _dotResult;
    private float _previousDotResult;
    private float _dotDifference;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _localUp = _transform.up;
        _dotResult = Vector3.Dot(_localUp, Vector3.up);

        if (_dotResult < _stabilizationDotThreshold) 
        {
            StabilizeRotation();
            AddDamping();           
        }
    }

    private void StabilizeRotation() 
    {
        _rotationAxis = Vector3.Cross(_localUp, Vector3.up);
        _rigidbody.AddTorque((1 - _dotResult) * _stabilizingForce * _rotationAxis, ForceMode.Force);
    }

    private void AddDamping()
    {
        _dotDifference = (_previousDotResult - _dotResult) * Time.fixedDeltaTime;

        if (_dotDifference > 0f)
            _rigidbody.AddTorque(_dotDifference * _dampingForce * -_rotationAxis, ForceMode.Force);

        _previousDotResult = _dotResult;
    }
}