﻿using UnityEngine;
using System.Collections;

public class Shotgun : GunAbstract {

	public AudioClip pumpSound;
    public AudioClip addBullet;

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
        //bullet.GetComponent<Bullet>().damage=damage;
        IncreaseRecoil();
        Instantiate(bullet, firePoint.position + new Vector3(Random.Range(minRecoilX,maxRecoilX) * recoilAmount, Random.Range(minRecoilY, maxRecoilY) * recoilAmount, 0), firePoint.rotation);
        gunManager.UpdateUI(bulletsInClip, looseAmmo, gunName);
    }

    public override IEnumerator Reload()
    {
        #region
        //if (isReloading == false)
        //{
        //    gunManager.isReloading = true;
        //    StopCoroutine("RateOfFire");
        //    isReloading = true;
        //    mayFire = false;
        //    if (looseAmmo == 0)
        //    {
        //        print("cant reload brah");
        //        mayFire = true;
        //        StopCoroutine("Reload");
        //    }
        //    audioSource.PlayOneShot(reload);
        //    yield return new WaitForSeconds(reloadSpeed);
        //    isReloading = false;
        //    mayFire = true;
        //    if (looseAmmo >= clipSize)
        //    {
        //        print("1");
        //        looseAmmo -= clipSize - bulletsInClip;
        //        bulletsInClip = clipSize;
        //    }
        //    else if (looseAmmo < clipSize && looseAmmo > 0)
        //    {
        //        print("2");
        //        if (looseAmmo + bulletsInClip > clipSize)
        //        {
        //            looseAmmo -= clipSize - bulletsInClip;
        //            bulletsInClip = clipSize;
        //        }
        //        else
        //        {
        //            bulletsInClip += looseAmmo;
        //            looseAmmo -= looseAmmo;
        //        }

        //    }
        //    gunManager.isReloading = false;
        //}
        //gunManager.UpdateUI(bulletsInClip, looseAmmo, gunName);
        #endregion 
        mayFire=false;
        for(int i = 0; i<clipSize; i++)
        {
            if(bulletsInClip<clipSize && looseAmmo > 1)
            {
                audioSource.PlayOneShot(addBullet);
                bulletsInClip++;
                looseAmmo--;
                gunManager.UpdateUI(bulletsInClip,looseAmmo,gunName);
                yield return new WaitForSeconds(addBullet.length);
            }
            if(bulletsInClip==clipSize)
            {
                audioSource.PlayOneShot(pumpSound);
                yield return new WaitForSeconds(pumpSound.length);
                break;
            }

        }
        mayFire=true;

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
        audioSource=gunManager.gunAudio;
        gunManager.addAmmo = AddAmmo;
        gunManager.shoot = PullTrigger;
        gunManager.aim = Aim;
        gunManager.unAim = UnAim;
        gunManager.reload = Reload;
        gunManager.decrease = DecreaseRecoil;
        transform.position=normalSpot.position;
        transform.rotation=normalSpot.rotation;
        gunManager.UpdateUI(bulletsInClip, looseAmmo, gunName);
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

    public override void IncreaseRecoil()
    {
        if(recoilAmount<maxRecoilAmount)
        {
            recoilAmount+=0.1f;
        }
    }

    public override void DecreaseRecoil()
    {
        if (recoilAmount > 0 )
        {
            recoilAmount -= 1f * Time.deltaTime;
        }
    }

    public override IEnumerator RateOfFire()
    {
        mayFire = false;
       	audioSource.PlayOneShot(pumpSound);
        yield return new WaitForSeconds(pumpSound.length);
        mayFire = true;
    }

    public override void AddAmmo(int bullets)
    {
        looseAmmo+=bullets;
        gunManager.UpdateUI(bulletsInClip, looseAmmo, gunName);
    }
}
