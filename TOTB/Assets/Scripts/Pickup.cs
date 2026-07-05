using Unity.VisualScripting;
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
            this.transform.parent = grabParentTransform.transform;
            rb.useGravity = false;

            rb.freezeRotation = true;
        }

        public void DropObject()
        {
            this.transform.parent = null;
            
            rb.useGravity = true;
           rb.freezeRotation = false;

        }

        private void Update()
        {
            if (grabParentTransform != null)
            {
                float lerpSpeed = 100f;
                Vector3 newPos = Vector3.Lerp(transform.position, grabParentTransform.position, Time.deltaTime * lerpSpeed);

                rb.MovePosition(newPos);
            }
        }
    }
}