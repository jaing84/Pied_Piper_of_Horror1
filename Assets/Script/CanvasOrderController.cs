using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasOrderController : MonoBehaviour
{
    public Canvas canvasA;

    void Start()
    {
        
        canvasA.overrideSorting = true;
        canvasA.sortingOrder = 1; 
    }
}
