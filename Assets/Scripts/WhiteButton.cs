using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteButton : Button
{
    
    private void OnMouseDown()
    {
        cannon.GetComponent<Cannon>().RandomShoot();
        bulletCount++;
        counter.text = bulletCount.ToString();
    }
}
