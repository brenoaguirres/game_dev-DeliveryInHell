using UnityEngine;

namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateMachine : MonoBehaviour
    {
        #region FIELDS

        #endregion

        #region PROPERTIES
        public ControllableCharacterState CurrentState
        {
            get { return _currentState; }
            set { _currentState = value;  }
        }
        public ControllableCharacterStateFactory States
        {
            get { return _states; }
            set { _states = value;  }
        }

        public ControllableCharacterData Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public ControllableCharacterDataInput Input
        {
            get { return _dataInput; }
            set { _dataInput = value; }
        }
        #endregion

        #region REFERENCES

        #endregion
        
        #region DATA
        private ControllableCharacterData _data;
        private ControllableCharacterDataInput _dataInput;
        #endregion

        #region STATE MACHINE PATTERN
        [Header("State Pattern")]
        [Tooltip("DEBUG ONLY - Assigning values manually via inspector may result in unaccounted behavior.")]
        [SerializeField] private ControllableCharacterState _currentState;
        private ControllableCharacterStateFactory _states;
        #endregion

        #region DEFAULT METHODS

        private void Awake()
        {
            // setup state
            _states = new ControllableCharacterStateFactory(this);
            _currentState = _states.Ground();
            _currentState.EnterState();
        }

        private void Start()
        {

        }

        private void Update()
        {

        }

        #endregion

        #region CUSTOM METHODS

        #endregion
    }
}
