using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public Image collectionBar;
	private float collectionBarReduction;

	// Use this for initialization
	void Start () 
	{
		collectionBarReduction = 2000.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		collectionBar.fillAmount -= 1.0f / collectionBarReduction;
	}

	public Image GetCollectionBar()
	{
		return collectionBar;
	}
}
