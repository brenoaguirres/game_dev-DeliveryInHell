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
            if (!(Ctx.Input.HorizontalInput >= 0.05 || Ctx.Input.HorizontalInput <= -0.05))
            {
                SetSubState(Factory.Idle());
            }
            else if ((Ctx.Input.HorizontalInput >= 0.05 || Ctx.Input.HorizontalInput <= -0.05) && Ctx.Input.RunInput)
            {
                SetSubState(Factory.Run());
            }
        }

        public override void InitializeSubState()
        {
        }

        #endregion
    }
}
