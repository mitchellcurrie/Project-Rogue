using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroyer : MonoBehaviour {

	void Start () {

        float DestroyTime = GetComponent<ParticleSystem>().main.duration;
        Destroy(gameObject, DestroyTime);
        Debug.Log("Destroy Time = " + DestroyTime);
	}
}
