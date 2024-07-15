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

        // 敺?鋆賡??貊?銝剝璈????鋆賡?
        GameObject randomPrefab = equipmentPrefabsS[Random.Range(0, equipmentPrefabsS.Length)];

        // ?典?臭葉???訾葉??鋆賡?
        Instantiate(randomPrefab, transform.position, Quaternion.identity);
    }
}

