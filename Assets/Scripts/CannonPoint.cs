using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonPoint : MonoBehaviour
{
    public GameObject pointer;
    public int speed;
    private Vector2 movement;

    void Update()
    {
        if (movement.magnitude != 0)
        {
            //Movimiento para ambos ejes con límites (que no se salga de la pantalla y no atraviese el suelo)
            pointer.transform.position += new Vector3(movement.x, movement.y, 0)*speed*Time.deltaTime;
            pointer.transform.position = new Vector3(Mathf.Clamp(pointer.transform.position.x, -10.5f, 5.5f), Mathf.Clamp(pointer.transform.position.y, 1.15f, 5.5f), pointer.transform.position.z);
        }

        //El padre mira la diana para alinear el cañón
        transform.LookAt(pointer.transform.position);
    }

    //Recibir movimiento
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}
