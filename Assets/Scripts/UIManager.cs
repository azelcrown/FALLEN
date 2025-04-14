using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI objects")]
    [SerializeField] public GameObject textPick;
    [SerializeField] public GameObject textSave;
    //[SerializeField] public TMP_Text questionText;

    public void Start()
    {
        // Ocultar los elementos de la UI que no queremos ver:
        textPick.SetActive(false);
        textSave.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Funciones UI objetos:
    public void ShowMessage() // Mostrar objeto string mensaje
    {
         // Mostrar objeto
        //interacText.text = mensaje; // reescribir el texto con el mensaje
    } 
    
}
