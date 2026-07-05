using UnityEngine;

public class DestroyOnAwake : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Destroy(gameObject);
    }
}
