using UnityEngine;

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

        public override void FixedUpdateState()
        {
            UpdateMovement(Ctx.Data.WalkSpeed);
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

        #region BEHAVIOR METHODS
        public void UpdateMovement(float speed)
        {
            float currentSpeed = speed;
            Vector3 moveDirection = Vector3.right * Ctx.Input.HorizontalInput;
            Vector3 newPosition = Ctx.transform.position + moveDirection * currentSpeed * Time.fixedDeltaTime;

            // apply pos && rot
            Ctx.Data.Physics.MovePosition(newPosition);

            if (Ctx.Input.HorizontalInput > 0.1f)
            {
                Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                Ctx.Data.Physics.MoveRotation(targetRotation);
            }
            else if (Ctx.Input.HorizontalInput < -0.1f)
            {
                Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                Ctx.Data.Physics.MoveRotation(targetRotation);
            }
        }
        #endregion
    }
}