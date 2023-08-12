using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
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
  [SerializeField]private MovementType _movementType;

  private Rigidbody2D _playerRb;
  private bool _onGround = true;
  private Animator _playerAnimator;

  private void Awake()
  {
    _playerRb = GetComponent<Rigidbody2D>();
    _playerAnimator = GetComponent<Animator>();
  }

  private void FixedUpdate()
  {
    //All the physic calculations is here
    RaycastHit2D hit2D = Physics2D.Raycast(transform.position-transform.right*0.2f,Vector2.down * 0.37f,0.37f,layerMask);
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
    //Cheking current phase for moveType.
    //If moveType == normal then moving and jumping phase is active
    if (_movementType == MovementType.Normal)
    {
      //Need to get inputs in update so some physic calculations done here.
      if ((Input.GetMouseButton(0) || Input.touchCount > 0) && _onGround)
      {
        NormalJump();
      }
    }
    //If moveType == Carpet then flying phase is active
    else if (_movementType == MovementType.Carpet)
    {
      carpet.SetActive(true);
      if (Input.GetMouseButton(0))
      {
        Fly();
      }
      //when player's touched thump is up on screen carpet plays fall animation 
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
#if UNITY_EDITOR
    //For editor, current carpetSpeed is too much. So balanced it.
    carpetSpeed = 60f;
#endif
    _playerRb.AddForce(Vector2.up*carpetSpeed,ForceMode2D.Force);
  }
  public void OnGround()
  {
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

  //For checking rays without play mode
  private void OnDrawGizmos()
  {
    Debug.DrawRay(transform.position-Vector3.right*0.2f,Vector2.down * 0.39f,Color.cyan);
    Debug.DrawRay(transform.position, transform.right * 0.4f,Color.cyan);
  }
}
