using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Gun
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip noAmmoAudio;
    [SerializeField]
    ParticleSystem muzzleFlash;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public override void Shoot()
    {
        base.Shoot();

        if (canFire)
        {
            audioSource.Play();
            muzzleFlash.Play();

            Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 100))
            {
                var health = hitInfo.collider.GetComponent<Health>();
                if (health != null)
                    health.TakeDemage(5);
            }
        }
        else if(base.getCurrentAmmo() <= 0){
            audioSource.PlayOneShot(noAmmoAudio);
        }
    }
}
