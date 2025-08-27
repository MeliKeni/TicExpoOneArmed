using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarBasuraII : MonoBehaviour
{
    public List<GameObject> BasuraTirada = new List<GameObject>();
    public List<GameObject> BasuraNoTirada = new List<GameObject>();
    public Tasks tareas; // Referencia al script Tasks
    public PuntajeScript puntajeScript;
    private bool listo = false;
    private float tiempoJugado = 0f;
    private bool basuraActivada = false;

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;

    private void Start()
    {
        // Desactivar toda la basura no tirada al inicio
        foreach (GameObject basura in BasuraNoTirada)
        {
            if (basura != null)
                basura.SetActive(false);
        }
    }

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
                tareas.SumarBasuraII(1);
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
                tareas.SumarBasuraII(-1);
            }

            puntajeScript.SumarPuntaje(-10);
            ActualizarConteo();
        }
    }

    private void ActualizarConteo()
    {
        if (!listo && tareas.EstaCompletaBasura() && tareas.pasoActual == Tasks.PasoTask.task5TirarBasuraII)
        {
            listo = true;
            Debug.Log("¡Tarea de basura completada!");
        }

        Debug.Log("Objetos en lista: " + BasuraTirada.Count);
    }

    private void Update()
    {
        if (listo && tareas.pasoActual == Tasks.PasoTask.task5TirarBasuraII)
        {
            tareas.AvanzarPaso();
        }

        // Sumar tiempo solo si todos los paneles están desactivados
        if (!panel1.activeSelf && !panel2.activeSelf && !panel3.activeSelf && !panel4.activeSelf)
        {
            tiempoJugado += Time.deltaTime;
        }

        // Mostrar la basura no tirada después de 100 segundos
        if (tiempoJugado >= 100f && !basuraActivada)
        {
            foreach (GameObject basura in BasuraNoTirada)
            {
                if (basura != null)
                    basura.SetActive(true);
            }
            basuraActivada = true;
            Debug.Log("¡Basura no tirada activada después de 100 segundos!");
        }
    }
}
