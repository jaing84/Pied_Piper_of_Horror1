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

        // 從預製體數組中隨機選擇一個預製體
        GameObject randomPrefab = equipmentPrefabsS[Random.Range(0, equipmentPrefabsS.Length)];

        // 在場景中生成選中的預製體
        Instantiate(randomPrefab, transform.position, Quaternion.identity);
    }
}
