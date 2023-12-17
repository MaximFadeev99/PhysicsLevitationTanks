using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private UserInputHandler _inputHandler;
    [SerializeField] private Rigidbody _vehicle;
    [SerializeField] private float _maxRotation;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _acceleration; 

    private Transform _engineTransform;
    private Vector3 _pushForwardForce;
    private float _currentSpeed = 0f;

    private void Awake() =>
        _engineTransform = transform;

    private void FixedUpdate() =>
        PushForward(_inputHandler.CurrentForwardInput); 

    private void PushForward(float direction) 
    {
        _currentSpeed = Mathf.MoveTowards(_currentSpeed, _maxSpeed * direction, _acceleration);
        _pushForwardForce = _engineTransform.forward * _currentSpeed;
        _vehicle.AddForceAtPosition(_pushForwardForce, _engineTransform.position, ForceMode.Force); 
    }
}