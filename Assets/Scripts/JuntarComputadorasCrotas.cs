using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarComputadorasCrotas : MonoBehaviour
{
    public PuntajeScript puntajeScript;
    public int CantidadTotalComputadoras = 5;
    public List<GameObject> ComputadorasGuardadas = new List<GameObject>();

    public JuntarComputadoras pros; // referencia al otro script
    public Tasks tareas;

    private Dictionary<GameObject, Vector3> posicionesOriginales = new Dictionary<GameObject, Vector3>();
    private bool tareaListo = false;

    // Mantener la computadora actual en contacto con un carrito
    private GameObject computadoraEnContacto = null;

    private void Start()
    {
        GameObject[] todas = FindObjectsOfType<GameObject>();
        foreach (var obj in todas)
        {
            if (obj.name.StartsWith("computadora crota"))
            {
                posicionesOriginales[obj] = obj.transform.position;
            }
        }
    }

    private void Update()
    {
        // Avanzar de paso automáticamente si estamos en el paso correcto y tareaListo es true
        if (tareas != null &&
            tareas.pasoActual == Tasks.PasoTask.task3GuardarCompus &&
            tareaListo &&
            pros.TareaListaPro)
        {
            Debug.Log("¡Todas las computadoras guardadas y paso correcto! Avanzando...");
            tareas.AvanzarPaso();
            tareaListo = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("computadora crota"))
        {
            computadoraEnContacto = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (computadoraEnContacto != null && other.gameObject == computadoraEnContacto)
        {
            // Verificar si el carrito es correcto
            if (gameObject.name == "CarritoCorrecto") // cambiar según tu carrito correcto
            {
                // Correcto → apagar renderer y agregar
                Renderer rend = computadoraEnContacto.GetComponent<Renderer>();
                if (rend != null) rend.enabled = false;

                AgregarComputadora(computadoraEnContacto);
            }
            else
            {
                // Incorrecto → desaparecer
                computadoraEnContacto.SetActive(false);
            }

            computadoraEnContacto = null;
        }
    }

    public void AgregarComputadora(GameObject computadora)
    {
        if (!ComputadorasGuardadas.Contains(computadora))
        {
            ComputadorasGuardadas.Add(computadora);
            puntajeScript.SumarPuntaje(5);
            tareas.SumarComputadoraGuardada(1);

            if (ComputadorasGuardadas.Count == CantidadTotalComputadoras)
            {
                tareaListo = true;
            }

            ActualizarConteo();
        }
    }

    public void QuitarComputadora(GameObject computadora)
    {
        if (ComputadorasGuardadas.Contains(computadora))
        {
            ComputadorasGuardadas.Remove(computadora);
            Renderer rend = computadora.GetComponent<Renderer>();
            if (rend != null) rend.enabled = true;
            puntajeScript.SumarPuntaje(-5);

            if (ComputadorasGuardadas.Count < CantidadTotalComputadoras)
                tareaListo = false;

            ActualizarConteo();
        }
    }

    public void DevolverTodas()
    {
        foreach (var compu in ComputadorasGuardadas)
        {
            if (compu != null && posicionesOriginales.ContainsKey(compu))
            {
                compu.transform.position = posicionesOriginales[compu];
                compu.transform.rotation = Quaternion.identity;

                Renderer rend = compu.GetComponent<Renderer>();
                if (rend != null) rend.enabled = true;
            }
        }

        ComputadorasGuardadas.Clear();
        tareaListo = false;
        ActualizarConteo();
    }

    private void ActualizarConteo()
    {
        Debug.Log("Computadoras crota guardadas: " + ComputadorasGuardadas.Count);
    }
}
