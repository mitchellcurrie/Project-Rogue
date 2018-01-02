using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public Image collectionBar;
    public GameObject[] Orbs;
    public float orbSpawnTime;
    private FloorManager FManager;
    private float orbTimer;
    private float collectionBarReduction;
    private float dropHeight = 10.0f;

    // Use this for initialization
    void Start () 
	{
		collectionBarReduction = 2000.0f;
        FManager = FindObjectOfType<FloorManager>();
    }
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		collectionBar.fillAmount -= 1.0f / collectionBarReduction;

        orbTimer += Time.deltaTime;

        if (orbTimer > orbSpawnTime)
        {
            SpawnOrb();
            orbTimer = 0.0f;
        }
    }

	public Image GetCollectionBar()
	{
		return collectionBar;
	}

    public void SpawnOrb()
    {
        int randomOrb = Random.Range(0, Orbs.Length);
        Vector3 spawnLocation = FManager.GetRandomFloorPosition() + new Vector3(0, dropHeight, 0);
        Instantiate(Orbs[randomOrb], spawnLocation, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
    }
}
