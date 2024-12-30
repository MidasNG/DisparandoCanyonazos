using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManagerScript : MonoBehaviour
{
    public Cannon cannon;
    public GameObject origin, target, gameOverCanvas, victoryText, defeatText;
    public TextMeshProUGUI bulletCounter, targetCounter, timeCounter;
    public AudioClip shootSound, hitSound;
    private int bulletCount = 0, targetCount = 0;
    public float countdown = 20, timeBonus = 3, timeToHit, maxDistanceX, maxDistanceY;
    private bool hasEnded = false;

    private void Start()
    {
        //Detección de objetos
        cannon = FindObjectOfType<Cannon>();
        origin = GameObject.Find("Bullets");
        bulletCounter = GameObject.Find("BulletCounter").GetComponent<TextMeshProUGUI>();
        targetCounter = GameObject.Find("TargetCounter").GetComponent<TextMeshProUGUI>();
        timeCounter = GameObject.Find("TimeCounter").GetComponent<TextMeshProUGUI>();

        //Creación de la primera diana
        Instantiate(target, new Vector3(Random.Range(-20, 15), Random.Range(1.5f, 11), 10), Quaternion.Euler(-90, 0, 0));
    }

    //Contador de tiempo
    private void Update()
    {
        if (countdown <= 0 && !hasEnded)
        {
            GameOver();
            hasEnded = true;
        }
        else if (!hasEnded)
        {
            countdown -= Time.deltaTime;
            timeCounter.text = "Tiempo: " + (int)countdown;
        }
    }

    public void BulletUp()
    {
        GetComponent<AudioSource>().PlayOneShot(shootSound);

        //Incremento del contador
        bulletCount++;
        bulletCounter.text = "Balas: " + bulletCount.ToString();
    }

    public void TargetRespawn(bool wasHit, float oldX, float oldY)
    {
        if (wasHit)
        {
            GetComponent<AudioSource>().PlayOneShot(hitSound);

            //Incremento de dianas golpeadas y tiempo adicional
            targetCount++;
            countdown += timeBonus;
            targetCounter.text = "Dianas: " + targetCount.ToString();
        }

        //Creación de nueva diana con distancia limitada en ambos ejes
        Instantiate(target, new Vector3(Mathf.Clamp(Random.Range(-20, 15), oldX - maxDistanceX, oldX + maxDistanceX), Mathf.Clamp(Random.Range(1.5f, 11), oldY - maxDistanceY, oldY + maxDistanceY), 10), Quaternion.Euler(-90, 0, 0));
    }

    private void GameOver()
    {
        FindObjectOfType<TargetScript>().gameObject.SetActive(false);
        GameObject.Find("Cruceta").SetActive(false);


        //Condición de victoria: 10 dianas y más de 50% de presición
        if (targetCount >= 10 && bulletCount/2 < targetCount)
        {
            victoryText.SetActive(true);
        }
        else
        {
            defeatText.SetActive(true);
        }

        gameOverCanvas.SetActive(true);
        GameObject.Find("GameOverBulletCounter").GetComponent<TextMeshProUGUI>().text = "Disparos: " + bulletCount;
        GameObject.Find("GameOverTargetCounter").GetComponent<TextMeshProUGUI>().text = "Aciertos: " + targetCount;
        if (bulletCount > 0) GameObject.Find("AccuracyCounter").GetComponent<TextMeshProUGUI>().text = "Presición: " + (int)(100f / bulletCount * targetCount) + "%";
        else GameObject.Find("AccuracyCounter").GetComponent<TextMeshProUGUI>().text = "Presición: N/A";
    }
}
