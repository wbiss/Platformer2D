using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFinish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameMaster.isFinished = true;
        }
    }
}
