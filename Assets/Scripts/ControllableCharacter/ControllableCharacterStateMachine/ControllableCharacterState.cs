namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public abstract class ControllableCharacterState
    {
        #region FIELDS

        protected ControllableCharacterStateMachine _ctx;
        protected ControllableCharacterStateFactory _factory;

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

        public abstract void CheckSwitchStates();

        public abstract void InitializeSubState();

        #endregion

        #region CONCRETE METHODS

        public void UpdateState()
        {
        }

        protected void SwitchState(ControllableCharacterState newState)
        {
            ExitState();
            newState.EnterState();
            _ctx.CurrentState = newState;
        }

        public void SetSuperState()
        {
        }

        public void SetSubState()
        {
        }

        #endregion
    }
}