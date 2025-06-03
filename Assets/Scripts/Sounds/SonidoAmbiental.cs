using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoAmbiental : MonoBehaviour
{
    private static SonidoAmbiental instancia;

    void Awake()
    {
        // Si ya existe una instancia de este objeto, destr�yelo para evitar duplicados
        if (instancia != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);  // No destruir este objeto al cambiar de escena
        }
    }
}

