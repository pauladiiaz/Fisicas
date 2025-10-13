using UnityEngine;

public class CollisionColorChange : MonoBehaviour
{
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend == null)
            Debug.LogWarning("No Renderer found on " + gameObject.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Muestra en consola el nombre del objeto con el que colisiona
        Debug.Log(gameObject.name + " colisionó con " + collision.gameObject.name);

        // Cambia el color a un color aleatorio
        if (rend != null)
        {
            rend.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}