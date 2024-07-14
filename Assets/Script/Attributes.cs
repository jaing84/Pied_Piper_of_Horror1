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
    public float Strength;             //�O�q
    public float Spirit;               //�믫
    public float Constitution;         //��� 
    public float Agile;                //�ӱ�
    public float Luck;                 //���B
    public float MagicAttack;          //�]�� 
    public float MagicDefense;         //�]��
    public float PhysicalAttack;       //����
    public float PhysicalDefense;      //����
    public float Dodge;                //�{�� 
    public float Speed;                //�t��
    public float CriticalHit;          //����
    public float Block;                //���
    public float Batter;               //�s��
    public float Counterattack;        //����

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
        // ���]�C�W�[ 1 �I�O�q�A����W�[ 5
        float strengthIncrease = 1f; // �C���W�[���O�q�ƶq
        float physicalAttackIncrease = 5f; // �C���W�[�����z�����ƶq

        // �W�[�O�q
        Strength += strengthIncrease;

        // �ھڨC�I�O�q�W�[�����z�����ƶq�A��s���z����
        PhysicalAttack += strengthIncrease * physicalAttackIncrease;
        Debug.Log("�}�� A �����I���ƥ�wĲ�o�I");
        UpdateStrengthText();
    }
    void UpdateStrengthText()
    {
        if (Strengthvalue != null)
        {
            // �N Strength �����ഫ���r��A�ç�s�� UI �奻
            Strengthvalue.text = Strength.ToString();
            PhysicalAttackvalue.text = PhysicalAttack.ToString();
        }
        else
        {
            Debug.LogError("Strengthvalue is not assigned in the inspector!");
        }
    }
}
