using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StaticEnemy : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    public GameObject player;
    [SerializeField]
    public float attackDistance = 5.0f;
    [SerializeField]
    public float followDistance = 20.0f;

    [Range(0.0f, 1.0f)]
    public float attackProbability = 0.5f;

    [SerializeField]
    public float demagePoints = 2.0f;

    private Health health;

    [SerializeField]
    ParticleSystem muzzleFlash;

    [SerializeField]
    GameObject muzzle;

    AudioSource audioSource;

    [SerializeField]
    public float rotationSpeed = 10f;

    [SerializeField]
    MenuPause pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        audioSource = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu.gameIsPaused) {
            if (!health.isDead && !player.GetComponentInParent<Health>().isDead)
            {

                float dist = Vector3.Distance(player.transform.position, this.transform.position);
                bool shoot = false;
                bool follow = (dist < followDistance);

                if (follow)
                {
                    float random = Random.Range(0.0f, 1.0f);
                    if (random > (1.0f - attackProbability) && dist < attackDistance)
                    {
                        shoot = true;
                    }
                }

                if (follow)
                {
                    RotateTowards(player.transform);

                }

                if (shoot)
                {
                    TryShoot();
                }

            }
        }

    }

    public void TryShoot()
    {

        float random = Random.Range(0.0f, 1.0f);

        RaycastHit objectHit;

        if (Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out objectHit, 200))
        {
            Debug.DrawLine(muzzle.transform.position, objectHit.point, Color.green, 2f);

            if (objectHit.collider.tag == "Player")
            { 
                Health playerHP = player.GetComponentInParent<Health>();
                playerHP.TakeDemage(demagePoints);
            }
            muzzleFlash.Play();
            audioSource.Play();

        }

    }

    private void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
