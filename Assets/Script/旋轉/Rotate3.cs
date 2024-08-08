using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate3 : MonoBehaviour
{
    public float rotationSpeed = 150f;
    public float rotationInterval = 1f;
    private float timer = 0f;
    private bool isIncreasing = true;
    void Start()
    {

    }

   
    void Update()
    {
        //   Debug.Log("1");
        //  Debug.Log(timer);
        timer += Time.deltaTime;
        if (timer >= rotationInterval)
        {
          
            float rotationAngle = rotationSpeed * rotationInterval;
            Vector3 currentRotation = transform.rotation.eulerAngles;

           
            if (isIncreasing)
            {
                currentRotation.z += rotationAngle;
                if (currentRotation.z >= 25f)
                {
                    currentRotation.z = 25f; 
                    isIncreasing = false; 
                }
            }
            else 
            {
                currentRotation.z -= rotationAngle;
                if (currentRotation.z <= 0f)
                {
                    currentRotation.z = 0f; 
                    isIncreasing = true; 
                }
            }

            
            transform.rotation = Quaternion.Euler(currentRotation);

            
            timer = 0f;
        }

    }
}
