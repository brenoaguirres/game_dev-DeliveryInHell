using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CBPXL.ControllableCharacter.ControllableCharacterStateMachine
{
    public class ControllableCharacterStateShoot : ControllableCharacterState
    {
        #region EVENTS
        private Action GUN_UNLOCK;
        #endregion

        #region CONSTRUCTOR
        public ControllableCharacterStateShoot(ControllableCharacterStateMachine currentContext,
            ControllableCharacterStateFactory stateFactory) : base(currentContext, stateFactory)
        {
        }
        #endregion

        #region STATE METHODS
        public override void EnterState()
        {
            GUN_UNLOCK += OnGunUnlock;
            Ctx.Data.AnimatorEvents.onAnimationClipEnded += OnShootAnimFinish;

            // Shoot init
            Ctx.Data.Animator.SetBool("Shoot", true);
            Ctx.Data.ShootAnimEnded = false;
            Ctx.Data.CanShoot = true;
            Ctx.Data.GunLocked = false;
        }

        public override void UpdateState()
        {
            CheckSwitchStates();
            UpdateShoot();
        }

        public override void FixedUpdateState()
        {
        }

        public override void ExitState()
        {
            GUN_UNLOCK -= OnGunUnlock;
            Ctx.Data.AnimatorEvents.onAnimationClipEnded -= OnShootAnimFinish;

            Ctx.Data.Animator.SetBool("Shoot", false);
        }

        public override void CheckSwitchStates()
        {
            //if (!Ctx.Input.ShootInput /*&& Ctx.Data.CanShoot */&& Ctx.Data.ShootAnimEnded)
            if (!Ctx.Input.ShootInput && Ctx.Data.ShootAnimEnded)
            {
                SwitchState(Factory.Aim());
            }
        }

        public override void InitializeSubState()
        {
        }

        #endregion

        #region BEHAVIOR METHODS
        public void UpdateShoot()
        {
            if (Ctx.Data.RangedWeapon.ActionType == WeaponSystem.ActionType.SEMI_AUTO)
            {
                if (Ctx.Data.CanShoot)
                {
                    Ctx.Data.Animator.SetBool("Shoot", false);
                    Ctx.Data.CanShoot = false;
                }
                else if (!Ctx.Data.GunLocked)
                {
                    Ctx.StartCoroutine(WaitCooldown(Ctx.Data.RangedWeapon.FireRate * Ctx.Data.One));
                }
            }
            else if (Ctx.Data.RangedWeapon.ActionType == WeaponSystem.ActionType.FULLY_AUTO)
            {
                //TODO: fully auto behavior
            }
            
        }

        public IEnumerator WaitCooldown(float seconds)
        {
            Ctx.Data.GunLocked = true;
            yield return new WaitForSeconds(seconds);
            GUN_UNLOCK?.Invoke();
        }

        public void OnGunUnlock()
        {
            Ctx.Data.GunLocked = false;
            Ctx.Data.CanShoot = true;
        }

        public void OnShootAnimFinish(AnimationClip clip)
        {
            //TODO: Improve this by removing these literals
            string[] animNames = { "ShootMiddle", "ShootLower", "ShootUpper" };

            foreach (string animName in animNames) {
                if (clip.name == animName)
                {
                    Ctx.Data.ShootAnimEnded = true;
                }
            }
        }
        #endregion
    }
}
