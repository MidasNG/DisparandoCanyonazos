using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public bool altBehaviour;
    private int hitCount = 0;
    private bool rotate = false;

    private void OnCollisionEnter(Collision collision)
    {
        //Desde el inspector se ajusta si desaparece después de un golpe o tres
        if (!altBehaviour) Destroy(gameObject);
        else
        {
            //Estados
            hitCount++;

            if (hitCount == 1) GetComponent<MeshRenderer>().material.color = Color.red;
            else if (hitCount == 2) rotate = true;
            else if (hitCount == 3) Destroy(gameObject);
        }
    }

    private void Update()
    {
        //Rotación en estado 2
        if(rotate) transform.Rotate(0, 15*Time.deltaTime, 0);
    }
}
