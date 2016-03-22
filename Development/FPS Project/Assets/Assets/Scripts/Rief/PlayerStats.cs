using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public float hp;
    public float maxHp;
    public float sanity;
    public float maxSanity;

	void Start () {
        hp = maxHp;
        sanity = maxSanity;
	}
    void Update() {
        CheckHealth();
        CheckSanity();
    }

	void CheckHealth () {
	    if(hp >= maxHp) {
            hp = maxHp;
        }
        if(hp <= 0) {
            Die();
        }
	}
    void CheckSanity() {
        if(sanity >= maxSanity) {
            sanity = maxSanity;
        }
        if(sanity <= 0) {
            //doe iets
        }
    }
    void Die() {
        Destroy(gameObject, 5);
    }
}
