using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private GameManagerScript game;
    private float timeLeft;

    private void Start()
    {
        game = FindObjectOfType<GameManagerScript>();
        timeLeft = game.timeToHit;

        //Selección de la imagen en la diana
        List<Transform> children = new List<Transform>();
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            children.Add(child);
            if (child.gameObject != gameObject) child.gameObject.SetActive(false);
        }
        children[Random.Range(1, children.Count)].gameObject.SetActive(true);
    }

    //Tiempo para golpear la diana
    private void Update()
    {
        if (timeLeft < 0)
        {
            game.TargetRespawn(false, transform.position.x, transform.position.y);
            Destroy(gameObject);
        }
        timeLeft -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision) 
    {
        //Para no hacer otra detección de colisiones, destruyo la bala aquí
        game.TargetRespawn(true, transform.position.x, transform.position.y);
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
