using UnityEngine;
using System.Collections;

public class KeyPartSpawn : MonoBehaviour {

    public GameObject[] spawnKey;
    public GameObject keyPart;
    private int maxSpawn;

    void Start () {

        

        InvokeRepeating("RandomKeySpawn", 0, 1);

    }
    void RandomKeySpawn() {
        while(maxSpawn < 3) {
            Instantiate(keyPart, spawnKey[Random.Range(0, spawnKey.Length)].transform.position, Quaternion.identity);
            maxSpawn++;

        }
        Destroy(gameObject);
    }

    void Update() {

    }
}
