﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCharacterFollow : MonoBehaviour
{
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = playerTransform.position.x;
        playerTransform.position = temp;
    }
}
