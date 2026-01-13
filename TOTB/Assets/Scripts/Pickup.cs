using UnityEngine;
using UnityEngine.InputSystem;



namespace FleischWolf
{
    public class Pickup : MonoBehaviour
    {
        private Rigidbody rb;
        private Transform grabParentTransform;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        public void GrabObject(Transform grabParentTransform)
        {
            this.grabParentTransform = grabParentTransform;
            rb.useGravity = false;
        }

        private void FixedUpdate()
        {
            if (grabParentTransform != null)
            {
                rb.MovePosition(grabParentTransform.position);
            }
        }
    }
}