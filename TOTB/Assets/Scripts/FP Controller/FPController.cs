using UnityEngine;
using Unity.Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;

namespace FleischWolf
{
    [RequireComponent(typeof(CharacterController))]
    public class FPController : MonoBehaviour
    {
        [Header("Movement Paramenters")]
        public float maxSpeed => isSprinting ? sprintSpeed : walkSpeed;
        public float moveAcceleration = 15f;

        [SerializeField] float walkSpeed = 3.0f;
        [SerializeField] float sprintSpeed = 6.0f;

        public Vector3 currentVelocity { get; private set; }
        public float currentSpeed { get; private set; }

        [Header("Camera Parameters")]
        public Vector2 lookSensitivity = new Vector2(0.1f, 0.1f);
        public float pitchLimit = 85f;
        [SerializeField] float currentPitch = 0f;
        public float CurrentPitch
        {
            get => currentPitch;

            set
            {
                currentPitch = Mathf.Clamp(value, -pitchLimit, pitchLimit);
            }
        }



        [Header("Input")]
        public Vector2 moveInput;
        public Vector2 lookInput;
        public bool isSprinting;

        [Header("Components")]
        [SerializeField] CinemachineCamera FP_Camera;
        [SerializeField] CharacterController characterController;

        #region Unity Methods
        void OnValidate()
        {
            if (characterController == null)
            {
                characterController = GetComponent<CharacterController>();
            }
        }

        void Update()
        {
            MoveUpdate();
            LookUpdate();


        }
        #endregion

        #region Controller Methods

        void MoveUpdate()
        {
            Vector3 motion = transform.forward * moveInput.y + transform.right * moveInput.x;
            motion.y = 0f;
            motion.Normalize();

            if (motion.sqrMagnitude >= +0.01f)
            {
                currentVelocity = Vector3.MoveTowards(currentVelocity, motion * maxSpeed, moveAcceleration * Time.deltaTime);
            }
            else
            {
                currentVelocity = Vector3.MoveTowards(currentVelocity, Vector3.zero, moveAcceleration * Time.deltaTime);
            }

            float verticalVelocity = Physics.gravity.y * 20f * Time.deltaTime;

            Vector3 fullVelocity = new Vector3(currentVelocity.x, verticalVelocity, currentVelocity.z);

            characterController.Move(fullVelocity * Time.deltaTime);

            currentSpeed = currentVelocity.magnitude;


        }

        void LookUpdate()
        {
            Vector2 cameraInput = new Vector2(lookInput.x * lookSensitivity.x, lookInput.y * lookSensitivity.y);

            CurrentPitch -= cameraInput.y;

            FP_Camera.transform.localRotation = Quaternion.Euler(CurrentPitch, 0f, 0f);

            transform.Rotate(Vector3.up * cameraInput.x);
        }
        #endregion
    }
}
