using UnityEngine;

namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateIdle : ControllableCharacterState
    {
        #region CONSTRUCTOR

        public ControllableCharacterStateIdle(ControllableCharacterStateMachine currentContext,
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
            if ((Ctx.Input.HorizontalInput >= 0.05 || Ctx.Input.HorizontalInput <= -0.05) && !Ctx.Input.RunInput)
            {
                SetSubState(Factory.Walk());
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