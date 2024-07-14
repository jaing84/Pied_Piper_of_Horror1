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
    public float Strength;             //力量
    public float Spirit;               //精神
    public float Constitution;         //體質 
    public float Agile;                //敏捷
    public float Luck;                 //幸運
    public float MagicAttack;          //魔攻 
    public float MagicDefense;         //魔防
    public float PhysicalAttack;       //物攻
    public float PhysicalDefense;      //物防
    public float Dodge;                //閃避 
    public float Speed;                //速度
    public float CriticalHit;          //暴擊
    public float Block;                //格擋
    public float Batter;               //連擊
    public float Counterattack;        //反擊

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
        // 假設每增加 1 點力量，物攻增加 5
        float strengthIncrease = 1f; // 每次增加的力量數量
        float physicalAttackIncrease = 5f; // 每次增加的物理攻擊數量

        // 增加力量
        Strength += strengthIncrease;

        // 根據每點力量增加的物理攻擊數量，更新物理攻擊
        PhysicalAttack += strengthIncrease * physicalAttackIncrease;
        Debug.Log("腳本 A 中的點擊事件已觸發！");
        UpdateStrengthText();
    }
    void UpdateStrengthText()
    {
        if (Strengthvalue != null)
        {
            // 將 Strength 的值轉換為字串，並更新到 UI 文本
            Strengthvalue.text = Strength.ToString();
            PhysicalAttackvalue.text = PhysicalAttack.ToString();
        }
        else
        {
            Debug.LogError("Strengthvalue is not assigned in the inspector!");
        }
    }
}
