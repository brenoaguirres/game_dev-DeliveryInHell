using UnityEngine;
using UnityEngine.InputSystem;

// https://www.youtube.com/watch?v=ZSP3bFaZm-o

namespace CBPXL.ControllableCharacter
{
    public class InputPlayer : MonoBehaviour
    {
        #region FIELDS
        private PlayerInputActions inputs;
        private float movementHorizontal = 0;
        private float movementVertical = 0;
        private float jump = 0;
        private bool run = false;
        private bool aim = false;
        private bool shoot = false;
        #endregion

        #region PROPERTIES
        public float MovementHorizontal { get => movementHorizontal; }
        public float MovementVertical { get => movementVertical; }
        public float Jump { get => jump; }
        public bool Run { get => run; }
        public bool Aim { get => aim; }
        public bool Shoot { get => shoot; }
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

            // look input
            inputs.Player.Look.started += LookInput;
            inputs.Player.Look.performed += LookInput;
            inputs.Player.Look.canceled += LookInput;

            // jump input
            inputs.Player.Jump.started += JumpInput;
            inputs.Player.Jump.performed += JumpInput;
            inputs.Player.Jump.canceled += JumpInput;

            // run input
            inputs.Player.Run.started += RunInput;
            inputs.Player.Run.performed += RunInput;
            inputs.Player.Run.canceled += RunInput;

            // aim input
            inputs.Player.Aim.started += AimInput;
            inputs.Player.Aim.performed += AimInput;
            inputs.Player.Aim.canceled += AimInput;

            // shoot input
            inputs.Player.Shoot.started += ShootInput;
            inputs.Player.Shoot.performed += ShootInput;
            inputs.Player.Shoot.canceled += ShootInput;
        }

        private void OnDisable()
        {
            inputs.Disable();

            // movement input
            inputs.Player.Movement.started -= MovementInput;
            inputs.Player.Movement.performed -= MovementInput;
            inputs.Player.Movement.canceled -= MovementInput;

            // look input
            inputs.Player.Look.started -= LookInput;
            inputs.Player.Look.performed -= LookInput;
            inputs.Player.Look.canceled -= LookInput;

            // jump input
            inputs.Player.Jump.started -= JumpInput;
            inputs.Player.Jump.performed -= JumpInput;
            inputs.Player.Jump.canceled -= JumpInput;

            // run input
            inputs.Player.Run.started -= RunInput;
            inputs.Player.Run.performed -= RunInput;
            inputs.Player.Run.canceled -= RunInput;

            // aim input
            inputs.Player.Aim.started -= AimInput;
            inputs.Player.Aim.performed -= AimInput;
            inputs.Player.Aim.canceled -= AimInput;

            // shoot input
            inputs.Player.Shoot.started -= ShootInput;
            inputs.Player.Shoot.performed -= ShootInput;
            inputs.Player.Shoot.canceled -= ShootInput;
        }
        #endregion

        #region CUSTOM METHODS
        private void MovementInput(InputAction.CallbackContext context)
        {
            movementHorizontal = context.ReadValue<float>();
        }
        private void LookInput(InputAction.CallbackContext context)
        {
            movementVertical = context.ReadValue<float>();
        }
        private void JumpInput(InputAction.CallbackContext context)
        {
            jump = context.ReadValue<float>();
        }
        private void RunInput(InputAction.CallbackContext context)
        {
            run = context.ReadValueAsButton();
        }
        private void AimInput(InputAction.CallbackContext context)
        {
            aim = context.ReadValueAsButton();
        }
        private void ShootInput(InputAction.CallbackContext context)
        {
            shoot = context.ReadValueAsButton();
        }
        #endregion
    }
}
