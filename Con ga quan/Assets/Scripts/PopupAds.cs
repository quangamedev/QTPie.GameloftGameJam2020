using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupAds : MonoBehaviour
{
    public GameObject[] adPrefabs;
    public GameObject adHolder;
    public float timesToPopUp = 8;
    public float maxTimeBtwAds;
    public float chanceForPopUp;

    public void GenerateAdEncounter()
    {
        chanceForPopUp = Random.Range(1, 5);

        if (chanceForPopUp == 1)
        {
            StartCoroutine(GenerateAds());
        }
    }

    IEnumerator GenerateAds()
    {
        for (int i = 0; i < timesToPopUp; i++)
        {
            float x = Random.Range(-440f, 228f);
            float y = Random.Range(-765f, 400f);
            GameObject ad = Instantiate(adPrefabs[Random.Range(0,adPrefabs.Length)], new Vector2(x,y), Quaternion.identity);
            ad.transform.SetParent(adHolder.transform, false);
            yield return new WaitForSeconds(Random.Range(.5f, maxTimeBtwAds));
        }
    }
}
