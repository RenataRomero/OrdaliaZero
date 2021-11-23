using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("PLAYER MELEE HIT " + other.ToString());
        if (other.tag == "Enemy")
        {
            Debug.Log("ENEMY MELEE HIT PLAYER MELEE");
        }
    }
}
