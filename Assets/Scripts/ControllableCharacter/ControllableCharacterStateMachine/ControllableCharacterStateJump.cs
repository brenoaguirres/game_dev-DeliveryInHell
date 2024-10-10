using UnityEngine;

namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateJump : ControllableCharacterState
    {
        #region CONSTRUCTOR
        public ControllableCharacterStateJump(ControllableCharacterStateMachine currentContext,
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
            UpdateJump();
        }

        public override void ExitState()
        {
        }

        public override void CheckSwitchStates()
        {
            if (Ctx.Data.IsGrounded && !Ctx.Input.JumpInput)
            {
                SwitchState(Factory.Ground());
            }
        }

        public override void InitializeSubState()
        {
            //if ((Ctx.Input.HorizontalInput >= 0.05 || Ctx.Input.HorizontalInput <= -0.05))
            //{
            //    SetSubState(Factory.Walk());
            //}
        }
        #endregion

        #region BEHAVIOR METHODS
        public void CheckGrounded()
        {
            Debug.DrawRay(Ctx.Data.JumpBasePosition.position, Vector3.down, Color.magenta, Ctx.Data.MaxGroundCheckDist);
            Debug.Log(Physics.Raycast(Ctx.Data.JumpBasePosition.position, Vector3.down, Ctx.Data.MaxGroundCheckDist, Ctx.Data.GroundLayer));
            Ctx.Data.IsGrounded = Physics.Raycast(Ctx.Data.JumpBasePosition.position, Vector3.down, Ctx.Data.MaxGroundCheckDist, Ctx.Data.GroundLayer);
        }
        public void UpdateJump()
        {
            if (Ctx.Data.IsGrounded)
            {
                Ctx.Data.Physics.linearVelocity.Set(Ctx.Data.Physics.linearVelocity.x, Ctx.Data.MaxJumpForce, 0f);
            }

            if (!Ctx.Data.IsGrounded && !Ctx.Input.JumpInput)
            {
                Ctx.Data.Physics.linearVelocity.Set(Ctx.Data.Physics.linearVelocity.x, 0f, 0f);
            }
        }
        #endregion
    }
}
