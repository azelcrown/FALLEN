using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    private bool imagenActiva = false;

    void Start()
    {
        canvasGroup.alpha = 0f; // invisible al principio
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        StartCoroutine(FadeInDespuesDe(15f));
    }
    void Update()
    {
        // Solo escucha la tecla si ya se mostró la imagen
        if (imagenActiva && Input.GetButtonDown("Play"))
        {
            SceneManager.LoadScene("Final");
        }
    }

    IEnumerator FadeInDespuesDe(float segundos)
    {
        yield return new WaitForSeconds(segundos);

        float duracion = 2f;
        float tiempo = 0f;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, tiempo / duracion);
            yield return null;
        }

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        imagenActiva = true;
    }
}
/* 

[Header("UI objects")]
    [SerializeField] public GameObject titulo;

    Start is called before the first frame update
    void Start()
    {
        titulo.SetActive(false); // empieza oculta
        StartCoroutine(EsperarYMostrar());
    }

    IEnumerator EsperarYMostrar()
    {
        yield return new WaitForSeconds(15f);
        titulo.SetActive(true);
    }*/

