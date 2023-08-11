using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public UnityAction OnGroundEvent;
    public UnityAction NotOnGroundEvent;
    public UnityAction OnPlayerDie;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
 
}
