using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int attack, defense, agility, intelligence,weight;
    public int maxweight = 50;

    [SerializeField]
    private Text attackText , defenseText , agilityText, intelligenceText,weightText;

    [SerializeField]
    private Text attackPreText, defensePreText, agilityPreaText, intelligencePreText,weightPreText;
    [SerializeField]
    private Image previewImage;

    [SerializeField]
    private GameObject selectedItemStats;
    [SerializeField]
    private GameObject selectedItemImage;

    // Start is called before the first frame update
    void Start()
    {
        UpdateEquipmentStats(); 
    }

    // Update is called once per frame
    public void UpdateEquipmentStats()
    {
        attackText.text = attack.ToString();
        defenseText.text = defense.ToString();
        agilityText.text = agility.ToString();
        intelligenceText.text = intelligence.ToString();
        weightText.text = weight.ToString()+ "/"+ maxweight.ToString();
    }

    public void PreviewEquipmentStats(int attack, int defense, int agility, int intelligence, Sprite itemSprite, int weight) 
    {
       attackPreText.text = attack.ToString();
       defensePreText.text = defense.ToString();
       agilityPreaText.text = agility.ToString();
        intelligencePreText.text = intelligence.ToString();
        weightPreText.text = weight.ToString();

        previewImage.sprite = itemSprite;
        selectedItemStats.SetActive(true);
        selectedItemImage.SetActive(true);

    }
    public void TurnOffpreviewStats()
    {
         selectedItemStats.SetActive(false);
        selectedItemImage.SetActive(false);
    }
}

