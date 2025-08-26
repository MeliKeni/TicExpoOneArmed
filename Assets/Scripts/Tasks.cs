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

    private int guardadosTask1 = 0;
    private int guardadosTask2 = 0;
    private int guardadosTask3 = 0;
    private int guardadosTask4 = 0;

    [Header("Imágenes de instrucciones")]
    public GameObject[] imagenesPasos;

    [Header("Textos de descripción por tarea")]
    public GameObject[] textosPasos;

    [Header("Texto de progreso (opcional)")]
    public TextMeshPro progresoTexto2D;

    [Header("Referencias de UI extras a mostrar después del tercer panel")]
    public GameObject extraUI1;
    public GameObject extraUI2;

    [Header("Referencia a Generales (estado del juego)")]
    public Generales scriptGenerales;

    void Start()
    {
        OcultarTodo();
    }

    void Update()
    {
        if (JuegoEmpezado())
        {
            ActualizarImagenes();
            ActualizarProgresoTexto();
        }
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

        if (JuegoEmpezado())
        {
            ActualizarImagenes();
            ActualizarProgresoTexto();
        }
    }

    public void SumarBasura(int cantidad = 1)
    {
        guardadosTask1 += cantidad;
        if (guardadosTask1 > totalTask1) guardadosTask1 = totalTask1;

        if (pasoActual == PasoTask.task1TirarBasura && JuegoEmpezado())
            ActualizarProgresoTexto();
    }

    public void SumarComputadoraArreglada(int cantidad = 1)
    {
        guardadosTask2 += cantidad;
        if (guardadosTask2 > totalTask2) guardadosTask2 = totalTask2;

        if (pasoActual == PasoTask.task2ArreglarCompu && JuegoEmpezado())
            ActualizarProgresoTexto();
    }

    public void SumarComputadoraGuardada(int cantidad = 1)
    {
        guardadosTask3 += cantidad;
        if (guardadosTask3 > totalTask3) guardadosTask3 = totalTask3;

        if (pasoActual == PasoTask.task3GuardarCompus && JuegoEmpezado())
            ActualizarProgresoTexto();
    }

    public void sumarMouses(int cantidad = 1)
    {
        guardadosTask4 += cantidad;
        if (guardadosTask4 > totalTask4) guardadosTask4 = totalTask4;

        if (pasoActual == PasoTask.task4JuntarMouses && JuegoEmpezado())
            ActualizarProgresoTexto();
    }

    void ActualizarImagenes()
    {
        for (int i = 0; i < imagenesPasos.Length; i++)
        {
            if (imagenesPasos[i] != null)
                imagenesPasos[i].SetActive(i == (int)pasoActual);
        }

        for (int i = 0; i < textosPasos.Length; i++)
        {
            if (textosPasos[i] != null)
                textosPasos[i].SetActive(i == (int)pasoActual);
        }

        bool mostrarExtras = ((int)pasoActual >= 2);

        if (extraUI1 != null)
            extraUI1.SetActive(mostrarExtras);

        if (extraUI2 != null)
            extraUI2.SetActive(mostrarExtras);
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

    public bool EstaCompletaBasura()
    {
        return guardadosTask1 >= totalTask1;
    }

    void OcultarTodo()
    {
        foreach (var img in imagenesPasos)
            if (img != null) img.SetActive(false);

        foreach (var texto in textosPasos)
            if (texto != null) texto.SetActive(false);

        if (progresoTexto2D != null)
            progresoTexto2D.text = "";

        if (extraUI1 != null)
            extraUI1.SetActive(false);

        if (extraUI2 != null)
            extraUI2.SetActive(false);
    }

    public void ApagarTextos()
    {
        foreach (var texto in textosPasos)
        {
            if (texto != null)
                texto.SetActive(false);
        }

        if (extraUI1 != null)
            extraUI1.SetActive(false);

        if (extraUI2 != null)
            extraUI2.SetActive(false);

        if (progresoTexto2D != null)
            progresoTexto2D.text = "";
    }

    bool JuegoEmpezado()
    {
        return scriptGenerales != null && scriptGenerales.EstaJugando();
    }
}
