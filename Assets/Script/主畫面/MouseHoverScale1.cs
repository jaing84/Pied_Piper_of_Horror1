using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHoverScale1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // 原始的缩放比例
    private Vector3 originalScale;
    // 放大的比例
    public float scaleFactor = 1.2f;

    void Start()
    {
        // 保存对象的原始缩放比例
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 当鼠标移到对象上时，放大对象
        transform.localScale = originalScale * scaleFactor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 当鼠标移出对象时，恢复原始比例
        transform.localScale = originalScale;
    }
}