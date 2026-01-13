using UnityEngine;
using UnityEngine.InputSystem;


namespace FleischWolf
{
    
    public class PlayerPickup : MonoBehaviour
    {
        [SerializeField] Transform playerCamTransform; 
        [SerializeField] LayerMask pickupLayerMask;
        [SerializeField] Transform grabParentTransform;  
        public float maxGrabDistance = 0.3f;
        public void OnGrab()
            {
               // Debug.Log("Grab Object");

                if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit raycastHit, maxGrabDistance, pickupLayerMask))
            {
                if(raycastHit.transform.TryGetComponent(out Pickup objectGrabbable))
                {
                    Debug.Log(raycastHit.transform);
                    objectGrabbable.GrabObject(grabParentTransform);
                }
            }
            }
    }
}
