using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarBasura : MonoBehaviour
{
    public int CantidadTotalBasura = 10;
    public List<GameObject> BasuraTirada = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("Basura") && !BasuraTirada.Contains(other.gameObject))
        {
            BasuraTirada.Add(other.gameObject);

            // Apagar el renderer al entrar
            Renderer rend = other.gameObject.GetComponent<Renderer>();
            if (rend != null) rend.enabled = false;

            ActualizarConteo();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (BasuraTirada.Contains(other.gameObject))
        {
            BasuraTirada.Remove(other.gameObject);

            // Encender el renderer al salir
            Renderer rend = other.gameObject.GetComponent<Renderer>();
            if (rend != null) rend.enabled = true;

            ActualizarConteo();
        }
    }

    private void ActualizarConteo()
    {
        int CantidadBasuraTirada = BasuraTirada.Count;
        Debug.Log("Objetos en lista: " + CantidadBasuraTirada);

        if (CantidadBasuraTirada == CantidadTotalBasura)
        {
            Debug.Log("¡Todos los objetos están dentro! Mostrando texto.");
        }
    }
}
