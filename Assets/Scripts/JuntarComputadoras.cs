using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarComputadoras : MonoBehaviour
{
    public int CantidadTotalComputadoras = 5;
    public List<GameObject> ComputadorasGuardadas = new List<GameObject>();
    public bool TareaListaPro = false;
    public Tasks tareas;

    // Diccionario para guardar la posición original de cada computadora
    private Dictionary<GameObject, Vector3> posicionesOriginales = new Dictionary<GameObject, Vector3>();

    // Lista de nombres de computadoras que queremos registrar
    public string[] nombresComputadoras = { "compu god", "computadora crota" };

    private void Start()
    {
        // Guardar la posición inicial de todas las computadoras que empiecen con los nombres indicados
        GameObject[] todas = FindObjectsOfType<GameObject>();
        foreach (var obj in todas)
        {
            foreach (var nombre in nombresComputadoras)
            {
                if (obj.name.StartsWith(nombre))
                {
                    posicionesOriginales[obj] = obj.transform.position;
                    break;
                }
            }
        }
    }

    public void AgregarComputadora(GameObject computadora)
    {
        if (!ComputadorasGuardadas.Contains(computadora))
        {
            ComputadorasGuardadas.Add(computadora);

            Renderer rend = computadora.GetComponent<Renderer>();
            if (rend != null) rend.enabled = false;

            ActualizarConteo();
tareas.SumarComputadoraGuardada(1);

        }
    }

    public void QuitarComputadora(GameObject computadora)
    {
        if (ComputadorasGuardadas.Contains(computadora))
        {
            ComputadorasGuardadas.Remove(computadora);

            Renderer rend = computadora.GetComponent<Renderer>();
            if (rend != null) rend.enabled = true;

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
    }

    private void ActualizarConteo()
    {
        Debug.Log("Computadoras guardadas: " + ComputadorasGuardadas.Count);

        if (ComputadorasGuardadas.Count == CantidadTotalComputadoras)
        {
            Debug.Log("¡Todas las computadoras guardadas!");
            TareaListaPro = true;
        }
    }
}
