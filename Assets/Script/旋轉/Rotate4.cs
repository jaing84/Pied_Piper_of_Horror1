using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate4 : MonoBehaviour
{
    public float rotationSpeed = 5f; // 每秒旋轉的角度
    public float rotationInterval = 1f; // 旋轉間隔時間
    private float timer = 0f; // 計時器
    private bool isDecreasing = true; // 旋轉方向，true 表示角度減少，false 表示角度增加
    private float currentZRotation = 0f; // 用於手動追踪 z 軸的旋轉角度

    void Start()
    {
        // 初始化 z 軸旋轉角度
        currentZRotation = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= rotationInterval)
        {
            float rotationAngle = rotationSpeed * rotationInterval;

            if (isDecreasing)
            {
                currentZRotation -= rotationAngle;
                if (currentZRotation <= -25f)
                {
                    currentZRotation = -25f;
                    isDecreasing = false; // 改變方向
                }
            }
            else
            {
                currentZRotation += rotationAngle;
                if (currentZRotation >= 0f)
                {
                    currentZRotation = 0f;
                    isDecreasing = true; // 改變方向
                }
            }

            // 設置新的旋轉角度
            transform.rotation = Quaternion.Euler(0f, 0f, currentZRotation);

            // 重置計時器
            timer = 0f;
        }
    }
}
