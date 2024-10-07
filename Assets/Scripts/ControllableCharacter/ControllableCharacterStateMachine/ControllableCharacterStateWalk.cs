namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateWalk : ControllableCharacterState
    {
        #region CONSTRUCTOR

        public ControllableCharacterStateWalk(ControllableCharacterStateMachine currentContext,
            ControllableCharacterStateFactory stateFactory) : base(currentContext, stateFactory)
        {
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
            if (!_ctx.Input.HorizontalInput)
            {
                SetSubState(_factory.Idle());
            }
            else if (_ctx.Input.HorizontalInput && _ctx.Input.RunInput)
            {
                SetSubState(_factory.Run());
            }
        }

        public override void InitializeSubState()
        {
        }

        #endregion
    }
}
