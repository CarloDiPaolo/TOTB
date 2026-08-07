using System.Reflection;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public Animator animator;

    private bool binOpened = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void Interact()
    {
        //Debug.Log("Play Interaction");
        if (!binOpened)
        {
            animator.Play("Bin_Open");
            binOpened = true;
        }
        else if (binOpened)
        {
            animator.Play("Bin_Close");
            binOpened = false;
        }

       
        
    }

    
}



