using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] 
    float hitPoints;

    public event System.Action OnDeath;
    public event System.Action OnDemageReceived;

    float demageTaken;

    [HideInInspector]
    public bool isDead = false;   

    public float hitPointsRemaining {
        get {
            return hitPoints - demageTaken;
        }
    }

    public bool isAlive {
        get{
            return hitPointsRemaining > 0;
        }
    }

    public virtual void Die() {
        if (isAlive) {
            return;
        }

        if (OnDeath != null) {
            OnDeath();
            
        }
    }

    public virtual void TakeDemage(float amount) {
        demageTaken += amount;

        if (OnDemageReceived != null) {
            OnDemageReceived();
        }

        if (hitPointsRemaining <= 0) {
            Debug.Log("0 HITPOINTS");
            Die();
        }
    }

    public void Reset()
    {
        demageTaken = 0;
    }
}
