using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject ground;
    public Transform generationPoint;
    public float distanceBetween;
    private float groundWidth;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    public ObjectPooler objectPool;
    
    void Start()
    {
        groundWidth = ground.GetComponent<BoxCollider2D>().size.x;
        
    }

    
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            transform.position = new Vector3(transform.position.x + groundWidth + distanceBetween, transform.position.y, transform.position.z);
            //Instantiate(ground, transform.position, transform.rotation);
            GameObject newObject = objectPool.GetPooledObject();
            newObject.transform.position = transform.position;
            newObject.transform.rotation = transform.rotation;
            newObject.SetActive(true);
        } 
        
    }
}
