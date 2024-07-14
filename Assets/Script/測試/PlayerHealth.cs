using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 50.0f;
    public float maxHealth = 40.0f;
    public float damageAmount = 10.0f;
    public RectTransform rectTransform;

    public Text healthText;
    public Text healthText2;


    private void Start()
    {
        // �b Start ��k����l�� healthText
      //  healthText = GetComponent<Text>();

        if (healthText == null)
        {
            Debug.LogError("Text component not found on the object!");
        }

    }

    public void RestoreHealth(int amount)
    {
        health += amount;
        health = Mathf.Min(health, maxHealth); // �T�O���d�Ȥ��W�L�̤j��
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // �ˬd��q�O�_�j�� 0�A�H�T�O���|�����W�L�̤p�Ȫ���q
            if (health > 0)
            {
                // ������q
                health -= damageAmount;

                // �T�O��q���|�p�� 0
                health = Mathf.Max(health, 0);
            }
        }

        if (maxHealth > 0)
        {
            // �]�m rectTransform �� scale
            float newScaleX = health / maxHealth;
            Vector3 newScale = rectTransform.localScale;
            newScale.x = newScaleX;
            rectTransform.localScale = newScale;
        }

        // ��s UI �奻
        healthText.text = health + "/" + maxHealth;
        healthText2.text = health + "/" + maxHealth;

        
    }
}
