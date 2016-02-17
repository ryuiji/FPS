using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gunmanage : MonoBehaviour
{
    public delegate void ShootGun();
    public ShootGun shoot;
    public delegate IEnumerator ReloadGun();
    public ReloadGun reload;
    public delegate void Aim();
    public Aim aim;
    public delegate void UnAim();
    public UnAim unAim;
    public delegate void PassDelegates();
    public PassDelegates pass;
    public GameObject[] gunList;

    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetButtonDown("WeaponOne") && CheckGun(0)==true)
        {
            SwitchWeapon(0);
        }

        if (Input.GetButtonDown("WeaponTwo") && CheckGun(1) == true)
        {
            SwitchWeapon(1);
        }

        if (Input.GetButton("Fire1") && shoot != null)
        {
            print("shoot");
            shoot();
        }

        if(Input.GetMouseButton(1) && aim !=null)
        {
            aim();
        }
        else if(unAim != null)
        {
            unAim();
        }

        if(Input.GetButtonDown("Reload"))
        {
            StartCoroutine(reload());
        }
    }

    void SwitchWeapon(int i)
    {
        DeactivateWeapons();
        gunList[i].SetActive(true);
        print("switched weapon");
        pass();
    }

    void DeactivateWeapons()
    {
        for(int i =0; i<gunList.Length; i++)
        {
            gunList[i].SetActive(false);
        }
    }

    bool CheckGun(int i)
    {
        if(gunList[i].active==false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
