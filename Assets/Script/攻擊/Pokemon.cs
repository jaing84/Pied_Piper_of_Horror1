using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    public string �Ǫ��W;
    public int ����;
    public int �s���m;
    public int ���m;
    public int �t��;
    public int �믫;
    public int �̤j��q;
    public int �ثe��q;
    public int �̤j�g���;
    public int �ثe�g���;
    public int �z���v;
    public int �z���ˮ`;
    public int �v¡;
    private bool isDefending = false;
    private bool isDefending1 = false;
    public int ��l�t�׭�;

    void Start()
    {
        ��l�t�׭� = �t��; // �bStart��k����l�ƪ�l�t�׭Ȭ��t�ת���l��
    }
    public bool TakeDamage(int ���� , int ���m)
    {
        if (isDefending && isDefending1)
        {
            ���m *= (int)(1.1 * 2);
        }
        else if (isDefending1 ) 
        {
            ���m *= (int)(1.1);
        }
        else if (isDefending ) 
        {
            ���m *= 2;
        }
        int �ˮ` = ���� - �s���m;
        �ثe��q -= �ˮ`;
        if (�ثe��q <= 0)
            return true;
        else
            return false;
    }
    public bool TakeDamage1(int ����, int ���m)
    {
        if (isDefending && isDefending1)
        {
            ���m *= (int)(1.1 * 2);
        }
        else if (isDefending1)
        {
            ���m *= (int)(1.1);
        }
        else if (isDefending)
        {
            ���m *= 2;
        }
        int �ˮ` = (int)(���� * 2.5 - �s���m); 
        �ثe��q -= �ˮ`;
        if (�ثe��q <= 0)
            return true;
        else
            return false;
    }
    public bool Takepuncture(int ����) 
    {
        int �ˮ` = (int)(���� * 0.2);
        �ثe��q -= �ˮ`;
        if (�ثe��q <= 0)
            return true;
        else
            return false;
    }

    public bool Defense(int ���m) 
    {
        if (isDefending1)
        {
            �s���m = (int)(���m * 2*1.1);
            isDefending = true;
            return true;
        }
        else 
        {
            �s���m = ���m * 2;
            isDefending = true;
            return true;
        }
    }
    public bool Defense1(int ���m)
    {
        if (isDefending)
        {
            �s���m = (int)(���m * 1.1*2);
            isDefending1 = true;
            return true;
        }
        else 
        {
            �s���m = (int)(���m * 1.1);
            isDefending1 = true;
            return true;
        }
    }
    public bool MagicDamage(int �믫, int ���m)
    {
        int �ˮ` = �믫*2 - ���m;

        if (�ثe��q <= 0)
            return true;
        else
            return false;    
    }
    public void �g���(int �믫)
    {
        int �W�[ = (int)(�믫 * 0.25);
        �ثe�g��� += �W�[;
    }
    
    public void forever(int �ϥΪ̳t�� , float �t�״�q�v) 
    {
        int �^�� = (int)(�ϥΪ̳t�� * 1.5f);
        �ثe��q += �^��;
        if(�ثe��q>�̤j��q) 
            �ثe��q = �̤j��q;
        Debug.Log("�ͩR�^�_: " + �^�� + ", �t�״�q: " + (�t�״�q�v * 100) + "%");

    }
 
    public bool �v¡�ޯ�(int �v¡)

    {
        �ثe��q += �v¡;
        if(�ثe��q>= �̤j��q)
           return true;
        else 
            return false;
    }
    public bool IsDefending()
    {
        return isDefending;
    }
    public bool IsDefending1()
    {
        return isDefending1;
    }
    public void CancelDefense()
    {
        if (isDefending1)
        {
            �s���m = (int)(���m*1.2);
        }
        else 
        {
            �s���m = ���m;
        }
        isDefending = false;
    }
    public void CancelDefense1()
    {
        if (isDefending)
        {
            �s���m = (���m * 2);
        }
        else
        {
            �s���m = ���m;
        }
        isDefending1 = false;
    }
}
