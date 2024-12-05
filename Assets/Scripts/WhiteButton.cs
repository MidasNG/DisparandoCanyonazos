using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteButton : MonoBehaviour
{
    private GameManager game;

    private void Start()
    {
        game = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        game.cannon.RandomShoot();
        game.BulletUp();
    }
}
