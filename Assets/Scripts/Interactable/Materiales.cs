using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Materiales : Interactable
{
    // Declarar variables:
    private UIManager uiManager;
    private GameManager gameManager;

    private GameObject msjMaterial;
    private TMP_Text textMaterial;
    private TMP_Text textList;
    [SerializeField] private string material;
    private string interactMessage = "";
    private bool active = false;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        msjMaterial = uiManager.interctMessage;
        textMaterial = uiManager.materialText;

        gameManager = FindObjectOfType<GameManager>();
        textList = gameManager.listText;
    }

    // Sobreescribe la funci�n Interact() para este tipo de objetos (Materiales)
    public override void Interact()
    {
        base.Interact();
        //Debug.Log("object");
        MaterialData(material);  // texto datos del material
        msjMaterial.SetActive(true); // mostrar el mensaje correspondiente
        active = true;  
    }

    void Update()
    {
        // Si mientras est� activo el mensaje de interacci�n, se pulsa el bot�n, se desactiva.
        if (active) { 
            if (Input.GetButtonDown("Circulo"))
            {
                Debug.Log("O pulsado");
                Desactivate();
                AddList(material); // A�adir el material a la lista
            }
            if (Input.GetButtonDown("X"))
            {
                Debug.Log("X pulsado");
                Desactivate();
            }
        }
    }
    private void Desactivate()
    {
        msjMaterial.SetActive(false);
        active = false;
        interactMessage = "";
    }

    private void AddList(string matName)
    {
        textList.text += "\n- ";
        textList.text += matName;
    }

    private void MaterialData(string mat)
    {
        // Listado de Materiales y sus datos:
        switch (mat)
        {
            case "Prueba":
                interactMessage += mat;
                break;

            case "Aguarras":
                interactMessage += mat;
                interactMessage += "\n2 bidones de 200L\n10�8 Mcal/kg\n35�C,  0,86 kg/L";
                break;

            case "Disolvente F":
                interactMessage += mat;
                interactMessage += "\n7 bidones de 200L\n8 Mcal/kg\n-1�C,  0,85 kg/L";
                break;
            case "Disolvente D1":
                interactMessage += mat;
                interactMessage += "\n80L\n8 Mcal/kg\n-1�C,  0,85 kg/L";
                break;
            case "Disolvente D2":
                interactMessage += mat;
                interactMessage += "\n30L\n8 Mcal/kg\n-1�C\n0,85 kg/L";
                break;

            case "Polietileno M":
                interactMessage += mat;
                interactMessage += "\n30.000kg\n10�5 Mcal/kg\n200�C";
                break;
            case "Polietileno P":
                interactMessage += mat;
                interactMessage += "\n4.000kg\n10�5 Mcal/kg\n200�C";
                break;

            case "Poliestireno M":
                interactMessage += mat;
                interactMessage += "\n20.000kg\n9 Mcal/kg\n200�C";
                break;
            case "Poliestireno P":
                interactMessage += mat;
                interactMessage += "\n2.500kg\n9 Mcal/kg\n200�C";
                break;

            case "Resinas fen�licas M":
                interactMessage += mat;
                interactMessage += "\n10.000kg\n6 Mcal/kg\n200�C";
                break;
            case "Resinas fen�licas P":
                interactMessage += mat;
                interactMessage += "\n1.000kg\n6 Mcal/kg\n200�C";
                break;

            case "Pigmentos colorantes":
                interactMessage += mat;
                interactMessage += "\n100 kg (sacos de 25kg)";
                break;

            case "Aditivos minerales":
                interactMessage += mat;
                interactMessage += "\n100 kg (sacos de 25kg)";
                break;

            default:
                Debug.Log("Material no reconocido");
                break;
        }

        // Cambiar los datos del material en el texto:
        textMaterial.text = interactMessage;
    }
}
