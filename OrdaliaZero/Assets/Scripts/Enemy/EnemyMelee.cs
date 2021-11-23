using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMelee : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    public GameObject player;
    [SerializeField]
    public float attackDistance = 5.0f;
    [SerializeField]
    public float followDistance = 20.0f;

    [Range(0.0f, 1.0f)]
    public float attackProbability = 0.5f;

    [Range(0.0f, 1.0f)]
    public float hitAccuracy = 0.5f;
    [SerializeField]
    public float demagePoints = 2.0f;

    private Health health;

    AudioSource audioSource;

    public float animationBlend = 10;

    public float rotationSpeed = 10f;
    private bool attacking = false;

    [SerializeField]
    MenuPause pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        audioSource = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!pauseMenu.gameIsPaused)
        {
            if (health.isDead)
            {
                navMeshAgent.isStopped = true;
            }

            if (navMeshAgent.enabled && !health.isDead && !player.GetComponentInParent<Health>().isDead)
            {

                float dist = Vector3.Distance(player.transform.position, this.transform.position);
                bool follow = (dist < followDistance);
                animator.SetFloat("MotionSpeed", 1f);

                if (follow)
                {

                    if (!attacking && !animator.GetCurrentAnimatorStateInfo(0).IsName("melee_enemy"))
                    {
                        navMeshAgent.SetDestination(player.transform.position);
                        if (dist > attackDistance && (dist - attackDistance) > 1 && !animator.GetCurrentAnimatorStateInfo(0).IsName("melee_enemy") && !attacking)
                        {
                            animator.SetFloat("MotionSpeed", 1f);
                            animator.SetFloat("Speed", 2.1f);
                        }
                        else
                        {
                            animator.SetFloat("MotionSpeed", 1f);
                            animator.SetFloat("Speed", 2.1f);
                        }

                        if (dist < attackDistance && (attackDistance - dist) < 1 && !animator.GetCurrentAnimatorStateInfo(0).IsName("melee_enemy") && !attacking)
                        {
                            attacking = true;
                            StartCoroutine(Attack());
                        }
                        else
                        {
                            animator.SetFloat("MotionSpeed", 1f);
                            animator.SetFloat("Speed", 2.1f);

                        }

                    }

                }


            }
            else if (player.GetComponentInParent<Health>().isDead)
            {
                animator.SetFloat("MotionSpeed", 1f);
                animator.SetFloat("Speed", 0f);
            }

        }

    }

    public IEnumerator Attack() 
    {
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(3.0f);

        attacking = false;

    }
}
