using UnityEngine;
using System.Collections;

public class Recoil : MonoBehaviour
{
    public GameObject shakeObject;
    float shakeAmount = 0;
    // Use this for initialization

    
    public void Shake(float amt, float length)
    {
        shakeAmount = amt;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void DoShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = shakeObject.transform.position;
            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;

            shakeObject.transform.position = camPos;
        }
    }

    void StopShake()
    {
           CancelInvoke("DoShake");
        shakeObject.transform.localPosition = Vector3.zero;
    }
}
