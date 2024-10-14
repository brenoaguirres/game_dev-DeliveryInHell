using UnityEngine;

namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateGround : ControllableCharacterState
    {
        #region CONSTRUCTOR
        public ControllableCharacterStateGround(ControllableCharacterStateMachine currentContext,
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
            if (Ctx.Input.JumpInput)
            {
                SwitchState(Factory.Jump());
            }
        }

        public override void InitializeSubState()
        {
            if (Ctx.Input.InteractInput)
            {
                SetSubState(Factory.Interact());
            }
            else if (Ctx.Input.AimInput)
            {
                SetSubState(Factory.Aim());
            }
            else if (!(Ctx.Input.HorizontalInput >= 0.05 || Ctx.Input.HorizontalInput <= -0.05) && !Ctx.Input.RunInput)
            {
                SetSubState(Factory.Idle());
            }
            else if ((Ctx.Input.HorizontalInput >= 0.05 || Ctx.Input.HorizontalInput <= -0.05) && !Ctx.Input.RunInput)
            {
                SetSubState(Factory.Walk());
            }
            else if ((Ctx.Input.HorizontalInput >= 0.05 || Ctx.Input.HorizontalInput <= -0.05) && Ctx.Input.RunInput)
            {
                SetSubState(Factory.Run());
            }
        }
        #endregion
    }
}
