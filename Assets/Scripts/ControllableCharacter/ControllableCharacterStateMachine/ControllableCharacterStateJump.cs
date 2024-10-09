namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateJump : ControllableCharacterState
    {
        #region CONSTRUCTOR
        public ControllableCharacterStateJump(ControllableCharacterStateMachine currentContext,
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
            CheckSwitchStates();
        }

        public override void FixedUpdateState()
        {
        }

        public override void ExitState()
        {
        }

        public override void CheckSwitchStates()
        {
            if (Ctx.Data.IsGrounded)
            {
                SwitchState(Factory.Ground());
            }
        }

        public override void InitializeSubState()
        {
        }
        #endregion
    }
}
