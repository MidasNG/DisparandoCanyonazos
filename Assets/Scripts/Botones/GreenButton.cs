using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GreenButton : MonoBehaviour
{
    private GameManager game;
    public TextMeshProUGUI powerText;
    private float pow = 10f;

    private void Start()
    {
        game = FindObjectOfType<GameManager>();
    }

    //Incremento de potencia
    private void OnMouseDrag()
    {
        pow += 20 * Time.deltaTime;
        pow = Mathf.Clamp(pow, 0, 50);
        powerText.text = "Potencia: " + pow.ConvertTo<int>();
    }

    private void OnMouseUp()
    {
        //Disparo
        game.cannon.Shoot(pow.ConvertTo<int>());
        game.BulletUp();

        //Volver al estado inicial
        powerText.text = "Potencia: 10";
        pow = 10f;
    }
}
