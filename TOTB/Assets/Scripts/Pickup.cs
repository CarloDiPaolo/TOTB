using UnityEngine;
using UnityEngine.InputSystem;



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

       /* void OnMouseDown()
        {
            //Object picked up
            if (tempParent != null)
            {
                distance = Vector3.Distance(this.transform.position, tempParent.transform.position);

                if(distance <= maxDistace)
                {
                    isHeld = true;
                    rb.useGravity = false;
                    rb.detectCollisions = true;

                    this.transform.SetParent(tempParent.transform);
                }
            }
            else
            {
                Debug.Log("TempParent not found");
            }           
            //Debug.Log("Object picked up");
        } */

        private void OnMouseUp()
        {
            Drop();
        }

        private void OnMouseExit()
        {
            Drop();
        }

        private void Hold()
        {
            distance = Vector3.Distance(this.transform.position, tempParent.transform.position);

            if(distance >= maxDistace)
            {
                Drop();
            }
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            if (Input.GetMouseButtonDown(1))
            {
                rb.AddForce(tempParent.transform.forward * throwForce);

                Drop();
            }
           

        }

        private void Drop()
        {
            if (isHeld)
            {
                isHeld = false;
                objectPos = this.transform.position;
                this.transform.position = objectPos;
                this.transform.SetParent(null);
                rb.useGravity = true;
            }
        }
        
        private void Throw ()
        {
            
        }


    }
}