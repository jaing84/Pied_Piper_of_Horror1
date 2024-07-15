using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sprition : MonoBehaviour
{
    public Texture[] images; // 儲存圖片的數組
    public Image imageComponent; // Image 組件

    private int currentIndex = 0; // 目前顯示的圖片索引
    private bool isAnimating = false;

    void Start()
    {
        // 確保 images 數組不為空並且包含至少一張圖片
        if (images != null && images.Length > 0)
        {
            // 顯示第一張圖片
            imageComponent.sprite = Sprite.Create((Texture2D)images[0], new Rect(0, 0, images[0].width, images[0].height), new Vector2(0.5f, 0.5f));
        }
        else
        {
            Debug.LogError("Images array is empty or null!");
        }

        // 啟動圖片切換 Coroutine
        StartCoroutine(SwitchImages());
    }
    private void Update()
    {
        if (imageComponent.enabled)
        {
            isAnimating = true;
        }
        else
        {
            isAnimating = false;
        }

        if (!isAnimating)
        {
            StartCoroutine(SwitchImages());
        }
    }

    IEnumerator SwitchImages()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f); // 等待1秒

            // 切換到下一張圖片
            currentIndex = (currentIndex + 1) % images.Length;
            imageComponent.sprite = Sprite.Create((Texture2D)images[currentIndex], new Rect(0, 0, images[currentIndex].width, images[currentIndex].height), new Vector2(0.5f, 0.5f));
        }
    }
}

