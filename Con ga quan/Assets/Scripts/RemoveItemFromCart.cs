using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItemFromCart : MonoBehaviour
{
    public void RemoveFromCart(GameObject itemHolder)
    {
        Items itemToRemove = itemHolder.GetComponent<InspectPanel>().item;
        if (CartManager.instance.itemsInCart.Contains(itemToRemove))
        {
            CartManager.instance.itemsInCart.Remove(itemToRemove);
        }
        else if (CartManager.instance.matchedItems.Contains(itemToRemove))
        {
            CartManager.instance.matchedItems.Remove(itemToRemove);
        }

        HideItem(itemHolder);
    }

    public void HideItem(GameObject itemToHide)
    {
        itemToHide.SetActive(false);
    }
}
