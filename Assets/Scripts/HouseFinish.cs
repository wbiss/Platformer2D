﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseFinish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")&& GameMaster.isCollected==true)
        {
            GameMaster.isFinished = true;
        }
    }
}
