using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InspectPanel : MonoBehaviour
{
    public Items item;

    #region Panel reference
    public Image panelImage;
    public Image panelInspectImage;
    public TextMeshProUGUI panelName;
    public TextMeshProUGUI panelDescription;
    public TextMeshProUGUI panelMoney;
    public GameObject panelInspectImageHolder;
    public TextMeshProUGUI panelHealth;
    #endregion

    bool isPanelInspectOn = false;

    #region Panel data
    private float chance;
    private Sprite itemIcon;
    private Sprite itemInspect;
    private string itemName;
    private ItemType itemType;
    private int maxBuy;
    private string itemDescription;
    private int itemMoney;
    private int itemHealth;
    #endregion

    private void Start()
    {
        panelInspectImageHolder = InspectManager.instance.inspectHolder;
        panelInspectImage = InspectManager.instance.inspectImageHolder;
        UpdatePanelData();
        this.name = itemName + " panel";
    }

    public void UpdatePanelData()
    {
        itemIcon = item.itemIcon;
        itemInspect = item.inspectIcon;
        itemName = item.itemName;
        itemType = item.itemType;
        itemDescription = item.itemDescription;
        itemMoney = item.itemMoney;
        itemHealth = item.itemHealth;
        UpdatePanelUI();
    }

    void UpdatePanelUI()
    {
        panelImage.sprite = itemIcon;
        panelInspectImage.sprite = itemInspect;
        panelName.text = itemName;
        panelDescription.text = itemDescription;
        panelMoney.text = "$" + itemMoney;
        panelHealth.text = "Food: " + itemHealth;
    }

    public void InspectItem()
    {
        if (isPanelInspectOn)
        {
            panelInspectImageHolder.SetActive(false);
        }
        else
        {
            panelInspectImageHolder.SetActive(true);
            UpdatePanelData();
        }

        isPanelInspectOn = !isPanelInspectOn;
    }
}
