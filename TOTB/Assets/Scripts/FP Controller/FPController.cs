using UnityEngine;
using Unity.Cinemachine;
using Unity.Mathematics;

namespace FleischWolf
{
    [RequireComponent(typeof(CharacterController))]
    public class FPController : MonoBehaviour
    {
        [Header("Movement Paramenters")]
        public float MaxSpeed = 3.5f;

        [Header("Camera Parameters")]
        public Vector2 LookSensitivity = new Vector2(0.1f, 0.1f);
        public float PitchLimit = 85f;
        [SerializeField] float currentPitch = 0f;
        public float CurrentPitch
        {
            get => currentPitch;

            set
            {
                currentPitch = Mathf.Clamp(value, -PitchLimit, PitchLimit);
            }
        }



        [Header("Input")]
        public Vector2 MoveInput;
        public Vector2 LookInput;

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
            Vector3 motion = transform.forward * MoveInput.y + transform.right * MoveInput.x;
            motion.y = 0f;
            motion.Normalize();

            characterController.Move(motion * MaxSpeed * Time.deltaTime);


        }

        void LookUpdate()
        {
            Vector2 cameraInput = new Vector2(LookInput.x * LookSensitivity.x, LookInput.y * LookSensitivity.y);

            CurrentPitch -= cameraInput.y;

            FP_Camera.transform.localRotation = Quaternion.Euler(CurrentPitch, 0f, 0f);

            transform.Rotate(Vector3.up * cameraInput.x);
        }
        #endregion
    }
}
