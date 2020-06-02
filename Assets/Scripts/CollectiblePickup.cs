using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePickup : MonoBehaviour
{
    private bool alreadyScored;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (alreadyScored) 
                return;
            alreadyScored = true;
            gameObject.SetActive(false);
            GameMaster.CollectedItems +=1;
        }
    }
}
