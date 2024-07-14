using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // �I�]�B�˳ơB���
    public GameObject InventoryMenu;
    public GameObject EquipmentMenu;
    public GameObject EscMenu;
    
   
   //�I�]��l�B���~��T�B�˳Ʈ�l�B�˳Ʈ�l�}�C
    public ItemSlot[] itemSlot;
    public ItemSO[] itemSOs;
    public EquipmentSlot[] equipmentSlot;
    public EquippedSlot[] equippedSlot;


    
    void Update()
    {
      //  if (Input.GetButtonDown("InventoryMenu"))
        //    Inventory();
       // if (Input.GetButtonDown("EquipmentMenu"))
         //  Equipment();
       // if (Input.GetButtonDown("ESC"))
         //   Esc();

    }

    void Inventory()
    {
        if (EscMenu.activeSelf)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);

        }
        else if (InventoryMenu.activeSelf)   //activeSelf �ھڪ���O�_�B�󬡰ʪ��A�Ǧ^ true �� false ��    
        
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            EquipmentMenu.SetActive(false);
        }
    }
    void Equipment()
    {
        if (EscMenu.activeSelf)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);

        }

        else if (EquipmentMenu.activeSelf)   //activeSelf �ھڪ���O�_�B�󬡰ʪ��A�Ǧ^ true �� false ��    

        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(true);
        }
    }

    public void Esc() 
    {
        if (EquipmentMenu.activeSelf || InventoryMenu.activeSelf)   //activeSelf �ھڪ���O�_�B�󬡰ʪ��A�Ǧ^ true �� false ��    

        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
        }
        else if (EscMenu.activeSelf) 
        {
            Time.timeScale = 1;
            EscMenu.SetActive(false);
        }
        
        else
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(false);
            EscMenu.SetActive(true);
            EquipmentMenu.SetActive(false);
        }

    }
    //�ϥΪ��~����k
    public bool UseItem(string itemName) 
    {
       for(int i = 0; i<itemSOs.Length; i++) 
        {
            if (itemSOs[i].itemName == itemName) 
            {
                
                bool usable = itemSOs[i].UseItem();
                
                return usable;
            }        
        } 
        return false;    
    }
    // �W�[���~��I�]�θ˳��檺��k  
    public int AddItem(string itemName, int quantity, Sprite itemSprite,string itemDescription, ItemType itemType)
    {
        if(itemType == ItemType.consumable || itemType == ItemType.crafting || itemType == ItemType.collectible)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
                {
                    int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemType);
                    if (leftOverItems > 0)
                        leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemType);


                    return leftOverItems;
                }
            }
            return quantity;
        }
        else 
        {
            for (int i = 0; i < equipmentSlot.Length; i++)
            {
                if (equipmentSlot[i].isFull == false && equipmentSlot[i].itemName == itemName || equipmentSlot[i].quantity == 0)
                {
                    int leftOverItems = equipmentSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemType);
                    if (leftOverItems > 0)
                        leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemType);


                    return leftOverItems;
                }
            }
            return quantity;
        }
        
    }
    // ������ܩҦ��I�]�M�˳Ʈ�l����k
    public void DeselectAllSlots()
    {
        for (int i = 0; i<itemSlot.Length; i++) 
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
        for (int i = 0; i < equipmentSlot.Length; i++)
        {
            equipmentSlot[i].selectedShader.SetActive(false);
            equipmentSlot[i].thisItemSelected = false;
        }
        for (int i = 0; i < equippedSlot.Length; i++)
        {
            equippedSlot[i].selectedShader.SetActive(false);
            equippedSlot[i].thisItemSelected = false;
        }

    }


    public enum ItemType 
    {
      consumable,
      crafting,
      collectible,
      head,
      cloak,
      body,
      legs,
      mainHand,
      offHand,
      relic,
      feet,
      none,
      item
    };

    public void QuitGame()
    {
        Application.Quit();
    }
}
