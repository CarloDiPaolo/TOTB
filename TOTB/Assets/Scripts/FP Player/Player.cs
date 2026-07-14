using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System;




namespace FleischWolf
{
    [RequireComponent(typeof(FPController))]
    public class Player : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] FPController FPController;
        [SerializeField] Transform playerCamTransform; 
        public float maxInteractDistance;
        private Interactable interactable;

        #region Input Handling

        void OnMove(InputValue value)
        {
            FPController.moveInput = value.Get<Vector2>();
        }

        void OnLook(InputValue value)
        {
            FPController.lookInput = value.Get<Vector2>();
        }

        void OnSprint(InputValue value)
        {
            FPController.isSprinting = value.isPressed;
        }

        void OnInteract()
        {
            if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit raycastHit, maxInteractDistance))
                    {
                        if(raycastHit.transform.gameObject.TryGetComponent(out interactable))
                        {
                            interactable.Interact();
                        }
                    }
            
        }

        
        

        

        #endregion

        #region Unity Methods
        void OnValidate()
        {
            if (FPController == null) FPController = GetComponent<FPController>();
        }

        void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        #endregion
    }
}