using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarComputadoras : MonoBehaviour
{
    public PuntajeScript puntajeScript;
    public int CantidadTotalComputadoras = 5;
    public List<GameObject> ComputadorasGuardadas = new List<GameObject>();
    public bool TareaListaPro = false;
    public Tasks tareas;

    private Dictionary<GameObject, Vector3> posicionesOriginales = new Dictionary<GameObject, Vector3>();
    public string[] nombresComputadoras = { "compu god", "computadora crota" };

    // Nuevo: saber si la computadora se está moviendo
    private bool agarrado = false;
    private GameObject computadoraActual;

    private void Start()
    {
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

    void Update()
    {
        // Detectar si se suelta la computadora
        if (agarrado && Input.GetMouseButtonUp(0))
        {
            agarrado = false;

            if (computadoraActual != null)
            {
                // Revisar si está en contacto con el carrito correcto
                if (computadoraActual.GetComponent<Collider>().bounds.Intersects(GameObject.Find("CarritoCorrecto").GetComponent<Collider>().bounds))
                {
                    AgregarComputadora(computadoraActual);
                }
                else
                {
                    // Si es incorrecto, desaparece
                    computadoraActual.SetActive(false);
                }

                computadoraActual = null;
            }
        }
    }

    private void OnMouseDown()
    {
        // Detectar si agarraron una computadora
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            foreach (var nombre in nombresComputadoras)
            {
                if (hit.collider.gameObject.name.StartsWith(nombre))
                {
                    computadoraActual = hit.collider.gameObject;
                    agarrado = true;

                    // Apagar el renderer antes de moverla
                    Renderer rend = computadoraActual.GetComponent<Renderer>();
                    if (rend != null) rend.enabled = false;
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
            puntajeScript.SumarPuntaje(5);
            tareas.SumarComputadoraGuardada(1);
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
