using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    private Animator animator;
    private bool isActive = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isActive == true)
            {
                animator.SetBool("Activate", true);
                isActive = false;
            }
            else
            {
                animator.SetBool("Activate", false);
                isActive = true;
            }
        }    
    }

}
