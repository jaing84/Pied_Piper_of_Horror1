using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresetCollisionController : MonoBehaviour
{
    public GameObject 確認鍵1; // UI元素
    public RectTransform 被碰觸物體; // 被碰触的物体的RectTransform
    public string presetTag = "squite"; // 預置體的標籤
    private bool isOverlapping = false;

    void Start()
    {
        // 初始化时隐藏UI元素
        確認鍵1.SetActive(false);
    }

    void Update()
    {
        CheckForOverlap();
    }

    void CheckForOverlap()
    {
        // 获取场景中所有带有指定标签的预制体
        GameObject[] presets = GameObject.FindGameObjectsWithTag(presetTag);
        isOverlapping = false;

        foreach (GameObject preset in presets)
        {
            // 如果发现重叠的预制体，则显示确认按钮并退出循环
            if (preset != gameObject && IsOverlapping(preset))
            {
                isOverlapping = true;
                break;
            }
        }

        // 根据重叠情况显示或隐藏确认按钮
        確認鍵1.SetActive(isOverlapping);
    }

    bool IsOverlapping(GameObject other)
    {
        // 使用预制体的碰撞框检查是否重叠
        Collider2D coll = GetComponent<Collider2D>();
        Collider2D otherColl = other.GetComponent<Collider2D>();

        if (coll == null || otherColl == null)
        {
            return false;
        }

        return coll.bounds.Intersects(otherColl.bounds);
    }
}
