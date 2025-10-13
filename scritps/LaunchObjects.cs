using UnityEngine;

public class LaunchObjects : MonoBehaviour
{
    public Rigidbody[] objetos; // Asignar los 3 objetos en el Inspector
    public float fuerza = 500f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            foreach (Rigidbody rb in objetos)
            {
                rb.AddForce(Vector3.forward * fuerza); // Lanza los objetos hacia adelante
            }
        }
    }
}