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
    private float fireRate;
    private bool  mayFire = true;
    // Use this for initialization
    void Start()
    {
        fireRate=60/roundsPerMinute;
        print (fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        switch(fireType)
        {
            case FireType.SemiAutomatic:
                if(Input.GetButtonDown("Fire1"))
                {
                    FireBullet();
                }
                break;
            case FireType.Automatic:
                if(mayFire==true)
                {
                    FireBullet();
                    StartCoroutine("Cooldown");
                }
                if(Input.GetButtonUp("Fire1"))
                {
                    StopCoroutine("Cooldown");
                    mayFire=true;
                }
                break;
            case FireType.BoltOrPumpAction:
                break;
        }
    }

    void FireBullet()
    {
        print("boom headshot");
    }

    IEnumerator Cooldown()
    {
        mayFire=false;
        yield return new WaitForSeconds(fireRate);
        mayFire=true;
    }

    IEnumerator Pump()
    {
        yield return null;
    }
}
