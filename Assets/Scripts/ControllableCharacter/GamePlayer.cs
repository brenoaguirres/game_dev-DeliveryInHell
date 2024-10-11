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
        [Header("Jump Settings")]
        [SerializeField] private Transform _jumpBasePosition;
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
        private void Awake()
        {
            SetupPlayer();
        }
        private void Update()
        {
            // input and flags
            UpdateInput();

            // logic
            //UpdateAttack(aimInput, shootInput, lookInput);

            // animation
            UpdateAnimation();
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

            // Jump State Setup
            _playerData.JumpBasePosition = _jumpBasePosition;

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
