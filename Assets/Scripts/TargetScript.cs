using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private GameManagerScript game;
    public int posNum;

    private void Start()
    {
        game = GameObject.FindObjectOfType<GameManagerScript>();
        List<Transform> children = new List<Transform>();
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            children.Add(child);
            if (child.gameObject != gameObject) child.gameObject.SetActive(false);
        }
        children[Random.Range(1, children.Count)].gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        game.TargetRespawn(posNum);

        //Para no hacer otra detección de colisiones, destruyo la bala aquí
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
