using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Pickable : Interactable
{
    public float distanciaFrente = 2f; // Distancia frente a la c�mara
    public float velocidad = 2f;       // Velocidad del movimiento

    private Vector3 destino;
    private Rigidbody rb;
    private bool moviendo = false;
    public static bool up = false;
    private bool haCaido = false;

    private UIManager uiManager;
    private GameObject textPick;
    private GameObject textSave;

    public AudioClip sonidoCaida;
    private AudioSource audioSource;
    //public ParticleSystem particulasCaida;

    public override void Interact()
    {
        base.Interact(); // Sobreescribe la funci�n Interact() para este tipo de objetos
        
        LevitatePickable(); // El objeto flota delante de la c�mara y si no lo quiere, vuelve a caer.
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Empezamos sin gravedad
        rb.isKinematic = true; // Lo controlamos por script

        // Obtener elementos gr�ficos UI:
        uiManager = FindObjectOfType<UIManager>();
        textPick = uiManager.textPick;
        textSave = uiManager.textSave;

        // Inicializar el audio:
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = sonidoCaida;
    }

    void Update()
    {
        if (moviendo)
        {
            // Mover suavemente hacia el destino
            transform.position = Vector3.Lerp(transform.position, destino, Time.deltaTime * velocidad);

            // Si est� lo suficientemente cerca, parar
            if (Vector3.Distance(transform.position, destino) < 0.01f)
            {
                transform.position = destino;
                moviendo = false;
            }
        }
        
    }

    public void LevitatePickable()
    {
        rb.useGravity = false;
        rb.isKinematic = true;

        Camera cam = Camera.main;
        destino = cam.transform.position + cam.transform.forward * distanciaFrente; // Posici�n frente a la c�mara
        destino.y = cam.transform.position.y; // Mantener la misma altura que la c�mara

        moviendo = true;
        haCaido = false;
    }

    public void Soltar()
    {
        rb.useGravity = true; // activar gravedad = caer
        rb.isKinematic = false;
        Debug.Log("Cae");
        haCaido = true;
    }
    public void Guardar()
    {
        Destroy(gameObject); // desaparece
        Debug.Log("Guardado");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si no hemos ca�do a�n y tocamos el suelo
        if (!haCaido && collision.relativeVelocity.y > 1f)
        {
            haCaido = true;

            if (sonidoCaida != null)
                audioSource.Play();

            /*if (particulasCaida != null)
                particulasCaida.Play();*/
        }
    }

}
