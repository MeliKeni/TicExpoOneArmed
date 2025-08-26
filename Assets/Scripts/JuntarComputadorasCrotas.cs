using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarComputadorasCrotas : MonoBehaviour
{
    [Header("Puntaje y tareas")]
    public PuntajeScript puntajeScript;
    public Tasks tareas;
    public JuntarComputadoras pros; // referencia al otro script
    public int CantidadTotalComputadoras = 5;
    public List<GameObject> ComputadorasGuardadas = new List<GameObject>();
    public int carritosMuertos;


    [Header("Posiciones originales")]
    private Dictionary<GameObject, Vector3> posicionesOriginales = new Dictionary<GameObject, Vector3>();
    private bool tareaListo = false;

    private void Start()
    {
        // Guardar posiciones originales de todas las computadoras
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
        // Avanzar de paso automáticamente si se cumplieron las condiciones
        if (tareas != null &&
            tareas.pasoActual == Tasks.PasoTask.task3GuardarCompus &&
            tareaListo &&
            pros.TareaListaPro)
        {
            tareas.AvanzarPaso();
            tareaListo = false;
        }
    }

    // Apagar renderer y agregar automáticamente al contacto con el carrito correcto
    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.name.StartsWith("computadora crota")) return;

        if (gameObject.name == "CarritoCorrecto")
        {
            Renderer rend = other.gameObject.GetComponent<Renderer>();
            if (rend != null && rend.enabled)
            {
                rend.enabled = false; // Apagar renderer al entrar
                AgregarComputadora(other.gameObject);
            }
        }
    }

    // 🔹 Agregar computadora al conteo y puntaje
    public void AgregarComputadora(GameObject computadora)
    {
        if (!ComputadorasGuardadas.Contains(computadora))
        {
            ComputadorasGuardadas.Add(computadora);
            if (puntajeScript != null) puntajeScript.SumarPuntaje(5);
            if (tareas != null) tareas.SumarComputadoraGuardada(1);

            if (ComputadorasGuardadas.Count == CantidadTotalComputadoras)
                tareaListo = true;
                
            ActualizarConteo();
        }
    }

    // 🔹 Quitar computadora (reactivar renderer y restar puntaje)
    public void QuitarComputadora(GameObject computadora)
    {
        if (ComputadorasGuardadas.Contains(computadora))
        {
            ComputadorasGuardadas.Remove(computadora);

            Renderer rend = computadora.GetComponent<Renderer>();
            if (rend != null) rend.enabled = true;

            if (puntajeScript != null) puntajeScript.SumarPuntaje(-5);
            if (tareas != null) tareas.SumarComputadoraGuardada(-1);

            if (ComputadorasGuardadas.Count < CantidadTotalComputadoras)
                tareaListo = false;

            ActualizarConteo();
        }
    }

    // 🔹 Devolver todas las computadoras a su posición original
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
