using UnityEngine;
using System.Collections;

public class Gunmanage : MonoBehaviour
{
    public delegate void ShootGun();
    public ShootGun shoot;
    public delegate IEnumerator ReloadGun();
    public ReloadGun reload;
    public delegate void Aim();
    public Aim aim;
    public delegate void PassDelegates();
    public PassDelegates pass;
    public AK47 ak47;
    public Pistol pistol;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SwitchToAK();
        }

        if((Input.GetMouseButtonDown(1)))
        {
            SwitchToPistol();
        }

        if (Input.GetButtonDown("Jump") && shoot!=null)
        {
            shoot();
        }
    }

    void SwitchToAK()
    {
        pass = ak47.PassDelegates;
        pass();
    }

    void SwitchToPistol()
    {
        pass = pistol.PassDelegates;
        pass();
    }


}
