namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateJump : ControllableCharacterState
    {
        #region FIELDS
        private bool _isGrounded;
        #endregion
        
        #region CONSTRUCTOR
        public ControllableCharacterStateJump(ControllableCharacterStateMachine currentContext,
            ControllableCharacterStateFactory stateFactory) : base(currentContext, stateFactory)
        {
        }
        #endregion

        #region STATE METHODS
        public override void EnterState()
        {
        }

        public override void ExitState()
        {
        }

        public override void CheckSwitchStates()
        {
            if (_isGrounded)
            {
                SwitchState(_factory.Ground());
            }
        }

        public override void InitializeSubState()
        {
        }
        #endregion
    }
}
