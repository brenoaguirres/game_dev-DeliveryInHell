using CBPXL.ControllableCharacter.ControllableCharacterStateMachine;
using UnityEngine;

public class ControllableCharacterStateCrouchWalk : ControllableCharacterState
{
    #region CONSTRUCTOR
    public ControllableCharacterStateCrouchWalk(ControllableCharacterStateMachine currentContext,
        ControllableCharacterStateFactory stateFactory) : base(currentContext, stateFactory)
    {
    }
    #endregion
    
    #region STATE METHODS
    public override void EnterState()
    {
        Ctx.Data.Animator.SetBool("Crouch", true);
        //Ctx.Data.Animator.SetBool("CrouchWalk", true);
    }
        
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void FixedUpdateState()
    {
        UpdateCrouchWalk(Ctx.Data.CrouchSpeed);
    }

    public override void ExitState()
    {
        Ctx.Data.Animator.SetBool("Crouch", false);
        //Ctx.Data.Animator.SetBool("CrouchWalk", false);
    }
    public override void CheckSwitchStates()
    {
        if (!Ctx.Input.CrouchInput)
        {
            SwitchState(Factory.Ground());
        }
        else if (!(Ctx.Input.HorizontalInput > 0.05f || Ctx.Input.HorizontalInput < -0.05f) && Ctx.Input.CrouchInput)
        {
            SwitchState(Factory.Crouch());
        }
    }
    public override void InitializeSubState()
    {
        
    }
    #endregion
    
    #region BEHAVIOR METHODS
    private void UpdateCrouchWalk(float speed)
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
