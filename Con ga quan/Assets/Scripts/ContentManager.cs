using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentManager : MonoBehaviour
{
    public GameObject panelPrefab;
    public int numberOfPanels;

    public List<string> itemNames;

    public ItemPanel[] itemPanels;
    private void Awake()
    {
        for (int i = 0; i < numberOfPanels; i++)
        {
            GameObject panel = Instantiate(panelPrefab);
            panel.transform.SetParent(transform,false);
            
        }

        itemPanels = this.transform.GetComponentsInChildren<ItemPanel>();

        foreach (ItemPanel i in itemPanels)
        {
            itemNames.Add(i.name);
        }

    }
}
