using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class Portal : MonoBehaviour
{
    enum PortalType
    {
        ChangeMovementType,
        EndLevel
    }
    [Header("Attributes")]
    [SerializeField] private PortalType portalType;
    [SerializeField] private PlayerMovement.MovementType newMovementType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //checking if player entered
        if (other.TryGetComponent(out PlayerMovement playerMovement))
        {
            if (portalType == PortalType.ChangeMovementType)
            {
                //bursts players velocity for a while
                other.GetComponent<Rigidbody2D>().AddForce(15*Vector2.right,ForceMode2D.Impulse);
                //change player's moveType to carpet(for future we can add more types here easily).
                playerMovement.ChangeMovement(newMovementType);
            }
            else if (portalType == PortalType.EndLevel)
            {
                EventManager.Instance.OnGameEnd.Invoke();
            }
            
        }
    }
}
