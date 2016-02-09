using UnityEngine;
using System.Collections;

public class Recoil : MonoBehaviour
{
    public GameObject shakeObject;
    float shakeAmount = 0;
    // Use this for initialization

    public void StartShake(float amt, float length)
    {
        StartCoroutine(Shake(amt,length));
    }
    
    public IEnumerator Shake(float amt, float length)
    {
        shakeAmount = amt;
        DoShake();
        yield return new WaitForSeconds(length);
        StopShake();
    }

    void DoShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = shakeObject.transform.position;
            //float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            //camPos.x += offsetX;
            camPos.y += offsetY;

            shakeObject.transform.position = camPos;
        }
    }

    void StopShake()
    {
        shakeObject.transform.localPosition = Vector3.zero;
    }
}
