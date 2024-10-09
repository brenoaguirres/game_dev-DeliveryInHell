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
        #endregion

        #region PROPERTIES
        #endregion

        #region REFERENCES
        [Space(2)]
        [Header("Input")]
        private InputPlayer _input;

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
            //UpdateAttack(aimInput, shootInput, lookInput);

            // animation
            UpdateAnimation();
        }
        private void FixedUpdate()
        {
            UpdateJump();
        }
        #endregion

        #region CLASS METHODS
        private void SetupPlayer()
        {
            // StateMachine Setup
            _stateMachine = gameObject.AddComponent<CBPXLStateMachine.ControllableCharacterStateMachine>();

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

            // References Setup
            _input = GetComponent<InputPlayer>();

            // Data References Setup
            _playerData.Physics = GetComponent<Rigidbody>();
            _playerData.Animator = GetComponentInChildren<Animator>();
            _playerData.Attack = GetComponentInChildren<AttackPlayer>();

            // State Initialization
            _stateMachine.Initialize();
        }
        private void UpdateInput()
        {
            _inputData.HorizontalInput = _input.MovementHorizontal;
            _inputData.VerticalInput = _input.MovementVertical;
            _inputData.JumpInput = _input.Jump;
            _inputData.RunInput = _input.Run;
            _inputData.AimInput = _input.Aim;
            _inputData.ShootInput = _input.Shoot;
        }
        private void UpdateFlags()
        {

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
            //attack.UpdateAttack(aim, shoot, look);
        }
        private void UpdateAnimation()
        {
            // movement
            //animator.SetFloat("moveSpeed", Mathf.Abs(walkInput));
            //animator.SetBool("isRunning", runInput);
        }
        #endregion
    }
}
