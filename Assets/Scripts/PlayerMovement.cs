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
  [SerializeField] private LayerMask layerMask;
  
  private Rigidbody2D _playerRb;
  private Collider2D _playerCollider2D;
  private bool _onGround = true;
  private MovementType _movementType;

  private void Awake()
  {
    _playerRb = GetComponent<Rigidbody2D>();
    _playerCollider2D = GetComponent<Collider2D>();
  }

  private void FixedUpdate()
  {
    RaycastHit2D hit2D = Physics2D.Raycast(transform.position,Vector2.down * 0.52f,0.52f,layerMask);
    if (!(hit2D.collider == null))
    {
      Debug.Log(hit2D.collider.name);
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
    NotOnGround();
    _playerRb.AddForce(transform.up*jumpPower,ForceMode2D.Impulse);
  }
  public void OnGround()
  {
    if (_playerRb.velocity.y <= 0)
    {
      _onGround = true;  
    }
    
  }
  public void NotOnGround()
  {
    _onGround = false;
  }

  private void OnDrawGizmos()
  {
    Debug.DrawRay(transform.position,Vector2.down * 0.52f,Color.black);
  }
}
