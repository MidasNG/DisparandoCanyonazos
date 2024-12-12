using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private Transform parent;
    [SerializeField] private GameObject ball;
    private GameObject instance;
    private float randomSize, randomForce;
    private int randomColor;
    private CannonPoint direction;

    void Start()
    {
        parent = GameObject.Find("Bullets")?.transform;
        direction = GetComponentInParent<CannonPoint>();
    }

    public void Shoot(int power)
    {
        //Dejar la corrutina de rastreo anterior
        StopAllCoroutines();

        //Cambio de color inicial y creación de bala
        GetComponent<MeshRenderer>().material.color = Color.red;
        instance = Instantiate(ball, transform);
        instance.transform.LookAt(direction.pointer.transform.position);
        instance.transform.SetParent(parent);
        instance.GetComponent<Rigidbody>().AddForce(transform.up*power, ForceMode.Impulse);

        //Corrutina de rastreo de distancia para volver al color normal
        StartCoroutine(TrackDistance(instance));
    }

    private IEnumerator TrackDistance(GameObject bullet)
    {
        while (bullet != null && Vector3.Magnitude(bullet.transform.position - transform.position) < 7) yield return new WaitForEndOfFrame();
        GetComponent<MeshRenderer>().material.color = Color.white;
        yield return null;
    }
}