using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarBasura : MonoBehaviour
{
    public List<GameObject> BasuraTirada = new List<GameObject>();
    public Tasks tareas; // Referencia al script Tasks
    public PuntajeScript puntajeScript;
    private bool listo = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("Basura") && !BasuraTirada.Contains(other.gameObject))
        {
            BasuraTirada.Add(other.gameObject);

            // Apagar el renderer al entrar
            Renderer rend = other.gameObject.GetComponent<Renderer>();
            if (rend != null) rend.enabled = false;

            // Sumar a la tarea y al puntaje
            if (tareas != null)
            {
                tareas.SumarBasura(1); // ✅ Puede seguir sumando aunque ya esté completa
            }

            puntajeScript.SumarPuntaje(10);
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

            if (tareas != null)
            {
                tareas.SumarBasura(-1); // ✅ Opcional: si quieres que quitar basura reste progreso
            }

            puntajeScript.SumarPuntaje(-10);
            ActualizarConteo();
        }
    }

    private void ActualizarConteo()
    {
        if (!listo && tareas.EstaCompletaBasura() && tareas.pasoActual == Tasks.PasoTask.task1TirarBasura)
        {
            listo = true;
            Debug.Log("¡Tarea de basura completada!");
        }

        Debug.Log("Objetos en lista: " + BasuraTirada.Count);
    }

    private void Update()
    {
        if (listo && tareas.pasoActual == Tasks.PasoTask.task1TirarBasura)
        {
            tareas.AvanzarPaso();
        }
    }
}
