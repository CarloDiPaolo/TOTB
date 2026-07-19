using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System;


public class Player_Interaction : MonoBehaviour
{
    public Transform interactSource;
    public float interactRange;

    void OnInteract()
    {
        Ray r = new Ray(interactSource.position, interactSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out Interactable interactable))
            {
                //Debug.Log("Play Interaction");
                interactable.Interact();
            }
        }
    }

}
        
