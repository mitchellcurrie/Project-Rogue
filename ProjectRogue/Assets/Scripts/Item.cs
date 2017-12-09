using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

	private Image collectionBar;
	public float collectionValue;

	// Use this for initialization
	void Start () 
	{
		collectionBar = FindObjectOfType<ItemManager> ().GetCollectionBar ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.GetComponent<PlayerInteraction>())
		{
			Destroy (this);
			collectionBar.fillAmount += 1.0f / collectionValue;
		}
	}
}
