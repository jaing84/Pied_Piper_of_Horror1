using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using static InventoryManager;

public class EquipmentSlot : MonoBehaviour, IPointerClickHandler
{
    //======ITEM DATA======//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;
    public ItemType itemType;


    //====ITEM SLOT====//
    //  [SerializeField]
    //  private TMP_Text quantityText;
   // [SerializeField]
   // private Text quantitytext;

    //====EQUIPPED SLOTS====//
    [SerializeField]
    private EquippedSlot headSlot, cloakSlot, bodySlot, legsSlot, mainHandSlot, offHandSlot, relicSlot, feetSlot;

    
    public EquippedSlot [] itemSlots;
    [SerializeField]
    private Image itemImage;

    PlayerStats playerStats;

    public GameObject selectedShader;
    public bool thisItemSelected;
    private InventoryManager inventoryManager;
    private EquipmentSOLibrary equipmentSOLibrary;

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription, ItemType itemType)
    {
        //Chefck to see if the slot is already full
        if (isFull)
            return quantity;

        this.itemType = itemType;
      
        // Update NAME
        this.itemName = itemName;


        //Update Image
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;

        //Update Description
        this.itemDescription = itemDescription;

        //Update QUANTITY
        this.quantity = 1;
        isFull = true;
       
        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
       PlayerStats playerstats = GameObject.Find("StatManager").GetComponent<PlayerStats>();
        EquipmentSOLibrary equipmentSo = GameObject.Find("InventoryCanvas").GetComponent<EquipmentSOLibrary>();
        if (isFull) 
        {
            if (thisItemSelected)
            {
                
                
                    EquipGear();
                
            }
            else
            {
                inventoryManager.DeselectAllSlots();
                selectedShader.SetActive(true);
                thisItemSelected = true;
                for (int i = 0; i < equipmentSOLibrary.equipmentSO.Length; i++)
                {
                    if (equipmentSOLibrary.equipmentSO[i].itemName == this.itemName)
                        equipmentSOLibrary.equipmentSO[i].PreviewEquipment();
                    Debug.Log("ด๚ธี" + i);
                }

            }
        }
        else 
        {
            GameObject.Find("StatManager").GetComponent<PlayerStats>().TurnOffpreviewStats();
            inventoryManager.DeselectAllSlots(); 
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }


    }
    private void EquipGear()
    {

        if (itemType == ItemType.head)
            headSlot.EquipGear(itemSprite, itemName, itemDescription);
        if (itemType == ItemType.cloak)
            cloakSlot.EquipGear(itemSprite, itemName, itemDescription);
        if (itemType == ItemType.body)
            bodySlot.EquipGear(itemSprite, itemName, itemDescription);
        if (itemType == ItemType.legs)
            legsSlot.EquipGear(itemSprite, itemName, itemDescription);
        if (itemType == ItemType.mainHand)
            mainHandSlot.EquipGear(itemSprite, itemName, itemDescription);
        if (itemType == ItemType.offHand)
            offHandSlot.EquipGear(itemSprite, itemName, itemDescription);
        if (itemType == ItemType.relic)
            relicSlot.EquipGear(itemSprite, itemName, itemDescription);
        if (itemType == ItemType.feet)
            feetSlot.EquipGear(itemSprite, itemName, itemDescription);
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemType == ItemType.item && itemSlots[i] != null)
                itemSlots[i].EquipGear(itemSprite, itemName, itemDescription);
        }
        EmptySlot();
    }

    private void EmptySlot()
    {

        // quantitytext.gameObject.SetActive(false);
        quantity = 0;
        itemName = null; 
        itemImage.sprite = emptySprite;
        isFull = false;
        itemDescription = null;
        itemSprite = emptySprite;
        itemType = ItemType.none;


    }
    public void OnRightClick()
    {
        // Creat a new item
        GameObject itemToDrop = new(itemName);
        Item newItem = itemToDrop.AddComponent<Item>();
        newItem.quantity = 1;
        newItem.ItemName = itemName;
        newItem.sprite = itemSprite;
        newItem.itemDescription = itemDescription;
        newItem.itemType = itemType;

        //Create and modify the SR
        SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
        sr.sprite = itemSprite;
        sr.sortingOrder = 5;
        sr.sortingLayerName = "Ground";

        //Add a collider   
        itemToDrop.AddComponent<BoxCollider2D>();

        //Set the location
        itemToDrop.transform.position = GameObject.FindWithTag("Play").transform.position + new Vector3(1f, 0f, 0f);
        itemToDrop.transform.localScale = new Vector3(1f, 1f, 1f);

        //Subtract the item
        this.quantity -= 1;
      //  quantitytext.text = this.quantity.ToString();
        if (this.quantity <= 0)
            EmptySlot();
    }
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        equipmentSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<EquipmentSOLibrary>();
        playerStats =  GameObject.Find("StatManager").GetComponent<PlayerStats>();
    }


 

   // internal int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
  //  {
   //     throw new NotImplementedException();
   // }
}
