using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;


namespace FleischWolf
{
    public class Pickup : MonoBehaviour
    {
        bool isHeld = false;
        [SerializeField] float throwForce = 600f;
        [SerializeField] float maxDistace = 3f;
        float distance;
        TempParent tempParent;
        Rigidbody rb;

        Vector3 objectPos;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            tempParent = TempParent.Instance;
        }

        void Update()
        {
            if (isHeld == true)
            {
                Hold();
            }
        }

        private void OnMouseDown()
        {
            //Object picked up
            if (tempParent != null)
            {
                isHeld = true;
                rb.useGravity = false;
                rb.detectCollisions = true;

                this.transform.SetParent(tempParent.transform);
            }
            else
            {
                Debug.Log("TempParent not found");
            }
        }

        private void OnMouseUp()
        {
            //Object dropped? Maybe?
        }

        private void OnMouseExit()
        {
            //Same as MouseUp
        }

        private void Hold()
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;


        }
        
        public void Throw ()
        {
            
        }


    }
}