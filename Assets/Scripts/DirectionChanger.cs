using UnityEngine;

public class DirectionChanger : MonoBehaviour
{
    [SerializeField] private UserInputHandler _inputHandler;
    [SerializeField] private Rigidbody _vehicle;
    [SerializeField] private float _rotationSpeed;

    private Transform _engineTransform;
    private Vector3 _currentTorque;

    private void Awake() =>
        _engineTransform = transform;

    private void FixedUpdate()
    {
        if (_inputHandler.CurrentSideInput != 0) 
            ChangeDirection(_inputHandler.CurrentSideInput);
    }

    private void ChangeDirection(float direction) 
    {
        _currentTorque = _engineTransform.right * -direction * _rotationSpeed;
        _vehicle.AddForceAtPosition(_currentTorque, _engineTransform.position, ForceMode.Force); 
    }
}