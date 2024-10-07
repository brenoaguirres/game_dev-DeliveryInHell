using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
using CBPXLStateMachine = CBPXL.ControllableCharacter.ControllableCharacterStateMachine;
using System;
using UnityEditor;

namespace CBPXL.ControllableCharacter
{
    public class GamePlayer : MonoBehaviour
    {
        #region FIELDS
        [Header("Settings")]
        [SerializeField] private ControllableCharacterData _playerData;
        [SerializeField] private ControllableCharacterDataInput _inputData;
        [SerializeField] private string _dataAssetPath = "ControllableCharacterData/Data";
        [SerializeField] private string _inputAssetPath = "ControllableCharacterData/InputData";

        [Space(2)]
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
        [SerializeField] private float maxGroundCheckDist = 1f;
        [Tooltip("The position in which the character's feet is located.")]
        [SerializeField] private Transform basePosition;

        [Space(2)]
        [Header("Crouch")]

        [Space(2)]
        [Header("Attack")]

        [Space(2)]
        [Header("Input")]
        private float walkInput = 0;
        private float lookInput = 0;
        private bool runInput = false;
        [Range(0, 1)] private float jumpInput = 0;
        private bool crouchInput = false;
        private bool attackInput = false;
        private bool aimInput = false;
        private bool shootInput = false;

        #endregion

        #region PROPERTIES
        #endregion

        #region REFERENCES
        private Rigidbody physics;
        private Animator animator;

        private AttackPlayer attack;
        private InputPlayer input;

        [Header("State")]
        private CBPXLStateMachine.ControllableCharacterStateMachine _stateMachine;
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

            // logic
            UpdateAttack(aimInput, shootInput, lookInput);

            // animation
            UpdateAnimation();
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
            // References Setup
            physics = GetComponent<Rigidbody>();
            animator = GetComponentInChildren<Animator>();

            input = GetComponent<InputPlayer>();
            attack = GetComponentInChildren<AttackPlayer>();

            // StateMachine Setup
            _stateMachine = GetComponent<CBPXLStateMachine.ControllableCharacterStateMachine>();

            // Data Setup
            if (_playerData == null)
            {
                try
                {
                    _playerData = Resources.Load(_dataAssetPath) as ControllableCharacterData;
                }
                catch (Exception e)
                {
                    _playerData = new ControllableCharacterData();
                    AssetDatabase.CreateAsset(_playerData, "Resources/" + _dataAssetPath);
                    AssetDatabase.SaveAssets();
                }
            }
            if (_inputData == null)
            {
                try
                {
                    _inputData = Resources.Load(_inputAssetPath) as ControllableCharacterDataInput;
                }
                catch (Exception e)
                {
                    _inputData = new ControllableCharacterDataInput();
                    AssetDatabase.CreateAsset(_inputData, "Resources/" + _inputAssetPath);
                    AssetDatabase.SaveAssets();
                }
            }

            _stateMachine.Data = _playerData;
            _stateMachine.Input = _inputData;
        }
        private void UpdateInput()
        {
            _inputData.HorizontalInput = input.MovementHorizontal;
            _inputData.VerticalInput = input.MovementVertical;
            _inputData.JumpInput = input.Jump;
            _inputData.RunInput = input.Run;
            _inputData.AimInput = input.Aim;
            _inputData.ShootInput = input.Shoot;
        }
        private void UpdateFlags()
        {

        }
        private void UpdateMovement()
        {
            // checking direction && if its running
            float currentSpeed = isRunning ? runSpeed : walkSpeed;
            Vector3 moveDirection = Vector3.right * walkInput;
            Vector3 newPosition = transform.position + moveDirection * currentSpeed * Time.fixedDeltaTime;

            // apply pos && rot
            physics.MovePosition(newPosition);

            if (walkInput > 0.1f)
            {
                Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                physics.MoveRotation(targetRotation);
            }
            else if (walkInput < -0.1f)
            {
                Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                physics.MoveRotation(targetRotation);
            }
        }
        private void UpdateJump()
        {
            //// checking jump conditions
            //RaycastHit hit;
            //canJump = false;
            //isGrounded = false;
            //if (Physics.Raycast(basePosition.position, -basePosition.up, out hit, maxGroundCheckDist, groundLayer))
            //{
            //    jumpPhases = JumpPhases.GROUND;
            //    isGrounded = true;
            //}
            //if (isGrounded && jumpInput > 0.1f)
            //    canJump = true;
            //Debug.DrawRay(basePosition.position, -basePosition.up, Color.magenta, maxGroundCheckDist);

            //// jump start
            //if (canJump)
            //{
            //    jumpPhases = JumpPhases.IMPULSE;
            //}

            //// jump mid-air
            //if (jumpPhases == JumpPhases.IMPULSE && jumpInput >= 0.1f)
            //{
            //    currentJumpForce = Mathf.Lerp(currentJumpForce, maxJumpForce, maxJumpTime);
            //    physics.AddForce(Vector3.up * currentJumpForce, ForceMode.VelocityChange);
            //}

            //// jump max-height reached
            //if (currentJumpForce >= maxJumpForce)
            //{
            //    jumpPhases = JumpPhases.MAX_HEIGHT;
            //}

            //// jump inertia
            //if(jumpPhases == JumpPhases.MAX_HEIGHT)
            //{
            //    currentJumpForce = Mathf.Lerp(currentJumpForce, 0, maxJumpTime);
            //    physics.AddForce(Vector3.up * currentJumpForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
            //}

            //// jump inertia over
            //if (currentJumpForce <= 0 && !isGrounded)
            //{
            //    jumpPhases = JumpPhases.FALLING;
            //    //physics.linearVelocity = new Vector3(physics.linearVelocity.x, 0, physics.linearVelocity.z);
            //}

            //// jump fall
            //if (jumpPhases != JumpPhases.FALLING)
            //{
                
            //}
        }
        private void UpdateAttack(bool aim, bool shoot, float look)
        {
            attack.UpdateAttack(aim, shoot, look);
        }
        private void UpdateAnimation()
        {
            // movement
            animator.SetFloat("moveSpeed", Mathf.Abs(walkInput));
            animator.SetBool("isRunning", runInput);
        }
        #endregion
    }
}
