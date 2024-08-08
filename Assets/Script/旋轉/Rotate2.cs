using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2 : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float rotationInterval = 1f; 
    private float timer = 0f; 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     //   Debug.Log("1");
      //  Debug.Log(timer);
        timer += Time.deltaTime;
        if (timer >= rotationInterval)
        {
            
            float rotationAngle = rotationSpeed * Time.deltaTime;
            Vector3 currentRotation = transform.rotation.eulerAngles;
            currentRotation.z -= rotationAngle;
            if (currentRotation.z <= -360f)
            {
                currentRotation.z += 360f;
            }
            transform.rotation = Quaternion.Euler(currentRotation);
            timer = 0f;
        }
        
    }
}
