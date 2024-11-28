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
        if (!altBehaviour) Destroy(gameObject);
        else
        {
            hitCount++;

            if (hitCount == 1) GetComponent<MeshRenderer>().material.color = Color.red;
            else if (hitCount == 2) rotate = true;
            else if (hitCount == 3) Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(rotate) transform.Rotate(0, 0.02f, 0);
    }
}
