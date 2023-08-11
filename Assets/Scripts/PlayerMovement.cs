using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
  enum MovementType
  {
    Normal,
    Rocket
  }
  [Header("Attributes")]
  [SerializeField] private float moveSpeed;
  [SerializeField] private float jumpPower;
  [SerializeField] private float fallingMass;
  [SerializeField] private float defaultMass;
  [SerializeField] private LayerMask layerMask;
  
  private Rigidbody2D _playerRb;
  private bool _onGround = true;
  private MovementType _movementType;
  private Animator _playerAnimator;

  private void Awake()
  {
    _playerRb = GetComponent<Rigidbody2D>();
    _playerAnimator = GetComponent<Animator>();
  }

  private void FixedUpdate()
  {
    RaycastHit2D hit2D = Physics2D.Raycast(transform.position,Vector2.down * 0.37f,0.37f,layerMask);
    if (!(hit2D.collider == null))
    {
      OnGround();
    }
    else
    {
      NotOnGround();
    }
  }

  private void Update()
  {
    if (_movementType == MovementType.Normal)
    {
      gameObject.transform.position += transform.right * (moveSpeed * Time.deltaTime);
      if (Input.GetMouseButton(0) && _onGround)
      {
        NormalJump();
        
      }
    }
    
  }
  private void NormalJump()
  {
    _playerAnimator.SetBool("CanJump",true);
    NotOnGround();
    _playerRb.AddForce(transform.up*jumpPower,ForceMode2D.Impulse);
  }
  public void OnGround()
  {
    _playerAnimator.SetBool("CanJump",false);
    if (_playerRb.velocity.y <= 0)
    {
      _playerRb.gravityScale = defaultMass;
      _onGround = true;
      EventManager.Instance.OnGroundEvent.Invoke();
    }
  }
  public void NotOnGround()
  {
    _onGround = false;
    EventManager.Instance.NotOnGroundEvent.Invoke();
    if (_playerRb.velocity.y <= 0)
    {
      _playerRb.gravityScale = fallingMass; }
  }

  public bool IsGround()
  {
    return _onGround;
  }

  private void OnDrawGizmos()
  {
    Debug.DrawRay(transform.position,Vector2.down * 0.37f,Color.black);
  }
}
