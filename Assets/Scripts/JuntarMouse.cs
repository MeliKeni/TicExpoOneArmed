using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarMouse : MonoBehaviour
{
    public int CantidadTotalMouses = 10;
    public List<GameObject> MousesTiradas = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("mouse") && !MousesTiradas.Contains(other.gameObject))
        {
            MousesTiradas.Add(other.gameObject);

            // Apagar el renderer al entrar
            Renderer rend = other.gameObject.GetComponent<Renderer>();
            if (rend != null) rend.enabled = false;

            ActualizarConteo();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (MousesTiradas.Contains(other.gameObject))
        {
            MousesTiradas.Remove(other.gameObject);

            // Encender el renderer al salir
            Renderer rend = other.gameObject.GetComponent<Renderer>();
            if (rend != null) rend.enabled = true;

            ActualizarConteo();
        }
    }

    private void ActualizarConteo()
    {
        int CantidadMousesTirada = MousesTiradas.Count;
        Debug.Log("Objetos en lista: " + CantidadMousesTirada);

        if (CantidadMousesTirada == CantidadTotalMouses)
        {
            Debug.Log("¡Todos los objetos están dentro! Mostrando texto.");
        }
    }
}
