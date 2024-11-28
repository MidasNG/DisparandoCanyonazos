using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Button : MonoBehaviour
{
    private GameObject cannon, origin;
    private TextMeshProUGUI counter; 
    private static int bulletCount = 0;

    private void Start()
    {
        cannon = GameObject.Find("Cannon");
        origin = GameObject.Find("Origen");
        counter = GameObject.Find("Counter").GetComponent<TextMeshProUGUI>();
    }

    private void OnMouseDown()
    {
        switch (gameObject.tag)
        {
            case "Shoot":
                cannon.GetComponent<Cannon>().Shoot();
                bulletCount++;
                counter.text = bulletCount.ToString();
                break;

            case "Reset":
                foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("Bullet")) Destroy(bullet.gameObject);
                bulletCount = 0;
                counter.text = bulletCount.ToString();
                cannon.GetComponent<MeshRenderer>().material.color = Color.white;
                break;

            case "RandomShoot":
                cannon.GetComponent<Cannon>().RandomShoot();
                bulletCount++;
                counter.text = bulletCount.ToString();
                break;
        }
    }
}
