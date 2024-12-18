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
            Ctx.Data.Animator.SetBool("Fall", true);
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
            Ctx.Data.Animator.SetBool("Fall", false);
        }

        public override void CheckSwitchStates()
        {
            if (Ctx.Data.IsGrounded)
            {
                SwitchState(Factory.Ground());
            }
            // TODO: add switch from fall to climb
        }

        public override void InitializeSubState()
        {
            if ((Ctx.Input.HorizontalInput >= 0.05 || Ctx.Input.HorizontalInput <= -0.05))
            {
                SetSubState(Factory.AirborneWalk());
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