using UnityEngine;
using System.Collections;

public class Pistol : GunAbstract {

    public override void Shoot()
    {
        print("firedPistol");
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
        gunManager.shoot = Shoot;
        gunManager.aim = Aim;
        gunManager.reload = Reload;
    }
}
