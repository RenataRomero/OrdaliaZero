using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    Shooter assaultRifle;

    Animator animator;
    [SerializeField]
    MenuPause menuPause;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (Input.GetButton("Fire1") && !menuPause.gameIsPaused)
        {
            if (!animator.GetBool("Jump") && 
                !animator.GetCurrentAnimatorStateInfo(0).IsName("reload_idle") &&
                !animator.GetCurrentAnimatorStateInfo(0).IsName("reload_walk") &&
                !animator.GetCurrentAnimatorStateInfo(0).IsName("reload_running")
                && !menuPause.gameIsPaused)
            {
                assaultRifle.Shoot();
            }
            else {
                Debug.Log("Can't shoot");
            }

            
            if(!animator.GetBool("Walking"))
                animator.SetBool("Shoot", true);
        }
        else {
            animator.SetBool("Shoot", false);
        }
    }
}
