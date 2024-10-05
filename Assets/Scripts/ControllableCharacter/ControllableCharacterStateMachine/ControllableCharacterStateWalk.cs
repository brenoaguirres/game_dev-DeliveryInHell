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
