using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    public enum ZoneType { ColorChange, DamageZone }
    public ZoneType zoneType;

    public Color colorInside = Color.red; // Color al entrar en la zona
    public int damageAmount = 10;         // Cantidad de daño a aumentar

    private Color colorOriginal;          // Guardamos el color original al entrar

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (zoneType == ZoneType.ColorChange)
            {
                Renderer playerRenderer = other.GetComponent<Renderer>();
                if (playerRenderer != null)
                {
                    colorOriginal = playerRenderer.material.color; // Guardamos el color original
                    playerRenderer.material.color = colorInside;
                }
            }

            if (zoneType == ZoneType.DamageZone)
            {
                PlayerStats playerStats = other.GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    playerStats.damage += damageAmount;
                    Debug.Log("Daño aumentado a: " + playerStats.damage);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (zoneType == ZoneType.ColorChange)
            {
                Renderer playerRenderer = other.GetComponent<Renderer>();
                if (playerRenderer != null)
                {
                    playerRenderer.material.color = colorOriginal; // Restauramos el color guardado
                }
            }
        }
    }
}

