using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    public enum ZoneType { ColorChange, DamageZone }
    public ZoneType zoneType;

    public Color colorInside = Color.red; // Color al entrar en la zona
    public Color colorOriginal;           // Guardaremos el color original
    private Renderer playerRenderer;

    public int damageAmount = 10;         // Cantidad de daño a aumentar
    private PlayerStats playerStats;      // Referencia a un script de stats del personaje

    private void Start()
    {
        // Si es zona de color, intentamos obtener Renderer del personaje
        if (zoneType == ZoneType.ColorChange)
        {
            playerRenderer = GameObject.FindWithTag("Player")?.GetComponent<Renderer>();
            if (playerRenderer != null)
                colorOriginal = playerRenderer.material.color;
        }

        // Si es zona de daño, buscamos PlayerStats
        if (zoneType == ZoneType.DamageZone)
        {
            playerStats = GameObject.FindWithTag("Player")?.GetComponent<PlayerStats>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (zoneType == ZoneType.ColorChange && playerRenderer != null)
            {
                playerRenderer.material.color = colorInside;
            }

            if (zoneType == ZoneType.DamageZone && playerStats != null)
            {
                playerStats.damage += damageAmount;
                Debug.Log("Daño aumentado a: " + playerStats.damage);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (zoneType == ZoneType.ColorChange && playerRenderer != null)
            {
                playerRenderer.material.color = colorOriginal;
            }
        }
    }
}
