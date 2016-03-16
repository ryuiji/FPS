using UnityEngine;
using System.Collections;

public class Moveupanddown : MonoBehaviour
{
    public Transform up;
    public Transform down;
    public float speed;
    public bool trigger;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (trigger == true)
        {
            print("mofoup");
            transform.position = Vector3.MoveTowards(transform.position,up.position,speed*Time.deltaTime);
        }
        else if(trigger==false)
        {
            print("mofodown");
            transform.position = Vector3.MoveTowards(transform.position, down.position, speed * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position,up.position)<0.1f)
        {
            trigger=false;
        }
        if (Vector3.Distance(transform.position, down.position) < 0.1f)
        {
            trigger = true;
        }
    }
}
