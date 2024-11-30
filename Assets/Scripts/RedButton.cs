using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : Button
{
    private void OnMouseDown()
    {
        foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("Bullet")) Destroy(bullet.gameObject);
        bulletCount = 0;
        counter.text = bulletCount.ToString();
        cannon.GetComponent<MeshRenderer>().material.color = Color.white;
    }
    
}
