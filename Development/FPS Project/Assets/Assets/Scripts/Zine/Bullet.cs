using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public GameObject bulletImpact;
    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity=transform.forward*speed;
        if(Physics.Raycast(transform.position,transform.forward,1))
        {
            print("hit");
            Instantiate(bulletImpact, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

}
