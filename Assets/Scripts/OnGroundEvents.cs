using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundEvents : MonoBehaviour
{
    private GameObject _moveParticle;
    private void Start()
    {
        _moveParticle = GameManager.Instance.moveParticle;
        EventManager.Instance.NotOnGroundEvent += NotOnGroundEventCallback;
        EventManager.Instance.OnGroundEvent += OnGroundEventCallback;
    }

    private void OnDestroy()
    {
        EventManager.Instance.NotOnGroundEvent -= NotOnGroundEventCallback;
        EventManager.Instance.OnGroundEvent -= OnGroundEventCallback;
    }

    void NotOnGroundEventCallback()
    {
        _moveParticle.SetActive(false);
    }
    void OnGroundEventCallback()
    {
        _moveParticle.SetActive(true);
    }
}
