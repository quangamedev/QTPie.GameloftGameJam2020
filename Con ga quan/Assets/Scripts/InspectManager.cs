using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectManager : MonoBehaviour
{
    public static InspectManager instance;
    public GameObject inspectHolder;
    public Image inspectImageHolder;
    public GameObject checkout;
    public GameObject back;
    public GameObject timer;
    private void Awake()
    {
        instance = this;
    }
}
