using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Foods,
    Electronics,
    Clothes,
    Fake
}

[CreateAssetMenu(fileName = "New Item", menuName ="Items")]
public class Items : ScriptableObject
{
    public Sprite itemIcon;
    public Sprite inspectIcon;
    public Sprite alternateIcon;
    public string itemName;
    public ItemType itemType;
    public int maxBuy = 99;
    public float minProbabilityRange = 0;
    public float maxProbabilityRange = 100;
    public int itemMoney = 10;
    public int itemHealth = 0;


    [TextArea(3,10)]
    public string itemDescription;

    // This fucntion runs when variables are changed
    private void OnValidate()
    {
        if (itemType != ItemType.Fake)
        {
            itemName = name;
            inspectIcon = itemIcon;
        }

        if(itemType != ItemType.Foods && itemType != ItemType.Fake)
        {
            itemHealth = 0;
        }
    }
}
