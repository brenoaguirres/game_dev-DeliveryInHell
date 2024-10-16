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
            if (Ctx.Input.InteractInput)
            {
                SwitchState(Factory.Interact());
            }
            else if (Ctx.Input.AimInput)
            {
                SwitchState(Factory.Aim());
            }
            else if ((Ctx.Input.HorizontalInput >= 0.05 || Ctx.Input.HorizontalInput <= -0.05) && !Ctx.Input.RunInput)
            {
                SwitchState(Factory.Walk());
            }
            else if ((Ctx.Input.HorizontalInput >= 0.05 || Ctx.Input.HorizontalInput <= -0.05) && Ctx.Input.RunInput)
            {
                SwitchState(Factory.Run());
            }
            else if (Ctx.Input.CrouchInput)
            {
                SwitchState(Factory.Crouch());
            }
            else if (Ctx.Input.LookUpInput)
            {
                SwitchState(Factory.LookUp());
            }
        }

        public override void InitializeSubState()
        {
        }

        #endregion
    }
}