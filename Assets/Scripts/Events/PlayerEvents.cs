using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerEvents : MonoBehaviour//This scripts controls all the player's events
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
        //subscribe events
        EventManager.Instance.OnPlayerDie += OnPlayerDieCallback;
        EventManager.Instance.NotOnGroundEvent += NotOnGroundEventCallback;
        EventManager.Instance.OnGroundEvent += OnGroundEventCallback;
    }

    private void OnDestroy()
    {
        //Unsubscribe on destroy because it will cause some issues on reloading scene
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
        GameManager.Instance.player.GetComponent<Animator>().SetBool("CanJump",false);
    }

    private void InitilizeValues()//initilizes all the values from GameManager
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
        _deathParticle.Play();
        GameManager.Instance.gameData.IncreaseDieCount();
        _dieCounter.UpdateDieCounter();
        _progressIndicator.ResetIndicator();
        
        //change particle position to player's position.
        //Dont choose the destory and re instantiate because this way is more performance.
        _deathParticle.transform.position = _player.transform.position;

        _player.SetActive(false);
        //Re-use player's gameobject for performance.
        _player.transform.position = _playerStartPosition.position;
        _player.GetComponent<PlayerMovement>().ResetMoveType();
        
        yield return new WaitForSeconds(_deathParticle.main.duration);//Wait for death particle duration and active player
        
        _player.SetActive(true);
        
    }
}
