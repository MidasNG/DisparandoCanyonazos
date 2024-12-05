using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Cannon cannon;
    public GameObject origin;
    public TextMeshProUGUI counter;
    private int bulletCount = 0;

    private void Start()
    {
        cannon = FindObjectOfType<Cannon>();
        origin = GameObject.Find("Origen");
        counter = GameObject.Find("Counter").GetComponent<TextMeshProUGUI>();
    }

    public void BulletUp()
    {
        bulletCount++;
        counter.text = bulletCount.ToString();
    }

    public void BulletRemove()
    {
        foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("Bullet")) Destroy(bullet.gameObject);
        bulletCount = 0;
        counter.text = bulletCount.ToString();
    }
}
