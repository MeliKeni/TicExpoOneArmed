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
        completado
    }

    public PasoTask pasoActual = PasoTask.task1TirarBasura;

    public TextMeshPro texto2D;         // Texto principal de instrucciones
    public TextMeshPro progresoTexto2D; // Texto que muestra el progreso (ej: 3/10)

    [Header("Configuración de tareas")]
    public int totalTask1 = 10;  // Por ejemplo tirar basura tiene 5 cosas
    public int totalTask2 = 1;  // Arreglar computadora tiene 8 cosas
    public int totalTask3 = 10; // Guardar computadoras tiene 10 cosas

    private int totalPorTask;    // Total dinámico según task
    private int guardadosActual; // Cantidad guardada actualmente

    private Coroutine fadeCoroutineTexto;
    private Coroutine fadeCoroutineProgreso;

    void Start()
    {
        if (texto2D == null || progresoTexto2D == null)
        {
            Debug.LogError("No asignaste los textos 2D!");
            return;
        }

        // Inicializa valores según el primer paso
        ActualizarTotalPorTask();
        guardadosActual = 0;

        // Empieza oculto
        SetAlphaTexto(texto2D, 0f);
        SetAlphaTexto(progresoTexto2D, 0f);
        texto2D.gameObject.SetActive(false);
        progresoTexto2D.gameObject.SetActive(false);
    }

    public void AvanzarPaso()
    {
        if (pasoActual == PasoTask.completado)
        {
            Debug.Log("Ya se hicieron todas las tasks");
            return;
        }

        pasoActual++;
        ActualizarTotalPorTask();
        guardadosActual = 0; // Reset al cambiar de task
        Debug.Log("Avanzando al paso: " + pasoActual.ToString());
    }

    void ActualizarTotalPorTask()
    {
        switch (pasoActual)
        {
            case PasoTask.task1TirarBasura:
                totalPorTask = totalTask1;
                break;
            case PasoTask.task2ArreglarCompu:
                totalPorTask = totalTask2;
                break;
            case PasoTask.task3GuardarCompus:
                totalPorTask = totalTask3;
                break;
            case PasoTask.completado:
                totalPorTask = 0;
                break;
        }
    }

    public void AumentarGuardados(int cantidad = 1)
    {
        guardadosActual += cantidad;
        if (guardadosActual > totalPorTask) guardadosActual = totalPorTask;
    }

    void OnMouseDown()
    {
        MostrarTextoYProgreso();
    }

    void MostrarTextoYProgreso()
    {
        ActualizarTexto2D();
        ActualizarProgresoTexto();

        texto2D.gameObject.SetActive(true);
        progresoTexto2D.gameObject.SetActive(true);

        SetAlphaTexto(texto2D, 1f);
        SetAlphaTexto(progresoTexto2D, 1f);

        if (fadeCoroutineTexto != null) StopCoroutine(fadeCoroutineTexto);
        if (fadeCoroutineProgreso != null) StopCoroutine(fadeCoroutineProgreso);

        fadeCoroutineTexto = StartCoroutine(MostrarYDesvanecer(texto2D, 5f, 5f));
        fadeCoroutineProgreso = StartCoroutine(MostrarYDesvanecer(progresoTexto2D, 5f, 5f));
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
            case PasoTask.completado:
                texto2D.text = "¡Tareas completadas!";
                break;
        }
    }

    void ActualizarProgresoTexto()
    {
        progresoTexto2D.text = guardadosActual + " / " + totalPorTask;
    }

    IEnumerator MostrarYDesvanecer(TextMeshPro texto, float tiempoVisible, float tiempoFade)
    {
        yield return new WaitForSeconds(tiempoVisible);

        float tiempo = 0f;
        while (tiempo < tiempoFade)
        {
            tiempo += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, tiempo / tiempoFade);
            SetAlphaTexto(texto, alpha);
            yield return null;
        }

        SetAlphaTexto(texto, 0f);
        texto.gameObject.SetActive(false);
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
