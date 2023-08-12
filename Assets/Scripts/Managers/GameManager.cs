using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject player;
    public GameObject moveParticle;
    public GameObject stageClearedPanel;
    [Header("UI")]
    public Image progressImage;
    [Header("Transform")]
    public Transform startLine;
    public Transform endLine;
    [Header("Other")]
    public GameData gameData;
    public ParticleSystem deathParticle;
    public CinemachineVirtualCamera playerCam;
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
