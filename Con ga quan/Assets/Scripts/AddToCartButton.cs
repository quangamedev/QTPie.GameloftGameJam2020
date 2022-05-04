using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToCartButton : MonoBehaviour
{
    public CartManager cartManager;

    public void OnButtonClicked()
    {
        CartManager.instance.AddToCart(this.GetComponent<ItemPanel>().item);
    }
}
