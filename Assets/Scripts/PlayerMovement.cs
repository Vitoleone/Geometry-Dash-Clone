using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
  public enum MovementType
  {
    Normal,
    Carpet
  }
  [Header("Attributes")]
  [SerializeField] private float moveSpeed;
  [SerializeField] private float jumpPower;
  [SerializeField] private float carpetSpeed;
  [SerializeField] private LayerMask layerMask;
  [SerializeField] private GameObject carpet;

  private Rigidbody2D _playerRb;
  private bool _onGround = true;
  [SerializeField]private MovementType _movementType;
  private Animator _playerAnimator;

  private void Awake()
  {
    _playerRb = GetComponent<Rigidbody2D>();
    _playerAnimator = GetComponent<Animator>();
  }

  private void FixedUpdate()
  {
    RaycastHit2D hit2D = Physics2D.Raycast(transform.position,Vector2.down * 0.37f,0.37f,layerMask);
    RaycastHit2D trapHit = Physics2D.Raycast(transform.position,transform.right * 0.4f,0.4f,layerMask);
    if (!(hit2D.collider == null))
    {
      OnGround();
    }
    else
    {
      NotOnGround();
    }
    if (!(trapHit.collider == null))
    {
      EventManager.Instance.OnPlayerDie.Invoke();
    }
  }

  private void Update()
  {
    gameObject.transform.position += transform.right * (moveSpeed * Time.deltaTime);
    if (_movementType == MovementType.Normal)
    {
      if (Input.GetMouseButton(0) && _onGround)
      {
        NormalJump();
        
      }
    }
    else if (_movementType == MovementType.Carpet)
    {
      carpet.SetActive(true);
      if (Input.GetMouseButton(0))
      {
        Fly();
      }
      else if (Input.GetMouseButtonUp(0))
      {
        _playerAnimator.SetBool("isFlyDown",true);
        _playerAnimator.SetBool("isFlyUp",false);
      }
    }
    
    
  }
  private void NormalJump()
  {
    _playerAnimator.SetBool("CanJump",true);
    NotOnGround();
    _playerRb.AddForce(transform.up*jumpPower,ForceMode2D.Impulse);
  }
  private void Fly()
  {
    _playerAnimator.SetBool("isFlyUp",true);
    _playerAnimator.SetBool("isFlyDown",false);
    _playerRb.AddForce(Vector2.up*carpetSpeed,ForceMode2D.Force);
  }
  public void OnGround()
  {
    //_playerAnimator.SetBool("CanJump",false);
    if (_playerRb.velocity.y <= 0)
    {
      _onGround = true;
      EventManager.Instance.OnGroundEvent.Invoke();
    }
  }
  public void NotOnGround()
  {
    _onGround = false;
    EventManager.Instance.NotOnGroundEvent.Invoke();
  }

  public void ChangeMovement(MovementType newType)
  {
    _movementType = newType;
  }

  public void ResetMoveType()
  {
    _movementType = MovementType.Normal;
    carpet.SetActive(false);
  }

  public bool IsGround()
  {
    return _onGround;
  }

  private void OnDrawGizmos()
  {
    Debug.DrawRay(transform.position,Vector2.down * 0.37f,Color.black);
    Debug.DrawRay(transform.position, transform.right * 0.4f,Color.cyan);
  }
}
