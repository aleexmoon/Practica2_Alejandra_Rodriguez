using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeE : MonoBehaviour
{
    public GameObject panoramica;
    public GameObject equirectangular;

    void Start()
    {
        // Comienza el ciclo de activación/desactivación
        InvokeRepeating("OnOff", 0f, 30f); // 30 segundos para tener en cuenta todos los pasos
    }

    void OnOff()
    {
        panoramica.SetActive(true);
        equirectangular.SetActive(false);
        Invoke("OnOff2", 10f); // Espera 10 segundos antes de pasar al siguiente paso
    }

    void OnOff2()
    {
        panoramica.SetActive(false);
        equirectangular.SetActive(true);
        Invoke("OnOff3", 10f); // Espera 10 segundos antes de pasar al siguiente paso
    }

    void OnOff3()
    {
        panoramica.SetActive(false);
        equirectangular.SetActive(false);
        // No es necesario reiniciar el ciclo aquí, ya que se reiniciará automáticamente después de 30 segundos
    }
}

