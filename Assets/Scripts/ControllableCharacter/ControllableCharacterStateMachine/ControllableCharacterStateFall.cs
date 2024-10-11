using UnityEngine;

namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateFall : ControllableCharacterState
    {
        #region CONSTRUCTOR

        public ControllableCharacterStateFall(ControllableCharacterStateMachine currentContext,
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
            CheckGrounded();
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
            if ((Ctx.Input.HorizontalInput >= 0.05 || Ctx.Input.HorizontalInput <= -0.05))
            {
                SetSubState(Factory.Walk());
            }
        }

        #endregion
        
        #region BEHAVIOR METHODS
        public void CheckGrounded()
        {
            Ctx.Data.IsGrounded = Physics.Raycast(Ctx.Data.JumpBasePosition.position, -Ctx.Data.JumpBasePosition.up, Ctx.Data.MaxGroundCheckDist, Ctx.Data.GroundLayer);
        }
        #endregion
    }
}