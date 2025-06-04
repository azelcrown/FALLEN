using UnityEngine;

public class FeatherFallDynamic : MonoBehaviour
{
    private Rigidbody rb;

    // Movimiento lateral tipo pluma
    private float swaySpeed;
    private float swayAmount;
    private float swayOffset;

    // Viento dinámico
    private Vector3 windDirection;
    private float windChangeTimer;
    private float windChangeInterval;

    // Rotación
    private float rotationSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Ajustes físicos
        rb.mass = 0.05f;
        rb.drag = 4f;
        rb.angularDrag = 1.5f;

        // Variaciones por pluma
        swaySpeed = Random.Range(1.5f, 3.5f);
        swayAmount = Random.Range(0.3f, 0.7f);
        swayOffset = Random.Range(0f, 100f);
        rotationSpeed = Random.Range(5f, 20f);

        // Viento inicial y temporizador
        windChangeInterval = Random.Range(1.5f, 4f);
        UpdateWind();
    }

    void FixedUpdate()
    {
        // Movimiento de oscilación
        float sway = Mathf.Sin(Time.time * swaySpeed + swayOffset) * swayAmount;
        Vector3 swayForce = new Vector3(sway, 0f, 0f);

        // Aplicar fuerza total
        rb.AddForce(swayForce + windDirection * 0.2f, ForceMode.Force);

        // Rotación lenta para simular tumbo
        rb.AddTorque(Vector3.up * rotationSpeed * Time.fixedDeltaTime);

        // Temporizador de cambio de viento
        windChangeTimer += Time.fixedDeltaTime;
        if (windChangeTimer >= windChangeInterval)
        {
            UpdateWind();
        }
    }

    void UpdateWind()
    {
        windDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        windChangeTimer = 0f;
        windChangeInterval = Random.Range(2f, 5f);
    }
}
