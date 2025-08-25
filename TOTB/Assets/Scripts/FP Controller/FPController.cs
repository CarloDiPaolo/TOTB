using UnityEngine;
using Unity.Cinemachine;

namespace FleischWolf
{
    [RequireComponent(typeof(CharacterController))]
    public class FPController : MonoBehaviour
    {
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
        #endregion

    }
}
