using UnityEngine;
using TMPro;
using System.Collections;

public class Tasks : MonoBehaviour
{
    public enum PasoTask
    {
        task1TirarBasura,
        task2ArreglarCompu,
        task3GuardarCompus,
        task4Forms,       // ← Nuevo paso agregado
        completado
    }

    public PasoTask pasoActual = PasoTask.task1TirarBasura;

    public TextMeshPro texto2D;         
    public TextMeshPro progresoTexto2D; 

    [Header("Configuración de tareas")]
    public int totalTask1 = 10;  
    public int totalTask2 = 1;   
    public int totalTask3 = 10;  
    public int totalTask4 = 3;   // ← Total de forms

    // Contadores independientes
    private int guardadosTask1 = 0;
    private int guardadosTask2 = 0;
    private int guardadosTask3 = 0;
    public int guardadosTask4 = 0; // ← Contador forms

    void Start()
    {
        if (texto2D == null || progresoTexto2D == null)
        {
            Debug.LogError("No asignaste los textos 2D!");
            return;
        }

        texto2D.gameObject.SetActive(true);
        progresoTexto2D.gameObject.SetActive(true);

        ActualizarTexto2D();
        ActualizarProgresoTexto();
    }

    void Update()
    {
        ActualizarTexto2D();
        ActualizarProgresoTexto();
    }

    public void AvanzarPaso()
    {
        if (pasoActual == PasoTask.completado)
        {
            Debug.Log("Ya se hicieron todas las tasks");
            return;
        }

        pasoActual++;
        Debug.Log("Avanzando al paso: " + pasoActual.ToString());

        ActualizarProgresoTexto();
    }

    // 🔹 Funciones independientes para cada tarea
    public void SumarBasura(int cantidad = 1)
    {
        guardadosTask1 += cantidad;
        if (guardadosTask1 > totalTask1) guardadosTask1 = totalTask1;

        if (pasoActual == PasoTask.task1TirarBasura)
            ActualizarProgresoTexto();
    }

    public void SumarComputadoraArreglada(int cantidad = 1)
    {
        guardadosTask2 += cantidad;
        if (guardadosTask2 > totalTask2) guardadosTask2 = totalTask2;

        if (pasoActual == PasoTask.task2ArreglarCompu)
            ActualizarProgresoTexto();
    }

    public void SumarComputadoraGuardada(int cantidad = 1)
    {
        guardadosTask3 += cantidad;
        if (guardadosTask3 > totalTask3) guardadosTask3 = totalTask3;

        if (pasoActual == PasoTask.task3GuardarCompus)
            ActualizarProgresoTexto();
    }

    public void SumarForm(int cantidad = 1)   // ← Nueva función para forms
    {
        guardadosTask4 += cantidad;
        if (guardadosTask4 > totalTask4) guardadosTask4 = totalTask4;

        if (pasoActual == PasoTask.task4Forms)
            ActualizarProgresoTexto();
    }

    void ActualizarTexto2D()
    {
        switch (pasoActual)
        {
            case PasoTask.task1TirarBasura:
                texto2D.text = "Tira la basura";
                break;
            case PasoTask.task2ArreglarCompu:
                texto2D.text = "Arregla la computadora";
                break;
            case PasoTask.task3GuardarCompus:
                texto2D.text = "Guarda las computadoras";
                break;
            case PasoTask.task4Forms:
                texto2D.text = "Completa el formulario";   // ← Texto para el nuevo paso
                break;
            case PasoTask.completado:
                texto2D.text = "¡Tareas completadas!";
                break;
        }
    }

    void ActualizarProgresoTexto()
    {
        switch (pasoActual)
        {
            case PasoTask.task1TirarBasura:
                progresoTexto2D.text = guardadosTask1 + " / " + totalTask1;
                break;
            case PasoTask.task2ArreglarCompu:
                progresoTexto2D.text = guardadosTask2 + " / " + totalTask2;
                break;
            case PasoTask.task3GuardarCompus:
                progresoTexto2D.text = guardadosTask3 + " / " + totalTask3;
                break;
            case PasoTask.task4Forms:
                progresoTexto2D.text = guardadosTask4 + " / " + totalTask4;   // ← Progreso forms
                break;
            case PasoTask.completado:
                progresoTexto2D.text = "";
                break;
        }
    }

    void SetAlphaTexto(TextMeshPro texto, float alpha)
    {
        if (texto != null)
        {
            Color c = texto.color;
            c.a = alpha;
            texto.color = c;
        }
    }
}
