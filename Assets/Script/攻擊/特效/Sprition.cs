using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sprition : MonoBehaviour
{
    public Texture[] images; // �x�s�Ϥ����Ʋ�
    public Image imageComponent; // Image �ե�

    private int currentIndex = 0; // �ثe��ܪ��Ϥ�����
    private bool isAnimating = false;

    void Start()
    {
        // �T�O images �Ʋդ����ŨåB�]�t�ܤ֤@�i�Ϥ�
        if (images != null && images.Length > 0)
        {
            // ��ܲĤ@�i�Ϥ�
            imageComponent.sprite = Sprite.Create((Texture2D)images[0], new Rect(0, 0, images[0].width, images[0].height), new Vector2(0.5f, 0.5f));
        }
        else
        {
            Debug.LogError("Images array is empty or null!");
        }

        // �ҰʹϤ����� Coroutine
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
            yield return new WaitForSeconds(0.05f); // ����1��

            // ������U�@�i�Ϥ�
            currentIndex = (currentIndex + 1) % images.Length;
            imageComponent.sprite = Sprite.Create((Texture2D)images[currentIndex], new Rect(0, 0, images[currentIndex].width, images[currentIndex].height), new Vector2(0.5f, 0.5f));
        }
    }
}
