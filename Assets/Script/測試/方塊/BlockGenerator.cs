using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public GameObject[] blockPrefabs; // 包含所有可能方塊的預製體
    public KeyCode generateKey = KeyCode.B; // 生成方塊的按鍵
    public Transform playerTransform;
    public float minDistance = 3f; // 最小生成距離
    public float maxDistance = 5f; // 最大生成距離

    public float blockSpacing = 0.3f; // 方塊間距



    // Update 每一幀都會被調用
    void Update()
    {
        if (Input.GetKeyDown(generateKey))
        {
            GenerateBlock();
        }
    }

    void GenerateBlock()
    {
        // 隨機生成 3 到 6 個方塊
        int blockCount = Random.Range(3, 6);

        // 隨機選擇主要中心方塊
        int mainBlockIndex = Random.Range(0, blockCount);

        // 生成主要中心方塊
        Vector3 mainBlockPosition = GetRandomSpawnPosition();
        Instantiate(blockPrefabs[mainBlockIndex], mainBlockPosition, Quaternion.identity);

        // 生成指定數量的方塊
        for (int i = 0; i < blockCount; i++)
        {
            if (i != mainBlockIndex)
            {
                // 在x軸或y軸上設置偏移量
                float offsetX = 0f;
                float offsetY = 0f;
                if (Random.value < 0.5f) // 50%的概率在x軸上移動
                {
                    offsetX = Random.Range(-0.3f, 0.3f);
                }
                else // 50%的概率在y軸上移動
                {
                    offsetY = Random.Range(-0.3f, 0.3f);
                }

                // 生成其他方塊並根據偏移量調整位置
                Vector3 blockPosition = mainBlockPosition + new Vector3(offsetX * blockSpacing, offsetY * blockSpacing, 0f);
                Instantiate(blockPrefabs[i], blockPosition, Quaternion.identity);
            }
        }
    }
    Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized; // 隨機方向
        float randomDistance = Random.Range(minDistance, maxDistance); // 隨機距離
        Vector3 spawnPosition = playerTransform.position + new Vector3(randomDirection.x, randomDirection.y, 0f) * randomDistance; // 根據角色位置和隨機方向距離生成位置
        return spawnPosition;
    }
}







 
