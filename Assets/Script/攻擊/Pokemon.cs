using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    public string 怪物名;
    public int 攻擊;
    public int 新防禦;
    public int 防禦;
    public int 速度;
    public int 精神;
    public int 最大血量;
    public int 目前血量;
    public int 最大狂氣值;
    public int 目前狂氣值;
    public int 爆擊率;
    public int 爆擊傷害;
    public int 治癒;
    private bool isDefending = false;
    private bool isDefending1 = false;
    public int 初始速度值;

    void Start()
    {
        初始速度值 = 速度; // 在Start方法中初始化初始速度值為速度的初始值
    }
    public bool TakeDamage(int 攻擊, int 防禦)
    {
        if (isDefending && isDefending1)
        {
            防禦 *= (int)(1.1 * 2);
        }
        else if (isDefending1)
        {
            防禦 *= (int)(1.1);
        }
        else if (isDefending)
        {
            防禦 *= 2;
        }
        int 傷害 = 攻擊 - 新防禦;
        目前血量 -= 傷害;
        if (目前血量 <= 0)
            return true;
        else
            return false;
    }
    public bool TakeDamage1(int 攻擊, int 防禦)
    {
        if (isDefending && isDefending1)
        {
            防禦 *= (int)(1.1 * 2);
        }
        else if (isDefending1)
        {
            防禦 *= (int)(1.1);
        }
        else if (isDefending)
        {
            防禦 *= 2;
        }
        int 傷害 = (int)(攻擊 * 2.5 - 新防禦);
        目前血量 -= 傷害;
        if (目前血量 <= 0)
            return true;
        else
            return false;
    }
    public bool Takepuncture(int 攻擊)
    {
        int 傷害 = (int)(攻擊 * 0.2);
        目前血量 -= 傷害;
        if (目前血量 <= 0)
            return true;
        else
            return false;
    }

    public bool Defense(int 防禦)
    {
        if (isDefending1)
        {
            新防禦 = (int)(防禦 * 2 * 1.1);
            isDefending = true;
            return true;
        }
        else
        {
            新防禦 = 防禦 * 2;
            isDefending = true;
            return true;
        }
    }
    public bool Defense1(int 防禦)
    {
        if (isDefending)
        {
            新防禦 = (int)(防禦 * 1.1 * 2);
            isDefending1 = true;
            return true;
        }
        else
        {
            新防禦 = (int)(防禦 * 1.1);
            isDefending1 = true;
            return true;
        }
    }
    public bool MagicDamage(int 精神, int 防禦)
    {
        int 傷害 = 精神 * 2 - 防禦;

        if (目前血量 <= 0)
            return true;
        else
            return false;
    }
    public void 狂氣值(int 精神)
    {
        int 增加 = (int)(精神 * 0.25);
        目前狂氣值 += 增加;
    }

    public void forever(int 使用者速度, float 速度減益率)
    {
        int 回血 = (int)(使用者速度 * 1.5f);
        目前血量 += 回血;
        if (目前血量 > 最大血量)
            目前血量 = 最大血量;
        Debug.Log("生命回復: " + 回血 + ", 速度減益: " + (速度減益率 * 100) + "%");

    }

    public bool 治癒技能(int 治癒)

    {
        目前血量 += 治癒;
        if (目前血量 >= 最大血量)
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
            新防禦 = (int)(防禦 * 1.2);
        }
        else
        {
            新防禦 = 防禦;
        }
        isDefending = false;
    }
    public void CancelDefense1()
    {
        if (isDefending)
        {
            新防禦 = (防禦 * 2);
        }
        else
        {
            新防禦 = 防禦;
        }
        isDefending1 = false;
    }

}

