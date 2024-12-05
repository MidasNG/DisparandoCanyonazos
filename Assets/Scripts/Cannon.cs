using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private Transform origin;
    [SerializeField] private GameObject ball;
    private GameObject instance;
    private float randomSize, randomForce;
    private int randomColor;

    void Start()
    {
        origin = GameObject.Find("Origen")?.transform;        
    }

    public void Shoot()
    {
        //Dejar la corrutina de rastreo anterior
        StopAllCoroutines();

        //Cambio de color inicial y creación de bala
        GetComponent<MeshRenderer>().material.color = Color.red;
        instance = Instantiate(ball, origin);
        instance.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 10), ForceMode.Impulse);

        //Corrutina de rastreo de distancia para volver al color normal
        StartCoroutine(TrackDistance(instance));
    }

    public void RandomShoot()
    {
        //Dejar la corrutina de rastreo anterior
        StopAllCoroutines();

        //Cambio de color inicial y creación de bala con escala y fuerza aleatorios
        GetComponent<MeshRenderer>().material.color = Color.red;
        instance = Instantiate(ball, origin);

        randomSize = Random.Range(0.1f, 3f);
        instance.transform.localScale = new Vector3(randomSize, randomSize, randomSize);

        instance.GetComponentInChildren<TrailRenderer>().startWidth *= randomSize;
        randomForce = Random.Range(1f, 20f);
        instance.GetComponent<Rigidbody>().AddForce(new Vector3(0, randomForce, randomForce), ForceMode.Impulse);
        
        //Cambio de color
        randomColor = Random.Range(1, 6);
        switch (randomColor)
        {
            case 1:
                instance.GetComponent<MeshRenderer>().material.color = Color.white;
                instance.GetComponentInChildren<TrailRenderer>().startColor = Color.black;
                instance.GetComponentInChildren<TrailRenderer>().endColor = Color.black;
                break;
                
            case 2:
                instance.GetComponent<MeshRenderer>().material.color = Color.blue;
                instance.GetComponentInChildren<TrailRenderer>().startColor = Color.yellow;
                instance.GetComponentInChildren<TrailRenderer>().endColor = Color.yellow;
                break;

            case 3:
                instance.GetComponent<MeshRenderer>().material.color = Color.red;
                instance.GetComponentInChildren<TrailRenderer>().startColor = Color.cyan;
                instance.GetComponentInChildren<TrailRenderer>().endColor = Color.cyan;
                break;

            case 4:
                instance.GetComponent<MeshRenderer>().material.color = Color.green;
                instance.GetComponentInChildren<TrailRenderer>().startColor = Color.magenta;
                instance.GetComponentInChildren<TrailRenderer>().endColor = Color.magenta;
                break;

            case 5:
                instance.GetComponent<MeshRenderer>().material.color = Color.black;
                break;
        }

        //Corrutina de rastreo de distancia para volver al color normal del cañón
        StartCoroutine(TrackDistance(instance));
    }

    private IEnumerator TrackDistance(GameObject bullet)
    {
        while (bullet != null && Vector3.Magnitude(bullet.transform.position - transform.position) < 7) yield return new WaitForEndOfFrame();
        GetComponent<MeshRenderer>().material.color = Color.white;
        yield return null;
    }
}