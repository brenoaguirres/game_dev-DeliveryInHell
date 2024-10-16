using UnityEngine;
using UnityEngine.InputSystem;

// https://www.youtube.com/watch?v=ZSP3bFaZm-o

namespace CBPXL.ControllableCharacter
{
    public class InputPlayer : MonoBehaviour
    {
        #region FIELDS
        private PlayerInput playerInput;
        private PlayerInputActions inputs;

        private float movementHorizontal = 0;
        private float movementVertical = 0;
        private bool jump = false;
        private bool run = false;
        private bool aim = false;
        private bool shoot = false;
        private bool interact = false;
        private float aimPos = 0;
        private bool crouch = false;
        private bool lookUp = false;
        #endregion

        #region PROPERTIES
        public float MovementHorizontal { get => movementHorizontal; }
        public float MovementVertical { get => movementVertical; }
        public bool Jump { get => jump; }
        public bool Run { get => run; }
        public bool Aim { get => aim; }
        public bool Shoot { get => shoot; }
        public bool Interact { get => interact; }
        public float AimPos { get => aimPos; }
        public bool Crouch { get => crouch; }
        public bool LookUp { get => lookUp; }
        #endregion

        #region DEFAULT METHODS
        private void Awake()
        {
            inputs = new PlayerInputActions();

            playerInput = GetComponent<PlayerInput>();
            playerInput.actions = inputs.asset;
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

            // interact input
            inputs.Player.Interact.started += InteractInput;
            inputs.Player.Interact.performed += InteractInput;
            inputs.Player.Interact.canceled += InteractInput;

            // aim position input
            inputs.Player.AimPos.started += AimPosInput;
            inputs.Player.AimPos.performed += AimPosInput;
            inputs.Player.AimPos.canceled += AimPosInput;
            
            // crouch input
            inputs.Player.Crouch.started += CrouchInput;
            inputs.Player.Crouch.performed += CrouchInput;
            inputs.Player.Crouch.canceled += CrouchInput;
            
            // lookup input
            inputs.Player.Look.started += LookUpInput;
            inputs.Player.Look.performed += LookUpInput;
            inputs.Player.Look.canceled += LookUpInput;
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

            // interact input
            inputs.Player.Interact.started -= InteractInput;
            inputs.Player.Interact.performed -= InteractInput;
            inputs.Player.Interact.canceled -= InteractInput;

            // aim position input
            inputs.Player.AimPos.started -= AimPosInput;
            inputs.Player.AimPos.performed -= AimPosInput;
            inputs.Player.AimPos.canceled -= AimPosInput;
            
            // crouch input
            inputs.Player.Crouch.started -= CrouchInput;
            inputs.Player.Crouch.performed -= CrouchInput;
            inputs.Player.Crouch.canceled -= CrouchInput;
            
            // lookup input
            inputs.Player.Look.started -= LookUpInput;
            inputs.Player.Look.performed -= LookUpInput;
            inputs.Player.Look.canceled -= LookUpInput;
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
            jump = context.ReadValueAsButton();
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
        private void InteractInput(InputAction.CallbackContext context)
        {
            interact = context.ReadValueAsButton();
        }
        private void AimPosInput(InputAction.CallbackContext context)
        {
            aimPos = context.ReadValue<float>();
        }
        private void CrouchInput(InputAction.CallbackContext context)
        {
            crouch = context.ReadValueAsButton();
        }
        private void LookUpInput(InputAction.CallbackContext context)
        {
            lookUp = context.ReadValueAsButton();
        }
        #endregion
    }
}
