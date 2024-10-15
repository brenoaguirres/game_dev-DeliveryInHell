using System;
using UnityEngine;

public class AnimatorEvents : MonoBehaviour
{
    #region ACTIONS
    public Action<AnimationClip> onAnimationClipEnded;
    #endregion

    #region CUSTOM METHODS
    public void AnimationClipEnded(AnimationClip clip)
    {
        onAnimationClipEnded?.Invoke(clip);
    }
    #endregion
}
