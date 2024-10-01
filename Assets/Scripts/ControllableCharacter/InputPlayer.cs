using UnityEngine;
using UnityEngine.InputSystem;

// https://www.youtube.com/watch?v=ZSP3bFaZm-o

public class InputPlayer : MonoBehaviour
{
    #region FIELDS
    private PlayerInputActions inputs;
    private float movementHorizontal = 0;
    private float jump = 0;
    private bool run = false;
    #endregion

    #region PROPERTIES
    public float MovementHorizontal { get => movementHorizontal;}
    public float Jump { get => jump;}
    public bool Run { get => run; }
    #endregion

    #region DEFAULT METHODS
    private void Awake()
    {
        inputs = new PlayerInputActions();
    }
    private void OnEnable()
    {
        inputs.Enable();

        // movement input
        inputs.Player.Movement.started += MovementInput;
        inputs.Player.Movement.performed += MovementInput;
        inputs.Player.Movement.canceled += MovementInput;

        // jump input
        inputs.Player.Jump.started += JumpInput;
        inputs.Player.Jump.performed += JumpInput;
        inputs.Player.Jump.canceled += JumpInput;

        // run input
        inputs.Player.Run.started += RunInput;
        inputs.Player.Run.performed += RunInput;
        inputs.Player.Run.canceled += RunInput;
    }

    private void OnDisable()
    {
        inputs.Disable();

        // movement input
        inputs.Player.Movement.started -= MovementInput;
        inputs.Player.Movement.performed -= MovementInput;
        inputs.Player.Movement.canceled -= MovementInput;

        // jump input
        inputs.Player.Jump.started -= JumpInput;
        inputs.Player.Jump.performed -= JumpInput;
        inputs.Player.Jump.canceled -= JumpInput;

        // run input
        inputs.Player.Run.started -= RunInput;
        inputs.Player.Run.performed -= RunInput;
        inputs.Player.Run.canceled -= RunInput;
    }
    #endregion

    #region CUSTOM METHODS
    private void MovementInput(InputAction.CallbackContext context)
    {
        movementHorizontal = context.ReadValue<float>();
        Debug.Log(movementHorizontal);
    }
    private void JumpInput(InputAction.CallbackContext context)
    {
        jump = context.ReadValue<float>();
        Debug.Log(jump);
    }
    private void RunInput(InputAction.CallbackContext context)
    {
        run = context.ReadValueAsButton();
        Debug.Log(run);
    }
    #endregion
}
