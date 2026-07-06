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
        private bool objectGrabbed = false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        public void GrabObject(Transform grabParentTransform)
        {
            this.transform.parent = grabParentTransform.transform;
            rb.useGravity = false;
            rb.freezeRotation = true;
            rb.isKinematic = true;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
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

        private void OnTriggerEnter(Collider other)
        {
            //audioSource.Play();
            //Destroy(gameObject, audioSource.clip.length);
            Destroy(gameObject);
        }

        
            
        

        private void Update()
        {
            if (objectGrabbed == true)
            {
                float lerpSpeed = 100f;
                Vector3 newPos = Vector3.Lerp(transform.position, grabParentTransform.position, Time.deltaTime * lerpSpeed);

                rb.MovePosition(newPos);
            }
        }
    }

    
}