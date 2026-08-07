using System.Reflection;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public Animator animator;

    public 
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void Interact()
    {
        Debug.Log("Play Interaction");
        animator.Play("Bin_Open");
        
    }

    
}



