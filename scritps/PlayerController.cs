using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;       // Velocidad de movimiento
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evita que el personaje se caiga al girar
    }

    private void FixedUpdate()
    {
        // Leer input
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D o flechas
        float moveVertical = Input.GetAxis("Vertical");     // W/S o flechas

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Aplicar movimiento directamente al Rigidbody
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
