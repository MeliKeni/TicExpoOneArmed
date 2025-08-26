using UnityEngine;
using TMPro;

public class Tasks : MonoBehaviour
{
    public enum PasoTask
    {
        task2ArreglarCompu,
        task1TirarBasura,
        task4JuntarMouses,
        task3GuardarCompus,
        completado
    }

    public PasoTask pasoActual = PasoTask.task3GuardarCompus;

    [Header("Configuración de tareas")]
    public int totalTask1 = 5;
    public int totalTask2 = 1;
    public int totalTask3 = 10;
    public int totalTask4 = 5;

    // Contadores independientes
    private int guardadosTask1 = 0;
    private int guardadosTask2 = 0;
    private int guardadosTask3 = 0;
    private int guardadosTask4 = 0;

    [Header("Imágenes de instrucciones")]
    public GameObject[] imagenesPasos; // Asigna las imágenes por inspector (en el mismo orden que el enum)

    [Header("Texto de progreso (opcional)")]
    public TextMeshPro progresoTexto2D; // Si quieres seguir mostrando el progreso en texto

    void Start()
    {
        ActualizarImagenes();
        ActualizarProgresoTexto();
    }

    void Update()
    {
        ActualizarImagenes();
        ActualizarProgresoTexto();
    }

    public void AvanzarPaso()
    {
        if (pasoActual == PasoTask.completado)
        {
            Debug.Log("Todas las tareas completadas");
            return;
        }

        pasoActual++;
        Debug.Log("Avanzando al paso: " + pasoActual.ToString());

        ActualizarImagenes();
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

    public void sumarMouses(int cantidad = 1)
    {
        guardadosTask4 += cantidad;
        if (guardadosTask4 > totalTask4) guardadosTask4 = totalTask4;

        if (pasoActual == PasoTask.task4JuntarMouses)
            ActualizarProgresoTexto();
    }

    void ActualizarImagenes()
    {
        for (int i = 0; i < imagenesPasos.Length; i++)
        {
            if (imagenesPasos[i] != null)
            {
                imagenesPasos[i].SetActive(i == (int)pasoActual);
            }
        }
    }

    void ActualizarProgresoTexto()
    {
        if (progresoTexto2D == null) return;

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
            case PasoTask.task4JuntarMouses:
                progresoTexto2D.text = guardadosTask4 + " / " + totalTask4;
                break;
            case PasoTask.completado:
                progresoTexto2D.text = "";
                break;
        }
    }

    // ✅ NUEVO: método público para verificar si ya se juntó toda la basura
    public bool EstaCompletaBasura()
    {
        return guardadosTask1 >= totalTask1;
    }
}
