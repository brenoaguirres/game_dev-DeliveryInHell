using UnityEngine;

namespace CBPXL.ControllableCharacter
{
    public class GamePlayer : MonoBehaviour
    {
        #region FIELDS
        [Header("Movement")]
        [SerializeField] private float walkSpeed = 5f;
        [SerializeField] private float runSpeed = 10f;
        private bool isRunning = false;
        [Tooltip("How many seconds does the move input should take to lerp to 0 after key up?")]
        [SerializeField] private float skidTime = 0;

        [Space(2)]
        [Header("Jump")]
        [SerializeField] private float maxJumpForce = 5f;
        [Tooltip("How many seconds does the jump input should take to lerp to max after key down?")]
        [SerializeField] private float maxJumpTime = 1f;
        private float currentJumpForce = 0f;
        private bool canJump = false;
        private bool isGrounded = true;
        [SerializeField] private LayerMask groundLayer;

        [Space(2)]
        [Header("Crouch")]

        [Space(2)]
        [Header("Attack")]

        [Space(2)]
        [Header("Input")]
        private float walkInput = 0;
        private bool runInput = false;
        [Range(0, 1)] private float jumpInput = 0;
        private bool crouchInput = false;
        private bool attackInput = false;

        #endregion

        #region PROPERTIES
        #endregion

        #region REFERENCES
        private InputPlayer input;
        #endregion

        #region STATE MACHINE
        private enum MovePhases
        {
            IDLE,
            MOVING_LEFT,
            MOVING_RIGHT,
            RUNNING_LEFT,
            RUNNING_RIGHT,
            SKIDDING,
        }
        private enum JumpPhases
        {
            GROUND,
            IMPULSE,
            MAX_HEIGHT,
            FALLING,
        }
        #endregion

        #region EVENTS
        #endregion

        #region DEFAULT METHODS
        private void Start()
        {
            SetupPlayer();
        }
        private void Update()
        {
            // input and flags
            UpdateInput();
            UpdateFlags();
        }
        private void FixedUpdate()
        {
            // physics updates
            UpdateMovement();
            UpdateJump();
        }
        #endregion

        #region CLASS METHODS
        private void SetupPlayer()
        {
            input = GetComponent<InputPlayer>();
        }
        private void UpdateInput()
        {
            walkInput = input.MovementHorizontal;
            jumpInput = input.Jump;
            runInput = input.Run;
        }
        private void UpdateFlags()
        {

        }
        private void UpdateMovement()
        {

        }
        private void UpdateJump()
        {

        }
        #endregion
    }
}
