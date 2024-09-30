using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayer : MonoBehaviour
{
    PlayerInputActions inputs;
    Vector2 movementInput;
    float vertical = 0;
    float horizontal = 0;

    void Start()
    {
        inputs.Player.Movement.started += UpdateMovement;
        inputs.Player.Movement.performed += UpdateMovement;
        inputs.Player.Movement.canceled += UpdateMovement;
    }

    
    void Update()
    {
        Debug.Log(vertical + " " + horizontal);
    }

    void UpdateMovement(InputAction.CallbackContext context)
    {
        Debug.Log("boom");
        movementInput = context.ReadValue<Vector2>();
        vertical = movementInput.y;
        horizontal = movementInput.x;
    }
}
