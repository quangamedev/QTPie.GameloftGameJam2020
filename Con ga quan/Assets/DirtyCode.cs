using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DirtyCode : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        InspectManager.instance.back.SetActive(false);
        InspectManager.instance.checkout.SetActive(false);
        InspectManager.instance.timer.GetComponent<Timer>().StartTimer();
    }
}
