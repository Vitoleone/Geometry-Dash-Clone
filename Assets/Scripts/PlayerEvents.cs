using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerEvents : MonoBehaviour
{
    private ParticleSystem _deathParticle;
    private GameObject _player;
    private Transform _playerStartPosition;
    private ProgressIndıcator _progressIndicator;
    private DieCounter _dieCounter;
    

    private void Start()
    {
        InitilizeValues();
        EventManager.Instance.OnPlayerDie += OnPlayerDieCallback;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnPlayerDie -= OnPlayerDieCallback;
    }

    private void OnPlayerDieCallback()
    {
        StartCoroutine(PlayerDieCoroutine());
    }

    private void InitilizeValues()
    {
        _deathParticle = GameManager.Instance.deathParticle;
        _player = GameManager.Instance.player;
        _playerStartPosition = GameManager.Instance.startLine;
        _progressIndicator = GameManager.Instance.progressIndıcator;
        _dieCounter = GameManager.Instance.dieCounter;
    }

    IEnumerator PlayerDieCoroutine()
    {
        GameManager.Instance.gameData.IncreaseDieCount();
        _dieCounter.UpdateDieCounter();
        _progressIndicator.ResetIndicator();
        
        _deathParticle.transform.position = _player.transform.position;
        _deathParticle.Play();
        
        _player.SetActive(false);
        _player.transform.position = _playerStartPosition.position;
        
        yield return new WaitForSeconds(_deathParticle.main.duration);
        
        _player.SetActive(true);
        
    }
}
