using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Variables de Raycast:
    LayerMask mask;
    private new Transform camera;
    public float rayDistance;

    // Declarar variables:
    private UIManager uiManager;
    private GameObject textUI;

    void Start()
    {
        mask = LayerMask.GetMask("Interactable");
        camera = transform.Find("MainCamera");

        // Obtener elementos gráficos UI:
        uiManager = FindObjectOfType<UIManager>();
        textUI = uiManager.textPick;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(camera.position, camera.forward * rayDistance, Color.red); // dibujar rayo
        // Raycast(origen, dirección, out hit, distancia, máscara)
        RaycastHit hit; // declarar
        if (Physics.Raycast(camera.position, camera.forward, out hit, rayDistance, mask))
        {
            if (!Pickable.up)
            {
                uiManager.ShowMessage(textUI);// Aparece el mnsj de la UI
            }
            if (Input.GetButtonDown("Pick")) // Al pulsar 'P':
            {
                Debug.Log("Levitando");
                uiManager.HideMessage(textUI); // desactiva el elemento de la interfaz
                hit.transform.GetComponent<Interactable>().Interact(); // Interactuar con el objeto
            }
        }
        else
        {
            // Si no hay colisión dentro del rango:
            uiManager.HideMessage(textUI); // desactiva el elemento de la interfaz
        }
    }

}
