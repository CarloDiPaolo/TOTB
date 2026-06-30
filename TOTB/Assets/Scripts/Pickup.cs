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
            this.grabParentTransform = grabParentTransform;
            rb.useGravity = false;
        }

        private void FixedUpdate()
        {
            if (grabParentTransform != null)
            {
                float lerpSpeed = 15f;
                Vector3 newPos = Vector3.Lerp(transform.position, grabParentTransform.position, Time.deltaTime * lerpSpeed);

                rb.MovePosition(newPos);
            }
        }
    }
}