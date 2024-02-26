using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrusel : MonoBehaviour
{
    public float rotationSpeed = 20f;
    public bool rotateClockwise = true; // true para rotación en sentido horario, false para rotación en sentido antihorario

    void Update()
    {
        // Determina la dirección de la rotación según el valor de rotateClockwise
        float direction = rotateClockwise ? 1f : -1f;

        // Realiza la rotación según la velocidad y dirección especificadas
        transform.Rotate(new Vector3(0f, rotationSpeed * direction, 0f) * Time.deltaTime);
    }
}