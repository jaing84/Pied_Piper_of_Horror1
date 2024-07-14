using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipDisplay : MonoBehaviour
{

    public Text equipName; // 用于展示装备名称的UI组件
    public Text equipDescription; // 用于展示装备描述的UI组件

    public void SetEquipData(Equip equip)
    {
        if (equip == null) return;

        // 假设装备有一个图片字段，如果没有，你可以添加一个Sprite字段到Equip类中

        equipName.text = equip.名稱; // 设置装备名称
        equipDescription.text = equip.敘述; // 设置装备描述
    }
}
