using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show2 : MonoBehaviour
{
    public GameObject show11;

    private void Update()
    {
        if (show11 != null)
        {
            if (Input.GetMouseButtonDown(1))
            {

                show11.SetActive(false);
            }
        }
    }
}

