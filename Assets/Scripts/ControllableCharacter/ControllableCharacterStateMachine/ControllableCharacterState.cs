namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public abstract class ControllableCharacterState
    {
        #region FIELDS
        protected ControllableCharacterStateMachine _ctx;
        protected ControllableCharacterStateFactory _factory;
        protected ControllableCharacterState _currentSubState;
        protected ControllableCharacterState _currentSuperState;
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

        public abstract void CheckSwitchStates();

        public abstract void InitializeSubState();
        #endregion

        #region CONCRETE METHODS
        public void UpdateStates()
        {
        }

        protected void SwitchState(ControllableCharacterState newState)
        {
            ExitState();
            newState.EnterState();
            _ctx.CurrentState = newState;
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