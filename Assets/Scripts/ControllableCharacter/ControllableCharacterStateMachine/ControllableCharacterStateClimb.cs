using CBPXL.ClimbingSystem;
using CBPXL.ControllableCharacter.ControllableCharacterStateMachine;
using UnityEngine;
using System.Collections.Generic;

public class ControllableCharacterStateClimb : ControllableCharacterState
{
    #region FIELDS
    private bool _finishedClimbAnimation = false;
    private bool _isHanging = true;
    private Transform _grabPoint;
    private Transform _landingPoint;
    private Climbable _closestClimbable;
    
    // position update
    private float _lerpSpeed = 0.1f;
    private float _lerpTime = 0f;
    private Vector3 _startingPos;
    #endregion
    #region CONSTRUCTOR
    public ControllableCharacterStateClimb(ControllableCharacterStateMachine currentContext,
        ControllableCharacterStateFactory stateFactory) : base(currentContext, stateFactory)
    {
        _isRootState = true;
        InitializeSubState();
    }
    #endregion

    #region STATE METHODS
    public override void EnterState()
    {
        Ctx.Data.AnimatorEvents.onAnimationClipEnded += OnClimbAnimFinish;
        
        _grabPoint = SelectClimbPoint();
        if (_grabPoint == null) OnNoGrabPointFound();
        if (_grabPoint != null)
            _landingPoint = SelectLandingPoint(_grabPoint);

        Ctx.Data.Animator.SetBool("Hang", true);
        
        _startingPos = Ctx.Data.Climber.ClimberPosition.position;
        LockPhysics();
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
        UpdateClimb();
    }

    public override void FixedUpdateState()
    {
        
    }

    public override void ExitState()
    {
        Ctx.Data.AnimatorEvents.onAnimationClipEnded -= OnClimbAnimFinish;
        //Ctx.Data.Physics.isKinematic = false;
    }

    public override void CheckSwitchStates()
    {
        //TODO: fix switch states
        if ((!Ctx.Data.WithinClimbRange && Ctx.Data.IsGrounded || _finishedClimbAnimation) && !_isHanging)
        {
            UnlockPhysics();
            SwitchState(Factory.Ground());
        }
        else if (!Ctx.Data.WithinClimbRange && !Ctx.Data.IsGrounded && !_isHanging)
        {
            UnlockPhysics();
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
        if (!_isHanging && !_finishedClimbAnimation)
            UpdateClimbPos();
        
        if (Ctx.Input.AimInput && !_finishedClimbAnimation)
        {
            _isHanging = false;
            Ctx.Data.Animator.SetBool("Hang", false);
            Ctx.Data.Animator.SetBool("Climb", true);
        }
        else if (Ctx.Input.ShootInput && !_finishedClimbAnimation) //TODO: Change to correct input later on -> circle
        {
            _isHanging = false;
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
        _closestClimbable = currentClosest;
        
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

    public Transform SelectLandingPoint(Transform grabPoint)
    {
        int index = _closestClimbable.GrabPoints.IndexOf(grabPoint);
        return _closestClimbable.UpperPoints[index];
    }
    
    public void OnClimbAnimFinish(AnimationClip clip)
    {
        //TODO: Improve this by removing these literals
        string[] animNames = { "Climb" };

        foreach (string animName in animNames) {
            if (clip.name == animName)
            {
                _finishedClimbAnimation = true;
            }
        }
    }

    public void UpdateClimbPos()
    {
        _lerpTime += Time.deltaTime * _lerpSpeed;
        _lerpTime = Mathf.Clamp01(_lerpTime);
        
        Ctx.Data.Climber.ClimberPosition.position = 
            Vector3.Lerp(_startingPos, _landingPoint.position, _lerpTime);
    }

    public void LockPhysics()
    {
        Ctx.Data.Physics.isKinematic = true;
        Ctx.Data.Physics.useGravity = false;

        Ctx.Data.Climber.ClimberPosition.SetParent(null);
        Ctx.Data.Climber.PlayerGameObject.transform.SetParent(Ctx.Data.Climber.ClimberPosition);
        
        Ctx.Data.Climber.ClimberPosition.position = _grabPoint.position;
    }

    public void UnlockPhysics()
    {
        Ctx.Data.Climber.PlayerGameObject.transform.SetParent(null);
        Ctx.Data.Climber.ClimberPosition.SetParent(Ctx.Data.Climber.transform);
        
        Ctx.Data.Physics.isKinematic = false;
        Ctx.Data.Physics.useGravity = true;
    }

    public void OnNoGrabPointFound()
    {
        _isHanging = false;
        Ctx.Data.WithinClimbRange = false;
        _finishedClimbAnimation = true;
    }
    #endregion
}
