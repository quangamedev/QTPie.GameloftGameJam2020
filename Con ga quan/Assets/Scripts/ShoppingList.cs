using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class ShoppingList : MonoBehaviour
{
    public List<GameObject> contents;

    public List<ItemPanel> allItemPanels;
    public List<ItemPanel> authenticItems;
    public List<ItemPanel> fakeItems;
    public List<ItemPanel> shoppingList;

    public GameObject shoppingListGraphic;
    public TextMeshProUGUI textContent;
    private bool isShoppingListOn = false;

    public List<GameObject> textRows;

    public int shoppingListSize = 8;
    private void Start()
    {
        PopulatePossibleList();
        PopulateShoppingList();
        PopulateFakeList();
        PopulateShoppingListGraphic();
    }

    public void PopulatePossibleList()
    {
        for(int i = 0; i < contents.Count; i++ )
        {
            allItemPanels = allItemPanels.Union(contents[i].GetComponentsInChildren<ItemPanel>().ToList()).ToList();
        }      
    }

    void PopulateShoppingList()
    {
        foreach (var i in allItemPanels)
        {
            if(i.item.itemType != ItemType.Fake)
            {
                authenticItems.Add(i);
            }
        }

        for (int i = 0; i < shoppingListSize; i++)
        {
            shoppingList.Add(authenticItems[Random.Range(0, authenticItems.Count)]);
        }
    }

    void PopulateFakeList()
    {
        foreach (var i in allItemPanels)
        {
            if (i.item.itemType == ItemType.Fake)
            {
                fakeItems.Add(i);
            }
        }
    }

    public void ToggleToDoList()
    {
        isShoppingListOn = !isShoppingListOn;
        shoppingListGraphic.SetActive(isShoppingListOn);
    }

    public void PopulateShoppingListGraphic()
    {
        for (int i = 0; i < shoppingListSize; i++)
        {
            textRows[i].GetComponent<TextMeshProUGUI>().text = shoppingList[i].item.itemName;
        }
    }
}
