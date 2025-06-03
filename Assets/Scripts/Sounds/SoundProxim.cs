using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundProxim : MonoBehaviour
{
    private AudioSource audioSource;
    private Coroutine fadeCoroutine;
    public float fadeDuration = 1f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0f; // Empezar silenciado
        audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (fadeCoroutine != null)
                StopCoroutine(fadeCoroutine);
            fadeCoroutine = StartCoroutine(FadeAudio(1f));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (fadeCoroutine != null)
                StopCoroutine(fadeCoroutine);
            fadeCoroutine = StartCoroutine(FadeAudio(0f));
        }
    }

    private IEnumerator FadeAudio(float targetVolume)
    {
        float startVolume = audioSource.volume;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsed / fadeDuration);
            yield return null;
        }

        audioSource.volume = targetVolume;

        if (targetVolume == 0f)
            audioSource.Pause(); // Pausa para no seguir gastando recursos
        else if (!audioSource.isPlaying)
            audioSource.Play();
    }
}
