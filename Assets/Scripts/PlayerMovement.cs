using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
  [SerializeField] private float moveSpeed;
  [SerializeField] private float jumpPower;
  private Rigidbody2D _playerRb;
  private bool _onGround = true;

  private void Awake()
  {
    _playerRb = GetComponent<Rigidbody2D>();
  }
  
  private void Update()
  {
    gameObject.transform.position += transform.right * (moveSpeed * Time.deltaTime);
    if (Input.GetMouseButton(0) && _onGround)
    {
      Jump();
    }
  }
  private void Jump()
  {
    NotOnGround();
    _playerRb.AddForce(transform.up*jumpPower,ForceMode2D.Impulse);
  }
  public void OnGround()
  {
    _onGround = true;
  }
  public void NotOnGround()
  {
    _onGround = false;
  }
  
}
