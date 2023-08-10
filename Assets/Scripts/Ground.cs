using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Ground : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.OnGround();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.NotOnGround();
        }
    }
}
