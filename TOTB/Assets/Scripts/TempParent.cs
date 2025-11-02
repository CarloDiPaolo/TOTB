using UnityEngine;

namespace FleischWolf
{
    public class TempParent : MonoBehaviour
    {
        public static TempParent Instance { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            else
            {
                Destroy(this);
            }
        }
    }
}