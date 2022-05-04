using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPanel : MonoBehaviour
{
    public List<Items> itemDatas;

    public Items item;

    #region Panel reference
    public Image panelImage;
    public TextMeshProUGUI panelName;
    public TextMeshProUGUI panelDescription;
    private ProbabilitiesController probabilitiesController;
    public TextMeshProUGUI panelMoney;
    public TextMeshProUGUI panelHealth;
    #endregion

    #region Panel data
    private Sprite itemIcon;
    public string itemName;
    public ItemType itemType;
    private int maxBuy;
    private string itemDescription;
    private float minProbability;
    private float maxProbability;
    private int itemMoney;
    private int itemHealth;
    #endregion

    private void Awake()
    {
        //find probability controller
        probabilitiesController = FindObjectOfType<ProbabilitiesController>().GetComponent<ProbabilitiesController>();

        //get random item from probability controller
        item = itemDatas[probabilitiesController.GetRandomItem(itemDatas)];
        UpdatePanelData();
        this.name = itemName;
    }

    public void UpdatePanelData()
    {
        itemIcon = item.itemIcon;
        minProbability = item.minProbabilityRange;
        maxProbability = item.maxProbabilityRange;
        itemName = item.itemName;
        itemType = item.itemType;
        itemHealth = item.itemHealth;
        maxBuy = item.maxBuy;
        itemDescription = item.itemDescription;
        itemMoney = item.itemMoney;
        UpdatePanelUI();
    }

    void UpdatePanelUI()
    {
        panelImage.sprite = itemIcon;
        panelName.text = itemName;
        panelDescription.text = itemDescription;
        panelMoney.text = "$"+itemMoney;
        if (panelHealth != null)
        {
            panelHealth.text = "Food: " + itemHealth;
        }
    }

}
