using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    private GameManager game;

    private void Start()
    {
        game = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        game.BulletRemove();
        game.cannon.GetComponent<MeshRenderer>().material.color = Color.white;
    }
    
}
