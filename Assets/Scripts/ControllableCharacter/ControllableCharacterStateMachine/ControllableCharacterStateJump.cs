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
            Ctx.Data.Animator.SetBool("Jump", true);
            Ctx.Data.Climber.onTouchClimbable += CheckClimbing;
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
            Ctx.Data.Animator.SetBool("Jump", false);
            Ctx.Data.Climber.onTouchClimbable -= CheckClimbing;
        }

        public override void CheckSwitchStates()
        {
            // FIX: very slow return due to lack of fall state (this methods remains being called after state change
            if (Ctx.Data.WithinClimbRange && Ctx.Input.JumpInput && !Ctx.Data.IsGrounded)
            {
                SwitchState(Factory.Climb());
            }
            else if (Ctx.Data.Physics.linearVelocity.y <= 0.1f && !Ctx.Input.JumpInput)
            {
                SwitchState(Factory.Fall());
            }
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
        public void CheckClimbing(bool climbing)
        {
            Ctx.Data.WithinClimbRange = climbing;
        }
        public void UpdateJump()
        {
            if (Ctx.Data.IsGrounded)
            {
                Ctx.Data.Physics.linearVelocity = new Vector3(Ctx.Data.Physics.linearVelocity.x, Ctx.Data.MaxJumpForce, 0f);
            }

            if (!Ctx.Data.IsGrounded && !Ctx.Input.JumpInput)
            {
                Ctx.Data.Physics.linearVelocity = new Vector3(Ctx.Data.Physics.linearVelocity.x, 0f, 0f);
            }
        }
        #endregion
    }
}
