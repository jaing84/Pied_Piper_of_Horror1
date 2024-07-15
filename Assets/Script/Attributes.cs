using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Attributes : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP;
    public float MaxHP = 100f;
    public float MP;
    public float MaxMP = 50f;
    public float Strength;             //??
    public float Spirit;               //蝎曄?
    public float Constitution;         //擃釭 
    public float Agile;                //?
    public float Luck;                 //撟賊?
    public float MagicAttack;          //擳 
    public float MagicDefense;         //擳
    public float PhysicalAttack;       //?拇
    public float PhysicalDefense;      //?拚
    public float Dodge;                //? 
    public float Speed;                //?漲
    public float CriticalHit;          //?湔?
    public float Block;                //?潭?
    public float Batter;               //???
    public float Counterattack;        //??

    public Text Strengthvalue;
    public Text Spiritvalue;
    public Text Constitutionvalue;
    public Text Agilevalue;
    public Text Luckvalue;
    public Text HPvalue;
    public Text MPvalue;
    public Text MagicAttackvalue;
    public Text MagicDefensevalue;
    public Text PhysicalAttackvalue;
    public Text PhysicalDefensevalue;
    public Text Dodgevalue;
    public Text Speedvalue;
    public Text CriticalHitvalue;
    public Text Blockvalue;
    public Text Battervalue;
    public Text Counterattackvalue;

    void Start()
    {
        HP = MaxHP;
        MP= MaxMP;
        Strengthvalue.text = Strength.ToString();
        Spiritvalue.text = Spirit.ToString();
        Constitutionvalue.text = Constitution.ToString();
        Agilevalue.text = Agile.ToString();
        Luckvalue.text = Luck.ToString();
        HPvalue.text = HP.ToString();
        MPvalue.text = MP.ToString();
        MagicAttackvalue.text = MagicAttack.ToString();
        PhysicalAttackvalue.text = PhysicalAttack.ToString();
        MagicDefensevalue.text = MagicDefense.ToString();
        PhysicalDefensevalue.text = PhysicalDefense.ToString();
        Dodgevalue.text = Dodge.ToString();
        Speedvalue.text = Speed.ToString();
        CriticalHitvalue.text = CriticalHit.ToString();
        Blockvalue.text = Block.ToString();
        Battervalue.text = Batter.ToString();
        Counterattackvalue.text = Counterattack.ToString();
    }


    public void AddStrength()
    {
        // ?身瘥???1 暺????拇憓? 5
        float strengthIncrease = 1f; // 瘥活憓??????
        float physicalAttackIncrease = 5f; // 瘥活憓??????

        // 憓???
        Strength += strengthIncrease;

        // ?寞?瘥???憓???????湔?拍??餅?
        PhysicalAttack += strengthIncrease * physicalAttackIncrease;
        Debug.Log("?單 A 銝剔?暺?鈭辣撌脰孛?潘?");
        UpdateStrengthText();
    }
    void UpdateStrengthText()
    {
        if (Strengthvalue != null)
        {
            // 撠?Strength ?潸??摮葡嚗蒂?湔??UI ?
            Strengthvalue.text = Strength.ToString();
            PhysicalAttackvalue.text = PhysicalAttack.ToString();
        }
        else
        {
            Debug.LogError("Strengthvalue is not assigned in the inspector!");
        }
    }
}

