using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;



namespace FleischWolf
{
    public class Pickup : MonoBehaviour
    {
        //public AudioSource audioSource;
        private Rigidbody rb;
        private Transform grabParentTransform;
        private Transform throwTransform;
        private bool objectGrabbed = false;
        //public float grabLerp = 10f;
        
        

        ScoreManager scoreManager;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();

            scoreManager = FindAnyObjectByType<ScoreManager>();
        }
        public void GrabObject(Transform grabParentTransform, Transform throwTransform)
        {
            this.transform.parent = grabParentTransform.transform;
            rb.useGravity = false;
            rb.freezeRotation = true;
            rb.isKinematic = true;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            //transform.localPosition = throwTransform.localPosition;
            
            //transform.position = Vector3.Lerp(transform.position, Vector3.zero, grabLerp);

            objectGrabbed = true;
        }

        public void DropObject()
        {
            this.transform.parent = null;
            rb.useGravity = true;
            rb.freezeRotation = false;
            rb.isKinematic = false;
            objectGrabbed= false;

        }

        public void ReadyThrow(Transform throwTransform)
        {
           transform.localPosition = throwTransform.localPosition;
           
        }

        public void Throw(float throwForce)
        {
            DropObject();
            rb.AddForce(transform.forward * throwForce);
        }

        private void OnTriggerEnter(Collider other)
        {
            //audioSource.Play();
            //Destroy(gameObject, audioSource.clip.length);

            if (other.gameObject.tag == this.gameObject.tag)
            {
                Debug.Log("CORRECT");
                scoreManager.AddScore();
            }
            else if(other.gameObject.tag != this.gameObject.tag)
            {
                Debug.Log("WRONG");
            }

            
            Destroy(gameObject);
        }

    }

    
}