using UnityEngine;
using UnityEngine.UI;
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
    public delegate void DecreaseRecoil();
    public DecreaseRecoil decrease;
    public delegate void AddAmmo(int bullets);
    public AddAmmo addAmmo;
    public GameObject[] gunList;
    public AudioSource gunAudio;
    public bool isReloading;
    public RaycastHit hit;
    public Text currAmountText;
    public Text looseAmountText;
    public Text gunName;
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
        if (!Input.GetButton("Fire1") && decrease!=null)
        {
            decrease();
        }

        if(Input.GetMouseButton(1) && aim !=null)
        {
            aim();
        }
        else if(unAim != null)
        {
            unAim();
        }

        if(Input.GetButtonDown("Reload") && Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && reload != null)
        {
            StartCoroutine(reload());
        }

        if(Input.GetAxis("Horizontal")>0 || Input.GetAxis("Vertical") > 0 && isReloading==true && reload!=null)
        {
            StopCoroutine(reload());
            gunAudio.Stop();
            isReloading=false;
        }

        if(Input.GetButtonDown("Use"))
        {
            if(Physics.Raycast(transform.position,transform.forward, out hit, 2))
            {
                if(hit.transform.tag=="AmmoPickUp")
                {
                    hit.transform.GetComponent<AmmoPackage>().AddAmmo(gameObject);
                }
                if(hit.transform.tag=="Primary")
                {
                    print("HitPrimary");
                    if(CheckGun(0)==false)
                    {
                        print("REPLACE");
                        gunList[0].transform.parent=null;
                        gunList[0].GetComponent<Collider>().enabled=true;
                        hit.transform.position=gunList[0].transform.position;
                        gunList[0]=hit.transform.gameObject;
                        gunList[0].transform.SetParent(transform);
                        hit.transform.rotation=transform.rotation;  
                        gunList[0].GetComponent<Collider>().enabled=false;
                        DeactivateWeapons();
                        gunList[0].SetActive(true);
                        pass();

                    }
                    else if(CheckGun(0)==true)
                    {
                        print("EMPTY");
                        gunList[0]=hit.transform.gameObject;
                        gunList[0].transform.SetParent(transform);
                        gunList[0].GetComponent<Collider>().enabled=false;
                        DeactivateWeapons();
                        gunList[0].SetActive(true);
                        pass();
                    }
                }
            }
        }
    }

    void SwitchWeapon(int i)
    {
        DeactivateWeapons();
        if (gunList[i] != null)
        {
            gunList[i].SetActive(true);
            print("switched weapon");
            pass();
        }

    }

    void DeactivateWeapons()
    {
        for(int i =0; i<gunList.Length; i++)
        {
            if(gunList[i]!=null)
            {
                gunList[i].SetActive(false);
            }
        }
    }

    bool CheckGun(int i)
    {
        if(gunList[i]!=null)
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
        else
        {
            return true;
        }

    }

    public void UpdateUI(float current, float loose, string name)
    {
        currAmountText.text=current.ToString("F0");
        looseAmountText.text=loose.ToString("F0");
        gunName.text=name;
    }


}
