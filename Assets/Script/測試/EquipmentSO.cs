using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EquipmentSO : ScriptableObject
{
    public string itemName;
    public int attack, defense, agility, intelligence,weight;

    [SerializeField]
    private Sprite itemSprite;

    public void PreviewEquipment() 
    {
       GameObject.Find("StatManager").GetComponent<PlayerStats>().
            PreviewEquipmentStats(attack, defense,agility ,intelligence,itemSprite,weight);
    }
   public void EquipItem()
    {
        
           //Update Stats
            PlayerStats playerstats = GameObject.Find("StatManager").GetComponent<PlayerStats>();
 
            playerstats.attack += attack;
            playerstats.defense += defense;
            playerstats.agility += agility;
            playerstats.intelligence += intelligence;
            playerstats.weight += weight;
            Debug.Log("¥[");
            playerstats.UpdateEquipmentStats();
     
    }

    // Update is called once per frame
    public void UnEquipItem()
    {
        //Update Stats
        PlayerStats playerstats = GameObject.Find("StatManager").GetComponent<PlayerStats>();
        playerstats.attack -= attack;
        playerstats.defense -= defense;
        playerstats.agility -= agility;
        playerstats.intelligence -= intelligence;
        playerstats.weight -= weight;
        Debug.Log("´î");
        playerstats.UpdateEquipmentStats();
    }
}
