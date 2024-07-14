using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public GameObject[] blockPrefabs; // �]�t�Ҧ��i�������w�s��
    public KeyCode generateKey = KeyCode.B; // �ͦ����������
    public Transform playerTransform;
    public float minDistance = 3f; // �̤p�ͦ��Z��
    public float maxDistance = 5f; // �̤j�ͦ��Z��

    public float blockSpacing = 0.3f; // ������Z



    // Update �C�@�V���|�Q�ե�
    void Update()
    {
        if (Input.GetKeyDown(generateKey))
        {
            GenerateBlock();
        }
    }

    void GenerateBlock()
    {
        // �H���ͦ� 3 �� 6 �Ӥ��
        int blockCount = Random.Range(3, 6);

        // �H����ܥD�n���ߤ��
        int mainBlockIndex = Random.Range(0, blockCount);

        // �ͦ��D�n���ߤ��
        Vector3 mainBlockPosition = GetRandomSpawnPosition();
        Instantiate(blockPrefabs[mainBlockIndex], mainBlockPosition, Quaternion.identity);

        // �ͦ����w�ƶq�����
        for (int i = 0; i < blockCount; i++)
        {
            if (i != mainBlockIndex)
            {
                // �bx�b��y�b�W�]�m�����q
                float offsetX = 0f;
                float offsetY = 0f;
                if (Random.value < 0.5f) // 50%�����v�bx�b�W����
                {
                    offsetX = Random.Range(-0.3f, 0.3f);
                }
                else // 50%�����v�by�b�W����
                {
                    offsetY = Random.Range(-0.3f, 0.3f);
                }

                // �ͦ���L����îھڰ����q�վ��m
                Vector3 blockPosition = mainBlockPosition + new Vector3(offsetX * blockSpacing, offsetY * blockSpacing, 0f);
                Instantiate(blockPrefabs[i], blockPosition, Quaternion.identity);
            }
        }
    }
    Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized; // �H����V
        float randomDistance = Random.Range(minDistance, maxDistance); // �H���Z��
        Vector3 spawnPosition = playerTransform.position + new Vector3(randomDirection.x, randomDirection.y, 0f) * randomDistance; // �ھڨ����m�M�H����V�Z���ͦ���m
        return spawnPosition;
    }
}







 