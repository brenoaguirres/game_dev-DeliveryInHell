using UnityEngine;

namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateFallWalk : ControllableCharacterState
    {
        #region CONSTRUCTOR

        public ControllableCharacterStateFallWalk(ControllableCharacterStateMachine currentContext,
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
            //UpdateFallWalk(Ctx.Data.CrouchSpeed);
        }

        public override void ExitState()
        {
        }

        public override void CheckSwitchStates()
        {
            //TODO logic
        }

        public override void InitializeSubState()
        {

        }

        #endregion

        #region BEHAVIOR METHODS

        private void UpdateFallWalk(float speed)
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
