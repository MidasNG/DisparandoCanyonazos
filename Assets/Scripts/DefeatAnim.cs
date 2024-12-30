using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DefeatAnim : MonoBehaviour
{
    //La animación en X es independiente de la animación en Y, pero ambos tienen la misma aceleración
    float xTime = 0.5f, yTime = 0.5f, xTimeDirection = 0.75f, yTimeDirection = 3;
    public AnimationCurve easing;

    void Update()
    {
        //Movimiento con aceleración
        transform.localPosition = new Vector3(Mathf.Lerp(-100, 100, easing.Evaluate(xTime)), Mathf.Lerp(265, 305, easing.Evaluate(yTime)), 0);

        //Tiempo cíclico de aceleraciones
        xTime += Time.deltaTime * xTimeDirection;

        yTime += Time.deltaTime * yTimeDirection;

        if (xTime > 1)
        {
            xTimeDirection *= -1;
            xTime = 1;
        }
        else if (xTime < 0)
        {
            xTimeDirection *= -1;
            xTime = 0;
        }

        if (yTime > 1)
        {
            yTimeDirection *= -1;
            yTime = 1;
        }
        else if (yTime < 0)
        {
            yTimeDirection *= -1;
            yTime = 0;
        }
    }
}
