using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdRandomiser : MonoBehaviour
{
    public Image sr;

    // Start is called before the first frame update
    void Start()
    {
        sr.color = Random.ColorHSV();
    }
}
