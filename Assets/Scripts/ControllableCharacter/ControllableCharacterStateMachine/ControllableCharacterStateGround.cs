namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateGround : ControllableCharacterState
    {
        #region CONSTRUCTOR

        public ControllableCharacterStateGround(ControllableCharacterStateMachine currentContext,
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
            if (_ctx.Input.JumpInput)
            {
                SwitchState(_factory.Jump());
            }
        }

        public override void InitializeSubState()
        {
        }

        #endregion
    }
}
