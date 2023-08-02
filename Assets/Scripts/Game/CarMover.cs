using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    public float moveSpeed = 2f;

    private void Update()
    {
        
        Vector3 forwardDirection = transform.TransformDirection(Vector3.forward);
        transform.position += forwardDirection * moveSpeed * Time.deltaTime;
    
      
    }
}
