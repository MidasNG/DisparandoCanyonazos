using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Button : MonoBehaviour
{
    protected GameObject cannon, origin;
    protected TextMeshProUGUI counter; 
    protected static int bulletCount = 0;

    private void Start()
    {
        cannon = GameObject.Find("Cannon");
        origin = GameObject.Find("Origen");
        counter = GameObject.Find("Counter").GetComponent<TextMeshProUGUI>();
    }
}
