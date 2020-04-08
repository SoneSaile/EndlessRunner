using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleObject : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = target.position;
        newPosition.z = transform.position.z;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
