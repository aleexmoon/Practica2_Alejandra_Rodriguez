using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLapse : MonoBehaviour
{
    public float timer = 0.0f;

    void Update()
    {
        // Incrementar el temporizador
        timer += Time.deltaTime;

        // Verificar el valor del temporizador y realizar las traslaciones correspondientes
        if (timer >= 0.0f && timer <= 10.0f)
        {
            transform.Translate(new Vector3(0.0f, -0.2f, 0.0f) * Time.deltaTime);
        }
        else if (timer >= 10.0f && timer <= 20.0f)
        {
            transform.Translate(new Vector3(0.0f, -0.2f, 0.0f) * Time.deltaTime);
        }
        else if (timer >= 20.0f && timer <= 30.0f)
        {
            transform.Translate(new Vector3(0.0f, 0.4f, 0.0f) * Time.deltaTime);
        }

        // Reiniciar el temporizador si ha pasado de 30.0f
        if (timer >= 30.0f)
        {
            timer = 0.0f;
        }
    }
}
