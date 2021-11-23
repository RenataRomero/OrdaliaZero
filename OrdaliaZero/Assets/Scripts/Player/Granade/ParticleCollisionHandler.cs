using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionHandler : MonoBehaviour
{

    public float demage = 20f;
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            other.GetComponent<Health>().TakeDemage(demage);
        }
    }
}
