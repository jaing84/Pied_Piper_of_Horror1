using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel;
using UnityEngine.EventSystems;
using static InventoryManager;
using System;

//using UnityEngine.UIElements;

public class EquippedSlot : MonoBehaviour, IPointerClickHandler
{
    //SLOT APPEARANCE//
    [SerializeField]
    private Image slotImage;
    [SerializeField]
    private Text slotName;
    public bool istull;
    
    
    public PlayerStats playerStats;
  

    

    //SLOT DATA//
    [SerializeField]
    private ItemType itemType = new ();
    

    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;

    private InventoryManager inventoryManager;
    private EquipmentSOLibrary equipmentSOLibrary;

 
    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        equipmentSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<EquipmentSOLibrary>();
        playerStats = GameObject.Find("StatManager").GetComponent<PlayerStats>();
        istull = slotImage.sprite == emptySprite;
        
    }

    //OTHER VARIABLES//
    private bool slotInUse;
    
    public GameObject selectedShader;

    
    public bool thisItemSelected;

    [SerializeField]
    private Sprite emptySprite;
    public void OnPointerClick(PointerEventData eventData) 
    {
        if(eventData.button == PointerEventData.InputButton.Left) 
        {
            OnLeftClick();
        }
        if(eventData.button == PointerEventData.InputButton.Right) 
        {
            OnRightClick();
        }
    }

    void OnLeftClick()
    {

        if (playerStats.maxweight >= playerStats.weight)
        {
            if (thisItemSelected && slotInUse)
                UnEquipGear();
            else
            {
                inventoryManager.DeselectAllSlots();
                selectedShader.SetActive(true);
                thisItemSelected = true;
                for (int i = 0; i < equipmentSOLibrary.equipmentSO.Length; i++)
                {
                    if (equipmentSOLibrary.equipmentSO[i].itemName == this.itemName)
                        equipmentSOLibrary.equipmentSO[i].PreviewEquipment();
                }
            }
        }
     }
 
    void OnRightClick() 
    {

        if (itemName != null)  // 檢查是否已經裝備了物品
        {
            UnEquipGear();
        }
    }
    public void EquipGear(Sprite itemSprite, string itemName,string itemDescription) 
    {
     
        if (slotInUse && this.itemName == itemName)
            {
                Debug.Log("Already equipped.");
                return;
            }

            //If SOMETIGN IS ALREADY EQUIPPED, send it vefore re-writing the data for this slot
            if (slotInUse)
                UnEquipGear();

        PlayerStats playerstats = GameObject.Find("StatManager").GetComponent<PlayerStats>();

        //Update Image
        this.itemSprite = itemSprite;
            slotImage.sprite = this.itemSprite;
            istull = true;
            slotName.enabled = false;
            //  isFull = true;



            //Update Data
            this.itemName = itemName;
            this.itemDescription = itemDescription;

        //Update player Stats
        for (int i = 0; i < equipmentSOLibrary.equipmentSO.Length; i++)
            {
              
               if (equipmentSOLibrary.equipmentSO[i].itemName == this.itemName)
               {
                

                    equipmentSOLibrary.equipmentSO[i].EquipItem();
                Debug.Log("測試一" + i+ "/"+playerstats.weight);
                    if ((playerstats.weight) > playerstats.maxweight)
                    {
                        // If it exceeds, revert the changes and inform the player
                        Debug.Log(playerstats.maxweight + itemName + equipmentSOLibrary.equipmentSO[i].weight+ playerstats.weight);
                    UnEquipGear(); // Revert the changes
                    return;

                    }
               }
            }
            slotInUse = true;
        
   
    }
    
    public void UnEquipGear()
    {
        if (istull )
        {
            inventoryManager.DeselectAllSlots();

            inventoryManager.AddItem(itemName, 1, itemSprite, itemDescription, itemType);
            //Updeat Slot Image

            this.itemSprite = emptySprite;
            slotImage.sprite = this.emptySprite;
            slotName.enabled = true;


            itemDescription = "";


            //Update player Stats
            for (int i = 0; i < equipmentSOLibrary.equipmentSO.Length; i++)
            {
                if (equipmentSOLibrary.equipmentSO[i].itemName == this.itemName)
                    equipmentSOLibrary.equipmentSO[i].UnEquipItem();
                Debug.Log("測試二" + i);

            }

            itemName = "";
            istull =false; 

            GameObject.Find("StatManager").GetComponent<PlayerStats>().TurnOffpreviewStats();
        }
    }

}

