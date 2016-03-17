using UnityEngine;
using System.Collections;

public class MakeShiftHp : MonoBehaviour
{
    public int hp;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damageTaken)
    {
        hp-=damageTaken;
        if(hp<=0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
}
