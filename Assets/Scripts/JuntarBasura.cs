using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarBasura : MonoBehaviour
{
    public int CantidadTotalBasura = 10;
    public List<GameObject> BasuraTirada = new List<GameObject>();
    public Tasks tareas; // Referencia al script Tasks
    public PuntajeScript puntajeScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("Basura") && !BasuraTirada.Contains(other.gameObject))
        {
            BasuraTirada.Add(other.gameObject);

            // Apagar el renderer al entrar
            Renderer rend = other.gameObject.GetComponent<Renderer>();
            if (rend != null) rend.enabled = false;

            // **Sumar 1 a la cantidad guardada en la task**
            if (tareas != null)
            {
        tareas.SumarBasura(1);
            }

            ActualizarConteo();
            puntajeScript.SumarPuntaje(10);
        }
    }

/*************  ✨ Windsurf Command ⭐  *************/
/*******  50973e8a-524f-4ad8-8a32-854b0e68777c  *******/
    private void OnTriggerExit(Collider other)
    {
        if (BasuraTirada.Contains(other.gameObject))
        {
            BasuraTirada.Remove(other.gameObject);

            // Encender el renderer al salir
            Renderer rend = other.gameObject.GetComponent<Renderer>();
            if (rend != null) rend.enabled = true;

             if (tareas != null)
            {
        tareas.SumarBasura(-1);
            }

            ActualizarConteo();
            puntajeScript.SumarPuntaje(-10); // **Restar 1 a la cantidad guardada si sacan la basura**
          
        }
    }

    private void ActualizarConteo()
    {
        int CantidadBasuraTirada = BasuraTirada.Count;
        Debug.Log("Objetos en lista: " + CantidadBasuraTirada);

        if (CantidadBasuraTirada == CantidadTotalBasura)
        {
            Debug.Log("¡Todos los objetos están dentro! Mostrando texto.");
            tareas.AvanzarPaso();
        }
    }
}
