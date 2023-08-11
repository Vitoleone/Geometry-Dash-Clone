using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public GameObject player;
    public GameObject moveParticle;
    public ParticleSystem deathParticle;
    
    public Transform startLine;
    public Transform endLine;
    public ProgressIndıcator progressIndıcator;
    public DieCounter dieCounter;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
