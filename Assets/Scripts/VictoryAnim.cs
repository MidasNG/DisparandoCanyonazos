using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryAnim : MonoBehaviour
{
    TextMeshProUGUI text;

    float timer = 0.5f;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();    
    }

    void Update()
    {
        if (timer < 0)
        {
            timer = 0.5f;
            text.color = Random.ColorHSV();
        }
        timer -= Time.deltaTime;
    }
}
