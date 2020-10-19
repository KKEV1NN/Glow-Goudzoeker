using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimManager : MonoBehaviour
{
    private bool anim1 = false;
    public Animator animator;
    
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

    }
    void Anim1()
    {
        if (anim1 == false){
            animator.SetBool("Idle", true);
            anim1 = true;
            return;
        }
        else if(anim1 == true)
        {
            anim1 = false;
            animator.SetBool("Idle", false);
            return;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Anim1();
        }
    }
}
