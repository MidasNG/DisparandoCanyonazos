using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Cannon cannon;
    public GameObject origin, target;
    public TextMeshProUGUI bulletCounter, targetCounter;
    private int bulletCount = 0, targetCount = 0, posNum = 0;
    public Transform[] targetPositions = new Transform[5];

    private void Start()
    {
        //Detecci�n de objetos
        cannon = FindObjectOfType<Cannon>();
        origin = GameObject.Find("Bullets");
        bulletCounter = GameObject.Find("BulletCounter").GetComponent<TextMeshProUGUI>();
        targetCounter = GameObject.Find("TargetCounter").GetComponent<TextMeshProUGUI>();

        //Creaci�n de la primera diana
        posNum = Random.Range(0, targetPositions.Length);
        Instantiate(target, targetPositions[posNum].position, Quaternion.Euler(-90, 0, 0)).GetComponent<TargetScript>().posNum = posNum;
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
        
        //Posici�n nueva diferente de la �ltima
        posNum = exception;
        while (posNum == exception) posNum = Random.Range(0, targetPositions.Length);

        //Creaci�n de nueva diana
        Instantiate(target, targetPositions[posNum].position, Quaternion.Euler(-90, 0, 0)).GetComponent<TargetScript>().posNum = posNum;
    }
}
