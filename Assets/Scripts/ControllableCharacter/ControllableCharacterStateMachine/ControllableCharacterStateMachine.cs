using UnityEngine;

namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateMachine : MonoBehaviour
    {
        #region FIELDS
        private bool _initialized = false;
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

        #region STATE PATTERN
        [Header("State Pattern")]
        private ControllableCharacterState _currentState;
        private ControllableCharacterStateFactory _states;
        #endregion

        #region DEFAULT METHODS

        private void Update()
        {
            if (!_initialized) return;

            _currentState.UpdateStates();
        }

        private void FixedUpdate()
        {
            if (!_initialized) return;

            _currentState.FixedUpdateStates();
        }

        #endregion

        #region CUSTOM METHODS
        public void Initialize()
        {
            // setup state
            _states = new ControllableCharacterStateFactory(this);
            _currentState = _states.Ground();
            _currentState.EnterState();

            _initialized = true;
        }
        #endregion
    }
}
