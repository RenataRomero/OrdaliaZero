using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    float rateOfFire;
    [SerializeField]
    float totalAmmo = 10f;

    float currentAmmo = 10f;

    float ammoPool = 20000f;
    [SerializeField]
    TextMeshProUGUI currentAmmoText;

    private float nextFireAllowed;

    [HideInInspector]
    public Transform muzzle;
    [HideInInspector]
    public bool canFire;

    

    private void Awake()
    {
        currentAmmo = totalAmmo;
        muzzle = transform.Find("Muzzle");
        currentAmmoText = GameObject.Find("currentAmmo").GetComponent<TextMeshProUGUI>();
        currentAmmoText.text = currentAmmo.ToString();
    }

    public virtual void Shoot() {

        canFire = false;

        if (Time.time < nextFireAllowed)
            return;

        nextFireAllowed = Time.time + rateOfFire;

        currentAmmo--;


        if (currentAmmo > 0)
        {
            canFire = true;
            currentAmmoText.text = currentAmmo.ToString();
        }
        else {
            currentAmmoText.text = 0f.ToString();
        }

    }

    public void reload() {
        if (ammoPool < totalAmmo)
        {
            currentAmmo = ammoPool;
            ammoPool = ammoPool - currentAmmo;
        }
        else
        {
            currentAmmo = totalAmmo;
            ammoPool = ammoPool - currentAmmo;
        }

        currentAmmoText.text = currentAmmo.ToString();
    }

    public float getCurrentAmmo() {
        return this.currentAmmo;
    }

    public void setCurrentAmmo(float currentAmmo)
    {
        this.currentAmmo = currentAmmo;
        
    }

    public float getTotalAmmo()
    {
        return this.totalAmmo;
    }

    public void setTotalAmmo(float totalAmmo)
    {
        this.totalAmmo = totalAmmo;
    }

    public float getAmmoPool() {
        return this.ammoPool;
    }

    public void setAmmoPool(float ammoPool) {
        this.ammoPool = ammoPool;
    }

}
