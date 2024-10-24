using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
using CBPXLStateMachine = CBPXL.ControllableCharacter.ControllableCharacterStateMachine;
using Interact = CBPXL.InteractSystem;
using System;
using UnityEditor;
using CBPXL.ClimbingSystem;

namespace CBPXL.ControllableCharacter
{
    public class GamePlayer : MonoBehaviour
    {
        #region FIELDS
        [Header("Debug Mode")] 
        [SerializeField] private bool _debugMode = false;
        
        [Space(2)]
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
            UpdateInput();

            if (_debugMode)
            {
                GetCurrentState(_stateMachine.CurrentState);
            }
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
                catch (Exception)
                {
                    _playerData = new ControllableCharacterData();
                    //AssetDatabase.CreateAsset(_playerData, "Assets/Resources/" + _dataAssetPath);
                    //AssetDatabase.SaveAssets();
                }
            }
            if (_inputData == null)
            {
                try
                {
                    _inputData = Resources.Load(_inputAssetPath) as ControllableCharacterDataInput;
                }
                catch (Exception)
                {
                    _inputData = new ControllableCharacterDataInput();
                    //AssetDatabase.CreateAsset(_inputData, "Assets/Resources/" + _inputAssetPath);
                    //AssetDatabase.SaveAssets();
                }
            }

            _stateMachine.Data = _playerData;
            _stateMachine.Input = _inputData;

            // References Setup
            _input = GetComponent<InputPlayer>();

            // Data References Setup
            _playerData.Physics = GetComponent<Rigidbody>();
            _playerData.Animator = GetComponentInChildren<Animator>();
            _playerData.AnimatorEvents = GetComponentInChildren<AnimatorEvents>();
            _playerData.Interactor = GetComponentInChildren<Interact.Interactor>();
            _playerData.Inspector = GetComponentInChildren<InspectionSystem.Inspector>();
            _playerData.Climber = GetComponentInChildren<Climber>();

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
            _inputData.InteractInput = _input.Interact;
            _inputData.AimPosInput = _input.AimPos;
            _inputData.CrouchInput = _input.Crouch;
            _inputData.LookUpInput = _input.LookUp;
        }
        #endregion

        #region DEBUG METHODS
        private void GetCurrentState(CBPXLStateMachine.ControllableCharacterState state)
        {
            if (state.CurrentSubState == null)
            {
                Debug.Log(state.GetType().Name);
            }
            else
            {
                GetCurrentState(state.CurrentSubState);
            }
        }
        #endregion
    }
}
