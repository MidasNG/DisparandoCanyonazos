using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonPoint : MonoBehaviour
{
    public GameObject pointer;
    public GameManagerScript game;
    public int speed;
    private Vector2 movement;
    private bool charging;
    private float pow;
    public TextMeshProUGUI powerText;

    void Update()
    {
        if (movement.magnitude != 0)
        {
            //Movimiento para ambos ejes con límites (que no se salga de la pantalla y no atraviese el suelo)
            pointer.transform.position += new Vector3(movement.x, movement.y, 0)*speed*Time.deltaTime;
            pointer.transform.position = new Vector3(Mathf.Clamp(pointer.transform.position.x, -10.5f, 5.5f), Mathf.Clamp(pointer.transform.position.y, 1.15f, 5.5f), pointer.transform.position.z);
        }

        //Aumento de potencia
        if (charging)
        {
            pow += 20 * Time.deltaTime;
            pow = Mathf.Clamp(pow, 0, 50);
            powerText.text = "Potencia: " + (int)pow;
        }

        //El padre mira la diana para alinear el cañón
        transform.LookAt(pointer.transform.position);
    }

    //Recibir movimiento
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    public void OnShoot(InputValue value)
    {
        if (value.Get<float>() > 0)
        {
            charging = true;
        }
        else
        {
            charging = false;
            //Disparo
            game.cannon.Shoot((int)pow);
            game.BulletUp();

            //Volver al estado inicial
            powerText.text = "Potencia: 10";
            pow = 10f;
        }
    }
}
