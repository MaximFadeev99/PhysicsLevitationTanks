using UnityEngine;

public class UserInputHandler : MonoBehaviour
{
    public float CurrentForwardInput { get; private set; }
    public float CurrentSideInput { get; private set; }

    private void Update()
    {
        CurrentForwardInput = Input.GetAxis("Vertical");
        CurrentSideInput = Input.GetAxis("Horizontal");
    }
}