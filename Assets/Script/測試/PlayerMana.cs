using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public int mana = 10;

    public void ChangeMana(int amount)
    {
        mana += amount;
    }
}
