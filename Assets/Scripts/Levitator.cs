using UnityEngine;

public class Levitator : MonoBehaviour
{
    [SerializeField] private Rigidbody _vehicle;
    [SerializeField] private LayerMask _contactMask;
    [SerializeField] private float _maxLevitationDistance;
    [SerializeField] private float _maxForce;

    private Transform _engineTransform;
    private float _appliedForce;

    private void Awake() =>
        _engineTransform = transform;

    private void FixedUpdate()
    {
        if (Physics.Raycast(_engineTransform.position, -Vector3.up, out RaycastHit hitInfo, _maxLevitationDistance, 
            _contactMask, QueryTriggerInteraction.Ignore))
        {
            _appliedForce = _maxForce - hitInfo.distance.Remap(0, _maxLevitationDistance, 0, _maxForce);
            _vehicle.AddForceAtPosition(Vector3.up * _appliedForce, _engineTransform.position, ForceMode.Force);
        }
    }
}