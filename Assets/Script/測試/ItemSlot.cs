using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using static InventoryManager;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //======ITEM DATA======//
    public string itemName;
    public int quantity;
    public string lv;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;
    public ItemType itemType;

    [SerializeField]
    private int maxNumberOfItems;
    //====ITEM SLOT====//
  //  [SerializeField]
  //  private TMP_Text quantityText;

    [SerializeField]
    private Text quantitytext;

    [SerializeField]
    private Image itemImage;

    


    //===ITEM DESCRIPTION SLOT===//
    public Image itemDescriptionImage;
    public Text ItemDescriptionNameText;
    public Text ItemDescriptionText;



    public GameObject selectedShader;
    public bool thisItemSelected;
    private InventoryManager inventoryManager;

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription,ItemType itemtype)
    {
        //Chefck to see if the slot is already full
        if (isFull)
            return quantity;

      //  this.itemType = itemType;
       // Update NAME
        this.itemName = itemName;
       
       
        //Update Image
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;

        //Update Description
        this.itemDescription = itemDescription;

        //Update QUANTITY
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            //quantityText.text = maxNumberOfItems.ToString();
            //quantityText.enabled = true;

            quantitytext.text = maxNumberOfItems.ToString();
            quantitytext.gameObject.SetActive(true);
            isFull = true;


            //Return the LEFTOVERS
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }

        //Update QUANTITY TEXT
        quantitytext.text = this.quantity.ToString();
        quantitytext.gameObject.SetActive(true);
      //  quantityText.text = this.quantity.ToString();
     //   quantityText.enabled = true;

        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left) 
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
        if (thisItemSelected)
        {
            bool usable = inventoryManager.UseItem(itemName);
            if (usable) 
            {
                Debug.Log("1");
                this.quantity -= 1;
                quantitytext.text = this.quantity.ToString();
                if (this.quantity <= 0)
                    EmptySlot();
                Debug.Log("2");
              
            }
 
        }
        else
        {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
            ItemDescriptionNameText.text = itemName;
            ItemDescriptionText.text = itemDescription;
            itemDescriptionImage.sprite = itemSprite;
            if (itemDescriptionImage.sprite == null)
                itemDescriptionImage.sprite = emptySprite;
            Debug.Log("ด๚ธี3");
        }
 

    }

    private void EmptySlot()
    {
        itemImage.sprite = emptySprite;
        quantitytext.gameObject.SetActive(false);
        itemSprite = emptySprite;
        itemImage.sprite = emptySprite;
        itemName = "";
        itemDescription = "";
        ItemDescriptionNameText.text = "";
        ItemDescriptionText.text = "";
        itemDescriptionImage.sprite = emptySprite;
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

        //Create and modify the SR
        SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
        sr.sprite = itemSprite;
        sr.sortingOrder = 5;
        sr.sortingLayerName = "Ground";

        //Add a collider
        itemToDrop.AddComponent<BoxCollider2D>();

        //Set the location
        itemToDrop.transform.position = GameObject.FindWithTag("Play").transform.position+ new Vector3(1f,0f,0f);
        itemToDrop.transform.localScale = new Vector3(1f, 1f, 1f);

        //Subtract the item
        this.quantity -= 1;
        quantitytext.text = this.quantity.ToString();
        if (this.quantity <= 0)
            EmptySlot();
    }
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }



    internal int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        throw new NotImplementedException();
    }
}
