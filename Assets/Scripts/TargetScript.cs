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
    }

    private void OnCollisionEnter(Collision collision) 
    {
        game.TargetRespawn(posNum);

        //Para no hacer otra detecci�n de colisiones, destruyo la bala aqu�
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
