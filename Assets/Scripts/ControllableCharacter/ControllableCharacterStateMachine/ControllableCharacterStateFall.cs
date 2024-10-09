namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateFall : ControllableCharacterState
    {
        #region CONSTRUCTOR

        public ControllableCharacterStateFall(ControllableCharacterStateMachine currentContext,
            ControllableCharacterStateFactory stateFactory) : base(currentContext, stateFactory)
        {
            _isRootState = true;
            InitializeSubState();
        }

        #endregion

        #region STATE METHODS

        public override void EnterState()
        {
        }

        public override void UpdateState()
        {

        }

        public override void FixedUpdateState()
        {
        }

        public override void ExitState()
        {
        }

        public override void CheckSwitchStates()
        {

        }

        public override void InitializeSubState()
        {

        }

        #endregion
    }
}