using System;
using UnityEngine;

namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    [Serializable]
    public abstract class ControllableCharacterState
    {
        #region FIELDS
        private ControllableCharacterStateMachine _ctx;
        private ControllableCharacterStateFactory _factory;
        protected ControllableCharacterState _currentSubState;
        protected ControllableCharacterState _currentSuperState;

        protected bool _isRootState = false;
        #endregion

        #region PROPERTIES
        public bool IsRootState { get { return _isRootState; } }
        public ControllableCharacterState CurrentSubState { get { return _currentSubState; } }
        public ControllableCharacterState CurrentSuperState { get { return _currentSuperState; } }
        public ControllableCharacterStateMachine Ctx { get { return _ctx; } }
        public ControllableCharacterStateFactory Factory { get { return _factory; } }
        #endregion

        #region CONSTRUCTOR
        public ControllableCharacterState(ControllableCharacterStateMachine currentContext,
            ControllableCharacterStateFactory stateFactory)
        {
            _ctx = currentContext;
            _factory = stateFactory;
        }
        #endregion

        #region ABSTRACT METHODS
        public abstract void EnterState();

        public abstract void ExitState();

        public abstract void UpdateState();

        public abstract void FixedUpdateState();

        public abstract void CheckSwitchStates();

        public abstract void InitializeSubState();
        #endregion

        #region CONCRETE METHODS
        public void UpdateStates()
        {
            UpdateState();
            if (_currentSubState != null)
            {
                _currentSubState.UpdateStates();
            }
        }

        public void FixedUpdateStates()
        {
            FixedUpdateState();
            if (_currentSubState != null)
            {
                _currentSubState.FixedUpdateStates();
            }
        }

        protected void SwitchState(ControllableCharacterState newState)
        {
            ExitState();
            newState.EnterState();

            if (_isRootState)
            {
                _ctx.CurrentState = newState;
            }
            else if (_currentSuperState != null)
            {
                _currentSuperState.SetSubState(newState);
            }
        }

        public void SetSuperState(ControllableCharacterState newSuperState)
        {
            _currentSuperState = newSuperState;
        }

        public void SetSubState(ControllableCharacterState newSubState)
        {
            _currentSubState = newSubState;
            newSubState.SetSuperState(this);
        }
        #endregion
    }
}