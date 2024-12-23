using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManagerScript : MonoBehaviour
{
    public Cannon cannon;
    public GameObject origin, target;
    public TextMeshProUGUI bulletCounter, targetCounter;
    private int bulletCount = 0, targetCount = 0;

    private void Start()
    {
        //Detección de objetos
        cannon = FindObjectOfType<Cannon>();
        origin = GameObject.Find("Bullets");
        bulletCounter = GameObject.Find("BulletCounter").GetComponent<TextMeshProUGUI>();
        targetCounter = GameObject.Find("TargetCounter").GetComponent<TextMeshProUGUI>();

        //Creación de la primera diana
        Instantiate(target, new Vector3(Random.Range(-20, 15), Random.Range(1.5f, 11), 10), Quaternion.Euler(-90, 0, 0));
    }

    public void BulletUp()
    {
        //Incremento del contador
        bulletCount++;
        bulletCounter.text = "Balas: " + bulletCount.ToString();
    }

    public void TargetRespawn(int exception)
    {
        //Incremento de dianas golpeadas
        targetCount++;
        targetCounter.text = "Dianas: " + targetCount.ToString();

        //Creación de nueva diana
        Instantiate(target, new Vector3(Random.Range(-20, 15), Random.Range(1.5f, 11), 10), Quaternion.Euler(-90, 0, 0));
    }
}
