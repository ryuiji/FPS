using UnityEngine;
using System.Collections;

public enum FireType
{
    Automatic,
    SemiAutomatic,
    BoltOrPumpAction
}



public class Gun : MonoBehaviour
{
    public FireType fireType;
    public float roundsPerMinute;
    public float timeBetweenShots;
    public AudioClip pumpSound;
    public float fireRate;
    public float pumpTime;
    public int ammoInClip;
    public int fullAmmoInClip;
    public float reloadSpeed;
    private bool mayFire = true;
    public AudioClip emptySound;
    public AudioClip shot;
    public AudioSource audioSource;
    public AudioClip reloadSound;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            fireRate = 60 / roundsPerMinute;
            print(fireRate);
            Fire();
        }
        if(Input.GetButtonDown("Reload") && ammoInClip!=fullAmmoInClip)
        {
            StopAllCoroutines();
            StartCoroutine("Reload");
        }
    }

    void Fire()
    {
        if (ammoInClip >= 1)
        {
            switch (fireType)
            {
                case FireType.SemiAutomatic:
                    if (Input.GetButtonDown("Fire1"))
                    {
                        FireBullet();
                    }
                    break;
                case FireType.Automatic:
                    if (mayFire == true)
                    {
                        FireBullet();
                        StartCoroutine("Cooldown");
                    }
                    if (Input.GetButtonUp("Fire1"))
                    {
                        StopCoroutine("Cooldown");
                        mayFire = true;
                    }
                    break;
                case FireType.BoltOrPumpAction:
                    if (mayFire == true)
                    {
                        FireBullet();
                        StartCoroutine("Pump");
                    }
                    break;
            }
        }
        else if (mayFire == true && ammoInClip == 0)
        {
            switch (fireType)
            {
                case FireType.Automatic:
                    audioSource.PlayOneShot(emptySound);
                    StartCoroutine("Empty");
                    break;
                case FireType.SemiAutomatic:
                    if (Input.GetButtonDown("Fire1"))
                    {
                        StartCoroutine("Empty");
                        audioSource.PlayOneShot(emptySound);
                    }
                    break;
                case FireType.BoltOrPumpAction:
                    if (Input.GetButtonDown("Fire1"))
                    {
                        StartCoroutine("Empty");
                        audioSource.PlayOneShot(emptySound);
                    }
                    break;
            }
        }

    }

    void FireBullet()
    {
        audioSource.PlayOneShot(shot);
        ammoInClip--;
        print("boom headshot");
    }

    IEnumerator Cooldown()
    {
        mayFire = false;
        yield return new WaitForSeconds(fireRate);
        mayFire = true;
    }

    IEnumerator Empty()
    {
        print("StartCooldown");
        mayFire = false;
        yield return new WaitForSeconds(emptySound.length);
        mayFire = true;
        print(mayFire);
    }


    IEnumerator Pump()
    {
        mayFire = false;
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(pumpSound);
        yield return new WaitForSeconds(pumpSound.length);
        mayFire = true;
    }

    IEnumerator Reload()
    {
        mayFire=false;
        audioSource.PlayOneShot(reloadSound);
        yield return new WaitForSeconds(reloadSound.length);
        mayFire=true;
        ammoInClip=fullAmmoInClip;
    }
}
