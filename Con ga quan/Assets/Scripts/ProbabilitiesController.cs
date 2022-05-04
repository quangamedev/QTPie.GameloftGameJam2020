using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilitiesController : MonoBehaviour
{
    public static ProbabilitiesController instance;

    private void Awake()
    {
        instance = this;
    }

    private int maxFakeItems = 2;
    public List<Items> fakeItems;

    private void OnEnable()
    {
        maxFakeItems = Random.Range(2, 5);
        fakeItems = new List<Items>();
    }

    //get random item
    public int GetRandomItem(List<Items> itemDatas)
    {
        int tries = 0;
        //conditions to avoid infinite loop
        while (tries < 100)
        {

            //faster random, more repitition, more control
            //get a number from 1 to 100
            int i = Random.Range(1, 101);

            //loop through all the items in the List
            for (int index = 0; index < itemDatas.Count; index++)
            {
                //see if the number fit in the 
                if (i >= itemDatas[index].minProbabilityRange && i <= itemDatas[index].maxProbabilityRange)
                {
                    //if the item is fake
                    if (itemDatas[index].itemType == ItemType.Fake)
                    {
                        //there can still be fake items in the shop
                        if (fakeItems.Count < maxFakeItems)
                        {
                            //add it to the fake list
                            fakeItems.Add(itemDatas[index]);
                            return index;
                        }
                    }
                    else //the item is not fake
                    {
                        return index;
                    }

                }
            }

            #region OtherRNG
            //slower random, less repitition, less control
            //int randIndex = Random.Range(0, itemDatas.Count);
            //int randNum = Random.Range(1, 101);
            //if (randNum >= itemDatas[randIndex].minProbabilityRange && randNum <= itemDatas[randIndex].maxProbabilityRange)
            //{
            //    return randIndex;
            //}
            #endregion

            tries++;
        }

        Debug.LogError("Cannot find random item");
        return -1;
        
    }
}
