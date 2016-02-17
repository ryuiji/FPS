using UnityEngine;
using System.Collections;
using System;

public class AK47 : GunAbstract
{
    public void Awake()
    {
        fireRate=60/roundsPerMinute;
    }

    public override void Shoot()
    {
        print("firedAk");
        audioSource.PlayOneShot(fire);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    public override IEnumerator Reload()
    {
        return null;
    }

    public override void Aim()
    {

    }

    public override void PassDelegates()
    {
        gunManager.shoot = PullTrigger;
        gunManager.aim = Aim;
        gunManager.reload = Reload;
    }

    public override void PullTrigger()
    {
        if (bulletsInClip >= 1)
        {
            switch (fireMode)
            {
                case CurrentFireMode.SemiAutomatic:
                    if (Input.GetButtonDown("Fire1") && mayFire == true)
                    {
                        Shoot();
                        StartCoroutine("RateOfFire");
                    }
                    break;
                case CurrentFireMode.Automatic:
                    if (mayFire == true)
                    {
                        Shoot();
                        StartCoroutine("RateOfFire");
                    }
                    if (Input.GetButtonUp("Fire1"))
                    {
                        Shoot();
                        StartCoroutine("RateOfFire");
                    }
                    break;
                case CurrentFireMode.PumpAction:
                    if (mayFire == true)
                    {
                        Shoot();
                        StartCoroutine("RateOfFire");
                    }
                    break;
            }
        }
    }

    public override IEnumerator RateOfFire()
    {
        mayFire=false;
        yield return new WaitForSeconds(fireRate);
        mayFire=true;
    }
}
