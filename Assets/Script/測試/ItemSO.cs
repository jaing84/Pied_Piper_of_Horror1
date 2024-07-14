using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new();
    public int amountToChangeStat;

    public AttributeToChange attributeToChange = new();
    public int amountToChangeAttrinute;


    public bool UseItem()
    {
        if(statToChange == StatToChange.health) 
        {
            
            PlayerHealth playerHealth = GameObject.Find("HealthManager").GetComponent<PlayerHealth>();
            if (playerHealth.health == playerHealth.maxHealth)
            {
                return false;
            }
            else
            {
                playerHealth.RestoreHealth(amountToChangeStat);
                return true;
            }
            
        }
        return false;
        // if (statToChange == StatToChange.mana)
        //{
        //    GameObject.Find("ManaManager").GetComponent<PlayerMana>().ChangeMana(amountToChangeStat);
        //}

    }
    public enum StatToChange
    {
        none,
        health,
        mana,
        stamina
    };

    public enum AttributeToChange
    {
        none,
        strength,
        defense,
        intelligence,
        agility
    };
}
