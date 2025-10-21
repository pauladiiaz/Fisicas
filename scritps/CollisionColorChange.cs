using UnityEngine;

public class CollisionColorChange : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Muestra en consola el nombre del objeto con el que colisiona
        Debug.Log(gameObject.name + " colisionó con " + collision.gameObject.name);

        // Cambia el color a un color aleatorio
        Renderer rend = collision.gameObject.GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
