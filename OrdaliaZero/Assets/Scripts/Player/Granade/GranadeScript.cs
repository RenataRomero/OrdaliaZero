using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeScript : MonoBehaviour
{
    //Variables;
    public GameObject explosionEffect;
    public float delay = 3f;

    public float explosionforce = 10f;
    public float radius = 20f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", delay);
    }

    //Method of explosion
    private void Explode()

    {
        //Nearby colliders
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius); 

        //Apply force
        foreach(Collider near in colliders)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();
            if (rig != null)
                rig.AddExplosionForce(explosionforce, transform.position, radius, 1f, ForceMode.Impulse);

        }
        //Explosion Effect
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    
}
