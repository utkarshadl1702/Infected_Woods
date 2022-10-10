using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject HitEffect;
    [SerializeField] GameObject BloodEffect;
    [SerializeField] float ImpactTime = 0.1f;
    float BloodImpactTime=.5f;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;

    [SerializeField] float timeBetweenShots = 0.5f;

    [SerializeField] bool continuousFire = false;


    bool CanShoot = true;

    private void OnEnable()
    {
        CanShoot = true;
    }

    void Update()
    {
        if (continuousFire)
        {
            if (Input.GetButton("Fire1") && CanShoot)
            {
                StartCoroutine(Shoot());
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && CanShoot)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        CanShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            ProcessRayCast();
            PlayMuzzleFlash();
            ammoSlot.ReduceAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        CanShoot = true;
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRayCast()
    {
        try
        {
            RaycastHit hit;
            Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);

            CreateHitImpact(hit);

            Debug.Log("Shot : " + hit.transform.name);
            // add hit effects
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            target.TakeDamage(damage);
        }

        catch { return; }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        if (hit.transform.tag == "Enemy")
        {
            GameObject _impact = Instantiate(BloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(_impact, BloodImpactTime);
            Debug.Log("enemy hit");
        }
        else
        {
            GameObject impact = Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, ImpactTime);
        }
    }
}
