using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(Animator))]
public class AnimationEvents : MonoBehaviour
{
    private Animator _playerAnimator;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    public void StopJump()//For play jump animation for once(animation event)
    {
        _playerAnimator.SetBool("CanJump",false);
    }
}
