using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addequip : MonoBehaviour
{
    public GameObject[] equipmentPrefabsS;
    public GameObject[] equipmentPrefabsA;
    public GameObject[] equipmentPrefabsB;
    public GameObject[] equipmentPrefabsC;
    public GameObject[] equipmentPrefabsD;
    public GameObject[] equipmentPrefabsE;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GenerateRandomEquipment();
        }
    }
    void GenerateRandomEquipment()
    {
        if (equipmentPrefabsS.Length == 0)
        {
            Debug.LogError("No equipment prefabs assigned.");
            return;
        }

        // �q�w�s��Ʋդ��H����ܤ@�ӹw�s��
        GameObject randomPrefab = equipmentPrefabsS[Random.Range(0, equipmentPrefabsS.Length)];

        // �b�������ͦ��襤���w�s��
        Instantiate(randomPrefab, transform.position, Quaternion.identity);
    }
}
