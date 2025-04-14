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
    public static FirstPersonController playerScript;

    void Start()
    {
        mask = LayerMask.GetMask("Interactable");
        camera = transform.Find("MainCamera");
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();

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
            Selected(); // Aparece el mnsj de la UI
            Debug.Log("Pulsar P");
            if (Input.GetButtonDown("Pick")) // Al pulsar 'P':
            {
                Debug.Log("Recoger");
                //playerScript.enabled = false; // para q el Player no pueda moverse
                hit.transform.GetComponent<Interactable>().Interact(); // Interactuar con el objeto
            }
        }
        else
        {
            // Si no hay colisión dentro del rango:
            Deselected(); // desactiva el elemento de la interfaz
        }
    }

    void Selected()
    {
        textUI.SetActive(true); // Aparece el mnsj de la UI
    }
    void Deselected()
    {
        textUI.SetActive(false); // desactivar el mnsj de la UI
    }


}
