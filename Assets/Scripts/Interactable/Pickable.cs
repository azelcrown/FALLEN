using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickable : Interactable
{
    public float distanciaFrente = 2f; // Distancia frente a la cámara
    public float velocidad = 2f;       // Velocidad del movimiento

    private Vector3 destino;
    private bool moviendo = false;
    private Rigidbody rb;

    private UIManager uiManager;
    private GameObject textUI;

    public override void Interact()
    {
        base.Interact(); // Sobreescribe la función Interact() para este tipo de objetos

        LevitatePickable(); // El objeto flota delante de la cámara y si no lo quiere, vuelve a caer.
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Empezamos sin gravedad
        rb.isKinematic = true; // Lo controlamos por script

        // Obtener elementos gráficos UI:
        uiManager = FindObjectOfType<UIManager>();
        textUI = uiManager.textSave;
    }

    void Update()
    {
        if (moviendo)
        {
            // Mover suavemente hacia el destino
            transform.position = Vector3.Lerp(transform.position, destino, Time.deltaTime * velocidad);

            // Si está lo suficientemente cerca, parar
            if (Vector3.Distance(transform.position, destino) < 0.01f)
            {
                transform.position = destino;
                moviendo = false;
                textUI.SetActive(true); // Aparece el mnsj de la UI
            }
        }
        if (Input.GetButtonDown("Guardar")) // Al pulsar 'G':
        {
            Guardar();
            textUI.SetActive(false); // desactivar el mnsj de la UI
            PlayerInteraction.playerScript.enabled = true; // activar el movimiento del Player
        } 
        else if (Input.GetButtonDown("Soltar")) // Al pulsar 'S':
        {
            Soltar();
            textUI.SetActive(false); // desactivar el mnsj de la UI
            PlayerInteraction.playerScript.enabled = true; // activar el movimiento del Player
        }
    }

    public void LevitatePickable()
    {
        rb.useGravity = false;
        rb.isKinematic = true;

        Camera cam = Camera.main;
        destino = cam.transform.position + cam.transform.forward * distanciaFrente; // Posición frente a la cámara
        destino.y = cam.transform.position.y; // Mantener la misma altura que la cámara

        moviendo = true;
    }

    public void Soltar()
    {
        moviendo = false;
        rb.isKinematic = false;
        rb.useGravity = true;
    }
    public void Guardar()
    {
        moviendo = false;
        Destroy(gameObject); // desaparece
        // Aquí habría q ir añadiendolos en una lista o array, aunq sea los nombres
        // para poder visualizarlos luego en el inventario, pero solo lo de la lista.
    }


}
