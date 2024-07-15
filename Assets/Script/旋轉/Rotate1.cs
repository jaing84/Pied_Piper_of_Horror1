using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate1 : MonoBehaviour
{
    
    public float rotationSpeed = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationAngle = rotationSpeed * Time.deltaTime;
        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.z -= rotationAngle;
        if (currentRotation.z <= -360f)
        {
            currentRotation.z += 360f;
        }
        transform.rotation = Quaternion.Euler(currentRotation);
    }
}

