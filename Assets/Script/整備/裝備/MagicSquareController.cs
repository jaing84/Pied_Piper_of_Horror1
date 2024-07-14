using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MagicSquareController : MonoBehaviour
{
    public GameObject prefab2;
    public Equip [] equips;
    public GameObject presetPrefab; // 預置體的Prefab
    public List<Transform> equipPositions;
    public Transform panelTransform; // Panel的Transform
    public Transform 背包;
    public float moveDistance = 50f; // 移動速度
    public GameObject 確認鍵;
    private bool canMove = true;
    public GameObject 點選件;
    public GameObject 確認鍵1;
    public GameObject airWall;
    public GameObject airWall1;
    public GameObject airWall2;
    public GameObject airWall3;
    private GameObject generatedPreset; // 生成的預置體
    public Image 大頭貼;
    public Image 替代物品圖片;
    public Image 空圖;
    public Text 名稱;
    public Text 名稱1;
    public Text 數值1;
    public Text 名稱2;
    public Text 數值2;
    public Text 右名稱;
    public Text 右數值1;
    public Text 右數值10;
    public Text 右數值2;
    public Text 右數值20;
    public int 右數值11 = 0;
    public int 右數值21 = 0;

    public PlayerValues playerValues;



    void Update()
    {
        // 如果生成了預置體，則啟用移動功能
        if (generatedPreset != null && canMove)
        {
            MovePreset();
        }
        if (generatedPreset != null && Input.GetKeyDown(KeyCode.Space) && canMove)
        {
            RotatePreset();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            AddBackpackSlot();
        }

    }
    public void 顯示() 
    {
        確認鍵.SetActive(true);
        點選件.SetActive(true);
        大頭貼.sprite = 替代物品圖片.sprite;
        名稱.text = "拼裝腎上腺素生成核心";
        名稱1.text = "精神";
        名稱2.text = "速度";
        數值1.text = "-50";
        數值2.text = "15";
    }
    public void 隱藏()
    {
        確認鍵.SetActive(false);
        點選件.SetActive(false);
        大頭貼.sprite = 空圖.sprite;
        名稱.text = "";
        名稱1.text = "";
        名稱2.text = "";
        數值1.text = "";
        數值2.text = "";
    }
    public void Generate()
    {
        if (generatedPreset == null)
        {
            // 在Panel內生成預置體
            generatedPreset = Instantiate(presetPrefab, panelTransform);
            // 將生成的預置體設置為UI元素
            generatedPreset.transform.SetParent(panelTransform, false); // 將父物件設置為Panel
            generatedPreset.GetComponent<RectTransform>().anchoredPosition = new Vector2(-19f, 57f); // 將錨點位置設置為(0, 0)
            確認鍵.SetActive(false);
            點選件.SetActive(false);
            大頭貼.sprite = 空圖.sprite;
            名稱.text = "";
            名稱1.text = "";
            名稱2.text = "";
            數值1.text = "";
            數值2.text = "";
        }
    }

    void MovePreset()
    {
        Vector3 targetPosition = generatedPreset.transform.position;
        if (Input.GetKeyDown(KeyCode.Z))
        {
           
            canMove = !canMove; // 切换 canMove 的状态
            AlignToBestPosition();
            右名稱.text = "拼裝腎上腺素生成核心";
            右數值1.text = "-50";
            右數值2.text = "15";
            右數值10.text = "-50";
            右數值20.text = "15";
            右數值11 = -50;
            右數值21 = 15;
            playerValues.裝備精神 = 右數值11;
            playerValues.裝備速度 = 右數值21;
            return;
        }
        // 检查是否将移动导致超出范围
       

        // 如果按下W鍵，向上移動預置體
        if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow))
        {
            targetPosition += Vector3.up * moveDistance;
        }
        // 如果按下S鍵，向下移動預置體
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            targetPosition += Vector3.down * moveDistance;
        }
        // 如果按下A鍵，向左移動預置體
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetPosition += Vector3.left * moveDistance;
        }
        // 如果按下D鍵，向右移動預置體
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetPosition += Vector3.right * moveDistance;
        }
  

        // 检查是否与空气墙碰撞
        if (!IsCollidingWithAirWall(targetPosition))
        {
            // 执行移动
            generatedPreset.transform.position = targetPosition;
        }
    }
    bool IsCollidingWithAirWall(Vector3 targetPosition)
    {
        if (airWall == null || generatedPreset == null)
        {
            return false;
        }

        // 获取预置体的Collider
        BoxCollider2D presetCollider = generatedPreset.GetComponent<BoxCollider2D>();

        // 检测预置体在目标位置是否与空气墙发生碰撞
        Collider2D collider = Physics2D.OverlapBox(targetPosition, presetCollider.size, 0);

        if (collider != null)
        {
            if (collider.gameObject == airWall ||
                collider.gameObject == airWall1 ||
                collider.gameObject == airWall2 ||
                collider.gameObject == airWall3)
            {
                Debug.LogWarning("碰到空气墙!");
                return true; // 发生碰撞，返回true
            }
        }

        return false; // 未发生碰撞，返回false
    }

    void RotatePreset()
    {
        if (generatedPreset != null)
        {
            // 将预置体绕着其正上方旋转90度
            generatedPreset.transform.Rotate(Vector3.forward, 90f);
        }
    }

    void AlignToBestPosition()
    {
        if (generatedPreset == null || equipPositions.Count == 0)
        {
            return;
        }

        List<Transform> overlappingTransforms = new List<Transform>();

        foreach (Transform equipPosition in equipPositions)
        {
            if (IsOverlapping(generatedPreset.GetComponent<Collider2D>(), equipPosition.GetComponent<Collider2D>()))

            {
                overlappingTransforms.Add(equipPosition);
            }
        }

        if (overlappingTransforms.Count == 0)
        {
            // 没有重叠的装备位置，直接返回
            return;
        }

        // 找到覆盖最多装备栏的位置
        Transform bestTransform = overlappingTransforms[0];
        float bestDistance = Vector3.Distance(generatedPreset.transform.position, bestTransform.position);

        foreach (Transform equipPosition in overlappingTransforms)
        {
            float distance = Vector3.Distance(generatedPreset.transform.position, equipPosition.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                bestTransform = equipPosition;
            }
        }

        // 计算预置体的中心位置，使其覆盖多个装备栏
        Vector3 targetPosition = CalculateCenterPosition(overlappingTransforms);

        // 将预置体移动到计算出的中心位置
        generatedPreset.transform.position = targetPosition;
    }

    Vector3 CalculateCenterPosition(List<Transform> transforms)
    {
        Vector3 center = Vector3.zero;
        foreach (Transform t in transforms)
        {
            center += t.position;
        }
        center /= transforms.Count;
        return center;
    }

    bool IsOverlapping(Collider2D presetCollider, Collider2D equipCollider)
    {
        return presetCollider.bounds.Intersects(equipCollider.bounds);
    }
    void AddBackpackSlot()
    {
        // 在背包父物件下生成新的背包格子
        GameObject newSlot = Instantiate(prefab2, 背包);
        // 將生成的背包格子設置為UI元素
        newSlot.transform.SetParent(背包, false);

        // 复制按钮组件及其事件处理器等属性
        Button newSlotButton = newSlot.GetComponent<Button>();
        if (newSlotButton != null)
        {
            // 假设你的原始背包格子有一个Button组件并设置了事件
            // 将原始按钮的事件处理器复制到新按钮上
            Button originalSlotButton = prefab2.GetComponent<Button>();
            if (originalSlotButton != null)
            {
                newSlotButton.onClick = originalSlotButton.onClick;
            }
        }

        // 隨機選擇一個裝備
        Equip randomEquip = equips[Random.Range(0, equips.Length)];

        // 將選中的裝備數據賦值給生成的背包格子
        // 假設你的背包格子有一個組件來處理裝備數據，比如EquipDisplay
        EquipDisplay equipDisplay = newSlot.GetComponent<EquipDisplay>();
        if (equipDisplay != null)
        {
            equipDisplay.SetEquipData(randomEquip);
        }
    }
    public void DestroyPreset()
    {
        Destroy(generatedPreset);
        generatedPreset = null;
        確認鍵.SetActive(false);
        canMove = true;
        點選件.SetActive(false);
        大頭貼.sprite = 空圖.sprite;
        名稱.text = "";
        名稱1.text = "";
        名稱2.text = "";
        數值1.text = "";
        數值2.text = "";
        右名稱.text = "";
        右數值1.text = "0";
        右數值2.text = "0";
        右數值10.text = "-50";
        右數值20.text = "15";
        右數值11 = 0;
        右數值21 = 0;
        playerValues.裝備精神 = 右數值11;
        playerValues.裝備速度 = 右數值21;
    }
}