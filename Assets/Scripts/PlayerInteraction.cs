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
    private GameObject textSave;

    // Objeto recogido actualmente
    private Pickable pickeadoActual;

    void Start()
    {
        mask = LayerMask.GetMask("Interactable");
        camera = transform.Find("MainCamera");

        // Obtener elementos gráficos UI:
        uiManager = FindObjectOfType<UIManager>();
        textUI = uiManager.textPick;
        textSave = uiManager.textSave;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(camera.position, camera.forward * rayDistance, Color.red); // dibujar rayo
        // Raycast(origen, dirección, out hit, distancia, máscara)
        RaycastHit hit; // declarar

        if (pickeadoActual == null)
        {
            if (Physics.Raycast(camera.position, camera.forward, out hit, rayDistance, mask))
            {
                uiManager.ShowMessage(textUI); // Aparece el mnsj de la UI

                if (Input.GetButtonDown("Pick")) // Al pulsar 'P':
                {
                    Debug.Log("Levitando");
                    uiManager.HideMessage(textUI); // desactiva el elemento de la interfaz

                    Interactable i = hit.transform.GetComponent<Interactable>();
                    i.Interact(); // esto internamente hace levitar el objeto con LevitatePickable()

                    pickeadoActual = i as Pickable;
                    if (pickeadoActual != null) // Si hay algún objeto interactivo recogido / levitando en este momento
                    {
                        uiManager.ShowMessage(textSave); // Aparece el segundo mnsj de la UI
                    }
                }
            }
            else
            {
                // Si no hay colisión dentro del rango:
                uiManager.HideMessage(textUI); // desactiva el elemento de la interfaz
            }
        }
        else
        {
            // Ya hay un pickeado activo, escuchamos para soltar o guardar
            if (Input.GetButtonDown("Guardar"))
            {
                Debug.Log("Guardado"); // Al pulsar 'G':
                pickeadoActual.Guardar();
                pickeadoActual = null;
                uiManager.HideMessage(textSave); // desactivar el mnsj de la UI
            }
            else if (Input.GetButtonDown("Soltar")) // Al pulsar 'S':
            {
                Debug.Log("Soltar");
                pickeadoActual.Soltar();
                pickeadoActual = null;
                uiManager.HideMessage(textSave); // desactivar el mnsj de la UI
            }
        }

    }

}
