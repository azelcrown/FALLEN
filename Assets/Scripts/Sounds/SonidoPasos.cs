using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoPasos : MonoBehaviour
{
    public AudioSource audioSource;   // AudioSource con sonido de pasos
    public float minVelocity = 0.1f;  // Umbral para considerar que se está moviendo
    private Vector3 lastPosition;

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        lastPosition = transform.position;
        audioSource.loop = true;
        audioSource.volume = 0.4f; // Ajusta volumen
    }

    void Update()
    {
        // Calcular velocidad aproximada
        float velocidad = (transform.position - lastPosition).magnitude / Time.deltaTime;

        if (velocidad > minVelocity)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Pause();
        }

        lastPosition = transform.position;
    }
}
