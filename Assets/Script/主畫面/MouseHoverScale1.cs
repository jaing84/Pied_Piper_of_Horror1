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
    public AudioData projectadio;
    void Start()
    {
        // 保存对象的原始缩放比例
        originalScale = transform.localScale;
        if (projectadio == null)
        {
            Debug.LogWarning("projectadio 沒有賦值，請在 Inspector 中設置它");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 当鼠标移到对象上时，放大对象
        transform.localScale = originalScale * scaleFactor;
        if (AudioManager.Instance == null)
        {
            Debug.LogError("AudioManager.Instance 為 null，請確保 AudioManager 正確初始化");
            return;
        }
        if (projectadio != null)
        {
            AudioManager.Instance.PlaySFX(projectadio);
        }
        else
        {
            Debug.LogError("projectadio 為 null，無法播放音效");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 当鼠标移出对象时，恢复原始比例
        transform.localScale = originalScale;
    }
}
