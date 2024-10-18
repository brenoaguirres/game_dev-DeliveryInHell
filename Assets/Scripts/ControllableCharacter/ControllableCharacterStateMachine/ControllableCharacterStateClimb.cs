using CBPXL.ClimbingSystem;
using CBPXL.ControllableCharacter.ControllableCharacterStateMachine;
using UnityEngine;
using UnityEngine.UIElements;

public class ControllableCharacterStateClimb : ControllableCharacterState
{
    #region FIELDS
    private bool _isClimbing = true;
    private bool _finishedClimbAnimation = true;
    #endregion
    #region CONSTRUCTOR
    public ControllableCharacterStateClimb(ControllableCharacterStateMachine currentContext,
        ControllableCharacterStateFactory stateFactory) : base(currentContext, stateFactory)
    {
    }
    #endregion

    #region STATE METHODS
    public override void EnterState()
    {
        Transform grabPoint = SelectClimbPoint();
        if (grabPoint == null) return;

        Ctx.Data.Animator.SetBool("Hang", true);
        Ctx.Data.Physics.isKinematic = true;
        Ctx.Data.Physics.useGravity = false;
        Ctx.transform.position = grabPoint.position;
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void FixedUpdateState()
    {
        UpdateClimb();
    }

    public override void ExitState()
    {
        Ctx.Data.Physics.isKinematic = false;
    }

    public override void CheckSwitchStates()
    {
        //TODO: fix switch states
        if (!Ctx.Data.WithinClimbRange && Ctx.Data.IsGrounded || _isClimbing && _finishedClimbAnimation)
        {
            Ctx.Data.Physics.isKinematic = false;
            Ctx.Data.Physics.useGravity = true;
            SwitchState(Factory.Idle());
        }
        else if (!Ctx.Data.WithinClimbRange && !Ctx.Data.IsGrounded)
        {
            Ctx.Data.Physics.isKinematic = false;
            Ctx.Data.Physics.useGravity = true;
            SwitchState(Factory.Fall());
        }
    }

    public override void InitializeSubState()
    {
    }
    #endregion

    #region BEHAVIOR METHODS
    public void UpdateClimb()
    {
        if (Ctx.Input.AimInput && _finishedClimbAnimation)
        {
            _finishedClimbAnimation = false;
            Ctx.Data.Animator.SetBool("Hang", false);
            Ctx.Data.Animator.SetBool("Climb", true);
            _isClimbing = false;
        }
        else if (Ctx.Input.ShootInput && _finishedClimbAnimation) //TODO: Change to correct input later on -> circle
        {
            _isClimbing = false;
            Ctx.Data.Animator.SetBool("Hang", false);
        }
    }

    public Transform SelectClimbPoint()
    {
        Vector3 climberPosition = Ctx.Data.Climber.transform.position;

        Collider closestClimbable = null;
        if (Ctx.Data.Climber.Climbables.Count > 1)
        {
            foreach (var climbable in Ctx.Data.Climber.Climbables)
            {
                if (closestClimbable == null)
                    closestClimbable = climbable;
                else if (Vector3.Distance(climberPosition, climbable.transform.position) < Vector3.Distance(climberPosition, closestClimbable.transform.position))
                    closestClimbable = climbable;

            }
        }
        else if (Ctx.Data.Climber.Climbables.Count == 1)
            closestClimbable = Ctx.Data.Climber.Climbables[0];
        else
        {
            Debug.Log("Error finding closest climbable.");
            return null;
        }

        Climbable currentClosest = closestClimbable.GetComponent<Climbable>();
        Transform closestGrabPoint = null;
        if (currentClosest.GrabPoints.Count > 1)
        {
            if (currentClosest != null)
            {
                foreach (var point in currentClosest.GrabPoints)
                {
                    if (closestGrabPoint == null)
                        closestGrabPoint = point;
                    else if (Vector3.Distance(climberPosition, point.transform.position) < Vector3.Distance(climberPosition, closestGrabPoint.transform.position))
                        closestGrabPoint = point;

                }
            }
        }
        else if (currentClosest.GrabPoints.Count == 1)
            closestGrabPoint = currentClosest.GrabPoints[0];

        if (closestGrabPoint != null)
            return closestGrabPoint;
        else
        {
            Debug.Log("Error finding closest grab point.");
            return null;
        }
    }

    public void OnClimbAnimFinish(AnimationClip clip)
    {
        _finishedClimbAnimation = true;
    }
    #endregion
}
