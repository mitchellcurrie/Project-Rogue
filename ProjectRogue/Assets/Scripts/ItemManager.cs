using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public Image collectionBar;
    public GameObject[] Orbs;
    public GameObject Bomb;

    public float orbSpawnTime; 
    private float orbTimer;

    public float bombSpawnTime;
    private float bombTimer;
    
    private FloorManager FManager;
    public float collectionBarReduction;
    private float dropHeight = 10.0f;

    // Use this for initialization
    void Start () 
	{
        FManager = FindObjectOfType<FloorManager>();
    }
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		collectionBar.fillAmount -= 1.0f / collectionBarReduction;

        if (collectionBar.fillAmount == 0.0f)
        {
            //GameManager.SetCauseOfDeath(GameManager.CauseOfDeath.TIME);
            //GameManager.GameOver();
        }

        // Orb Timing
        orbTimer += Time.deltaTime;

        if (orbTimer > orbSpawnTime)
        {
            SpawnOrb();
            orbTimer = 0.0f;
        }

        // Bomb timing
        bombTimer += Time.deltaTime;

        if (bombTimer > bombSpawnTime)
        {
            SpawnBomb();
            bombTimer = 0.0f;
        }
    }

	public Image GetCollectionBar()
	{
		return collectionBar;
	}

    public void SpawnOrb()
    {
        if (FManager.IsAvailableFloorPosition())
        {
            int randomOrb = Random.Range(0, Orbs.Length);
            Vector3 spawnLocation = FManager.GetRandomFloorPosition() + new Vector3(0, dropHeight, 0);
            Instantiate(Orbs[randomOrb], spawnLocation, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
        }        
    }

    void SpawnBomb()
    {
        if (FManager.IsAvailableFloorPosition())
        {
            Vector3 spawnLocation = FManager.GetRandomFloorPosition() + new Vector3(0, dropHeight, 0);
            Instantiate(Bomb, spawnLocation, Quaternion.Euler(0.0f, Random.Range(0, 360), 0.0f));
        }
    }
}
