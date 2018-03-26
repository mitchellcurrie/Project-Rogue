using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Bomb>())
        {
            Destroy(col.gameObject);
        }

        else if (col.gameObject.GetComponent<Item>())
        {
            Destroy(col.gameObject);
        }

        else if (col.gameObject.GetComponent<PlayerInteraction>())
        {
            //GameManager.GameOver();
        }
    }

}
