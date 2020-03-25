﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public Transform generationPoint;
    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    public ObjectPooler[] objectPools;    
    private int groundSelector;
    private float[] groundsWidth;
    void Start()
    {
        groundsWidth = new float[objectPools.Length];

        for (int i = 0; i < objectPools.Length; i++)
        {
            groundsWidth[i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        
    }

    
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            groundSelector = Random.Range(0, objectPools.Length);
            transform.position = new Vector3(transform.position.x + (groundsWidth[groundSelector]/2) + distanceBetween, transform.position.y, transform.position.z);
            GameObject newObject = objectPools[groundSelector].GetPooledObject();
            newObject.transform.position = transform.position;
            newObject.transform.rotation = transform.rotation;
            newObject.SetActive(true);
            transform.position = new Vector3(transform.position.x + (groundsWidth[groundSelector] / 2), transform.position.y, transform.position.z);

        } 
        
    }
}
