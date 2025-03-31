using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private bool isOpen = false;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position; // Guardar la posici�n original
    }

    // Sobreescribe la funci�n Interact() para este tipo de objetos (Puertas):
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Puerta abierta");
        // Destroy(gameObject);
        OpenDoor(); // abrir la puerta         
    }

    public void OpenDoor()
    {
        // Obtener el ancho de la puerta
        float width = GetComponent<Renderer>().bounds.size.x / 2;

        // Rotar 90� alrededor del eje Y
        transform.Rotate(Vector3.up * 90);

        // Mover la puerta hacia la mitad de su ancho
        transform.position += transform.right * width;
    }

    public void ToggleDoor()
    {
        if (isOpen)
        {
            // Cerrar la puerta (restablecer posici�n y rotaci�n)
            transform.position = initialPosition;
            transform.rotation = Quaternion.identity;
        }
        else
        {
            // Obtener el ancho de la puerta
            float width = GetComponent<Renderer>().bounds.size.x / 2;

            // Rotar 90� alrededor del eje Y
            transform.Rotate(Vector3.up * 90);

            // Mover la puerta hacia la mitad de su ancho
            transform.position += transform.right * width;
        }

        isOpen = !isOpen; // Alternar estado de la puerta
    }
}
