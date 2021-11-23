using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : Destructible
{
    Slider hpSlider;
    Animator animator;
    Animator panelAnimator;
    [SerializeField]
    GameObject failedMessage;
    [SerializeField]
    GameObject playerHUD;

    private void Start()
    {
        hpSlider = GameObject.Find("Slider_Vida").GetComponent<Slider>();
        animator = GetComponent<Animator>();
        panelAnimator = GameObject.Find("Danger").GetComponent<Animator>();
    }

    public override void Die() {
        base.Die();
        isDead = true;
        animator.SetTrigger("Dead");
        if (this.tag == "Player") {
            failedMessage.SetActive(true);
            playerHUD.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public override void TakeDemage(float amount) {
        base.TakeDemage(amount);
        if (this.tag == "Player") {
            hpSlider.value = hitPointsRemaining;
            panelAnimator.SetTrigger("FadeIn");
        }

    }
}
