using UnityEngine;
using System.Collections;
using System;

public class AK47 : GunAbstract
{
    public void OnEnable()
    {
        fireRate = 60 / roundsPerMinute;
        gunManager.pass = PassDelegates;
    }

    public override void Shoot()
    {
        bulletsInClip--;
        print("firedAk");
        audioSource.PlayOneShot(fire);
        bullet.GetComponent<Bullet>().damage=damage;
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    public override IEnumerator Reload()
    {
        if (isReloading == false)
        {
            StopCoroutine("RateOfFire");
            isReloading = true;
            mayFire = false;
            if (looseAmmo == 0)
            {
                print("cant reload brah");
                mayFire = true;
                StopCoroutine("Reload");
            }
            audioSource.PlayOneShot(reload);
            yield return new WaitForSeconds(reloadSpeed);
            isReloading = false;
            mayFire = true;
            if (looseAmmo >= clipSize)
            {
                print("1");
                looseAmmo -= clipSize - bulletsInClip;
                bulletsInClip = clipSize;
            }
            else if (looseAmmo < clipSize && looseAmmo > 0)
            {
                print("2");
                if (looseAmmo + bulletsInClip > clipSize)
                {
                    looseAmmo -= clipSize - bulletsInClip;
                    bulletsInClip = clipSize;
                }
                else
                {
                    bulletsInClip += looseAmmo;
                    looseAmmo -= looseAmmo;
                }

            }
        }


    }

    public override void Aim()
    {
        transform.position = Vector3.MoveTowards(transform.position, aimSpot.position, aimSpeed * Time.deltaTime);
    }

    public override void UnAim()
    {
        transform.position = Vector3.MoveTowards(transform.position, normalSpot.position, aimSpeed * Time.deltaTime);
    }

    public override void PassDelegates()
    {
        gunManager.shoot = PullTrigger;
        gunManager.aim = Aim;
        gunManager.unAim = UnAim;
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
        mayFire = false;
        yield return new WaitForSeconds(fireRate);
        mayFire = true;
    }
}
