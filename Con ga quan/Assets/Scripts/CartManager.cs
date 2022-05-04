using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CartManager : MonoBehaviour
{
    //will not contain matched item after checkout
    public List<Items> itemsInCart;

    public GameObject itemPanelPrefab;

    public GameObject contentTab;

    public static CartManager instance;

    public ShoppingList shoppingListRef;

    public List<Items> matchedItems;

    public GameObject cartNoti;
    public TextMeshProUGUI notiNumber;

    public GameObject goBackButton;

    private void Awake()
    {
        instance = this;

    }
    private void Update()
    {
        if (itemsInCart.Count <= 0)
        {
            cartNoti.SetActive(false);
        }
        else
        {
            cartNoti.SetActive(true);
        }
    }

    public void AddToCart(Items item, int number = 1)
    {
        itemsInCart.Add(item);
        GameObject myItem = Instantiate(itemPanelPrefab);
        myItem.transform.SetParent(contentTab.transform, false);
        myItem.GetComponent<InspectPanel>().item = item;
        myItem.GetComponent<InspectPanel>().UpdatePanelData();
        notiNumber.text = "" + itemsInCart.Count;
    }

    public void CompareCartAndShoppingList()
    {
        foreach (var item in shoppingListRef.shoppingList)
        {
            if (itemsInCart.Contains(item.item))
            {
                itemsInCart.Remove(item.item);
                matchedItems.Add(item.item);
            }
        }
    }

    public void Pay()
    {
        //buy enough items
        if (matchedItems.Count >= shoppingListRef.shoppingList.Count)
        {
            PlayerStats.Money += PlayerStats.EnoughItemsMoneyReward;

        }
        else //not enough required items
        {
            PlayerStats.Money -=
                (shoppingListRef.shoppingList.Count - matchedItems.Count)
                * PlayerStats.MissingItemMoneyPenaltyMultiplier;
        }

        //buy fake items
        if (shoppingListRef.fakeItems != null)
        {
            foreach (var item in itemsInCart)
            {
                if (item.itemType == ItemType.Fake)
                {
                    PlayerStats.Health -= 10;
                }
            }
        }
        ProcessPayment();
        ProcessFood();
    }

    private void ProcessPayment()
    {
        int totalCost = 0;

        //the items that are left after serperating (fake and excess items)
        for (int i = 0; i < itemsInCart.Count; i++)
        {
            totalCost += itemsInCart[i].itemMoney;
        }

        //the items that match the required items from shopping list
        for (int i = 0; i < matchedItems.Count; i++)
        {
            totalCost += matchedItems[i].itemMoney;
        }

        PlayerStats.Money -= totalCost;
    }

    private void ProcessFood()
    {
        float totalAddedHealth = 0;

        //the items that are left after serperating (fake and excess items)
        for (int i = 0; i < itemsInCart.Count; i++)
        {
            //only add if the item is food, do not add fake food or other category of items
            if (itemsInCart[i].itemType == ItemType.Foods)
            {
                //0.8 is health multiplier
                totalAddedHealth += (itemsInCart[i].itemHealth * 0.8f);
                print("Eaten excess items");
            }

        }

        //the items that match the required items from shopping list
        for (int i = 0; i < matchedItems.Count; i++)
        {
            totalAddedHealth += matchedItems[i].itemHealth;
        }

        PlayerStats.Health += totalAddedHealth;

    }

    public void CheckOutButton()
    {
        goBackButton.SetActive(false);
    }
}
