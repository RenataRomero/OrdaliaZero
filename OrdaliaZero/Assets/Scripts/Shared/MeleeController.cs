using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && this.tag == "Enemy") {
            Debug.Log("PEGO MELEE de " + this.tag + " a " + other.tag);
            Health targetHP = other.GetComponent<Health>();
            targetHP.TakeDemage(this.GetComponentInParent<EnemyMelee>().demagePoints);
        } else if (other.tag == "Enemy" && this.tag == "Player") {
            Debug.Log("PLAYER MELEE HIT");
        }
    }
}
