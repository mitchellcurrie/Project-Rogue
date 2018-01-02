using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    [Tooltip("Between 0 and 10.")]
    public float collectionValue;
    public GameObject DestroyExplosionEffect;
    public GameObject CollectEffect;
    private Image collectionBar;
    private Floor floorPiece;

    // Use this for initialization
    void Start () 
	{
		collectionBar = FindObjectOfType<ItemManager> ().GetCollectionBar ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Floor>())
        {
            floorPiece = col.gameObject.GetComponent<Floor>();
            Debug.Log("Floor piece set");
        }

        else if (col.gameObject.GetComponent<PlayerInteraction>())
        {
            Destroy(this.gameObject);
            collectionBar.fillAmount += collectionValue / 10;
            if (collectionValue == 0)
            {
                Debug.LogError("Collection value set to 0!");
            }
        }

        else if (col.gameObject.GetComponent<Bomb>())
        {
            if (floorPiece)
            {
                col.gameObject.GetComponent<Bomb>().BlowUp();
            }


            if (floorPiece)
            {
                floorPiece.MoveDown(this.gameObject);
                floorPiece.SetFloorHasDropped(true);
                Destroy(col.gameObject);
                this.gameObject.SetActive(false);
            }

            if (col.gameObject.GetComponent<Item>())
            {
                Debug.Log("Bomb collision with Orb");
            }
        }

        else if (col.gameObject.GetComponent<Item>())
        {
            Destroy(col.gameObject);
            this.gameObject.SetActive(false);
            Debug.Log("Orb collision with Orb");
        }
    }

    public void Destroy()
    {
        if (DestroyExplosionEffect)
        {
            Instantiate(DestroyExplosionEffect, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
  
}
