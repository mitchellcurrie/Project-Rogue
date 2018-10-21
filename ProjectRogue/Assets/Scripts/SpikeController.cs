using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour {
	private Spike[] spikes;
	private float waitTime = 5.0f;
	// Use this for initialization
	void Start () {

		spikes = GetComponentsInChildren<Spike>();

		if (spikes.Length == 0)
		{
			Debug.LogError("No spikes found by spike controller");
		}

		StartCoroutine("LoweringCoroutine");
	}
	
	void LowerRandomSpike()
	{
		int randomIndex = Random.Range(0, spikes.Length-1);
		spikes[randomIndex].isLowering = true;
	}

	IEnumerator LoweringCoroutine()
	{
		LowerRandomSpike();
		
		yield return new WaitForSeconds(waitTime);

		StartCoroutine("LoweringCoroutine");
	}
}
