using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AnimationEvents : MonoBehaviour
{
    private Animator _playerAnimator;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    public void StopJump()
    {
        _playerAnimator.SetBool("CanJump",false);
    }
}
