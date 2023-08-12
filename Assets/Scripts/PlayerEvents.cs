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
    private GameObject _moveParticle;
    

    private void Start()
    {
        InitilizeValues();
        EventManager.Instance.OnPlayerDie += OnPlayerDieCallback;
        EventManager.Instance.NotOnGroundEvent += NotOnGroundEventCallback;
        EventManager.Instance.OnGroundEvent += OnGroundEventCallback;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnPlayerDie -= OnPlayerDieCallback;
        EventManager.Instance.NotOnGroundEvent -= NotOnGroundEventCallback;
        EventManager.Instance.OnGroundEvent -= OnGroundEventCallback;
    }

    private void OnPlayerDieCallback()
    {
        StartCoroutine(PlayerDieCoroutine());
    }
    void NotOnGroundEventCallback()
    {
        _moveParticle.SetActive(false);
    }
    void OnGroundEventCallback()
    {
        _moveParticle.SetActive(true);
    }

    private void InitilizeValues()
    {
        _deathParticle = GameManager.Instance.deathParticle;
        _player = GameManager.Instance.player;
        _playerStartPosition = GameManager.Instance.startLine;
        _progressIndicator = GameManager.Instance.progressIndıcator;
        _dieCounter = GameManager.Instance.dieCounter;
        _moveParticle = GameManager.Instance.moveParticle;
    }

    IEnumerator PlayerDieCoroutine()
    {
        GameManager.Instance.playerCam.m_Lens.Dutch = 0;
        _deathParticle.Play();
        GameManager.Instance.gameData.IncreaseDieCount();
        _dieCounter.UpdateDieCounter();
        _progressIndicator.ResetIndicator();
        _deathParticle.transform.position = _player.transform.position;

        _player.SetActive(false);
        _player.transform.position = _playerStartPosition.position;
        _player.GetComponent<PlayerMovement>().ResetMoveType();
        
        yield return new WaitForSeconds(_deathParticle.main.duration);
        
        _player.SetActive(true);
        
    }
}
