using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject targetUIElement;


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (targetUIElement != null)
        {
            targetUIElement.SetActive(true);
        }
    }

  
    public void OnPointerExit(PointerEventData eventData)
    {
        if (targetUIElement != null)
        {
            targetUIElement.SetActive(false);
        }
    }
}
