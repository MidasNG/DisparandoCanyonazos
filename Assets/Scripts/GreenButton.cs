using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButton : Button
{
    private void OnMouseDown()
    {
        cannon.GetComponent<Cannon>().Shoot();
        bulletCount++;
        counter.text = bulletCount.ToString();
    }
}
