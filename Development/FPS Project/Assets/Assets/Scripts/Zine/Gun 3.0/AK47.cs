using UnityEngine;
using System.Collections;

public class AK47 : GunAbstract
{

    public override void Shoot()
    {
        print("firedAk");
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
