namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateGround : ControllableCharacterState
    {
        #region CONSTRUCTOR
        public ControllableCharacterStateGround(ControllableCharacterStateMachine currentContext,
            ControllableCharacterStateFactory stateFactory) : base(currentContext, stateFactory)
        {
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

        public override void ExitState()
        {
        }

        public override void CheckSwitchStates()
        {
            if (_ctx.Input.JumpInput)
            {
                SwitchState(_factory.Jump());
            }
        }

        public override void InitializeSubState()
        {
            if (!_ctx.Input.HorizontalInput && !_ctx.Input.RunInput)
            {
                SetSubState(_factory.Idle());
            }
            else if (_ctx.Input.HorizontalInput && !_ctx.Input.RunInput)
            {
                SetSubState(_factory.Walk());
            }
            else
            {
                SetSubState(_factory.Run());
            }
        }
        #endregion
    }
}
