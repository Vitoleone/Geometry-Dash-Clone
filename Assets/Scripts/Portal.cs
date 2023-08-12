using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    enum PortalType
    {
        ChangeMovementType,
        EndLevel
    }
    [SerializeField] private PortalType portalType;
    [SerializeField] private PlayerMovement.MovementType newMovementType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMovement playerMovement))
        {
            if (portalType == PortalType.ChangeMovementType)
            {
                other.GetComponent<Rigidbody2D>().AddForce(15*Vector2.right,ForceMode2D.Impulse);
                playerMovement.ChangeMovement(newMovementType);
                GameManager.Instance.playerCam.m_Lens.Dutch = -180;
            }
            else if (portalType == PortalType.EndLevel)
            {
                EventManager.Instance.OnGameEnd.Invoke();
            }
            
        }
    }
}
