using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarComputadorasCrotas : MonoBehaviour
{
    public int CantidadTotalComputadoras = 5;
    public List<GameObject> ComputadorasGuardadas = new List<GameObject>();

    public JuntarComputadoras pros;
    public Tasks tareas;

    // Diccionario para guardar la posición original de cada computadora
    private Dictionary<GameObject, Vector3> posicionesOriginales = new Dictionary<GameObject, Vector3>();

    private void Start()
    {
        // Guardar la posición inicial de todas las computadoras que empiecen con "computadora crota"
        GameObject[] todas = FindObjectsOfType<GameObject>();
        foreach (var obj in todas)
        {
            if (obj.name.StartsWith("computadora crota"))
            {
                posicionesOriginales[obj] = obj.transform.position;
            }
        }
    }

    public void AgregarComputadora(GameObject computadora)
    {
        if (!ComputadorasGuardadas.Contains(computadora))
        {
            ComputadorasGuardadas.Add(computadora);

            // Apagar render
            Renderer rend = computadora.GetComponent<Renderer>();
            if (rend != null) rend.enabled = false;

            ActualizarConteo();
        }
    }

    public void QuitarComputadora(GameObject computadora)
    {
        if (ComputadorasGuardadas.Contains(computadora))
        {
            ComputadorasGuardadas.Remove(computadora);

            // Volver a prender render
            Renderer rend = computadora.GetComponent<Renderer>();
            if (rend != null) rend.enabled = true;

            ActualizarConteo();
        }
    }

    // Devuelve todas las computadoras a su posición original
    public void DevolverTodas()
    {
        foreach (var compu in ComputadorasGuardadas)
        {
            if (compu != null && posicionesOriginales.ContainsKey(compu))
            {
                compu.transform.position = posicionesOriginales[compu];
                compu.transform.rotation = Quaternion.identity; // opcional: resetear rotación

                Renderer rend = compu.GetComponent<Renderer>();
                if (rend != null) rend.enabled = true;
            }
        }

        ComputadorasGuardadas.Clear();
    }

    private void ActualizarConteo()
    {
        Debug.Log("Computadoras guardadas: " + ComputadorasGuardadas.Count);

        if (ComputadorasGuardadas.Count == CantidadTotalComputadoras)
        {
            Debug.Log("¡Todas las computadoras guardadas!");
            if (pros.TareaListaPro == true)
                tareas.AvanzarPaso();
        }
    }
}
