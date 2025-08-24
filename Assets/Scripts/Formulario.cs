using UnityEngine;
using UnityEngine.UI;

public class Formulario : MonoBehaviour
{
    public GameObject canvasFormulario;
    public GameObject canvasPregunta1;
    public GameObject canvasPregunta2;
    public GameObject canvasPregunta3;
    public int cantidadRespondidasCorrectamente = 0;
    private bool preguntasRespondidas = false;
    public Tasks tareas;
    public InteraccionBrazo brazo;
    public PuntajeScript puntajeScript;

    void Start(){
        canvasFormulario.SetActive(false);
        canvasPregunta1.SetActive(false);
        canvasPregunta2.SetActive(false);
        canvasPregunta3.SetActive(false);
        cantidadRespondidasCorrectamente = 0;
    }
  

  


   void Update()
{
    tareas.guardadosTask4 = cantidadRespondidasCorrectamente;
    // Abrir formulario solo si el jugador está dentro del trigger del monitor 8
    if (Input.GetMouseButtonDown(0) && brazo != null && brazo.dentroDelTriggerMonitor8)
    {
        canvasFormulario.SetActive(true);
        canvasPregunta1.SetActive(true);
    }

    // Avanzar tarea si ya respondieron las preguntas
    if (preguntasRespondidas && tareas.pasoActual == Tasks.PasoTask.task4Forms)
    {
        tareas.AvanzarPaso();
    }

    // Control de respuestas por teclado
// Pregunta 1
if (canvasPregunta1.activeSelf)
{
    if (Input.GetKeyDown(KeyCode.B))
    {
        canvasPregunta1.SetActive(false);
        canvasPregunta2.SetActive(true);
        cantidadRespondidasCorrectamente = 1;
        puntajeScript.SumarPuntaje(15);
        return;
    }
    else if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.A))
    {
        canvasPregunta1.SetActive(false);
        canvasFormulario.SetActive(false);
    }
}

// Pregunta 2
if (canvasPregunta2.activeSelf)
{
    if (Input.GetKeyDown(KeyCode.C))
    {
        canvasPregunta2.SetActive(false);
        canvasPregunta3.SetActive(true);
        cantidadRespondidasCorrectamente = 2;
        puntajeScript.SumarPuntaje(15);
                return;

    }
    else if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.A))
    {
        canvasPregunta2.SetActive(false);
        canvasFormulario.SetActive(false);
    }
}

// Pregunta 3
if (canvasPregunta3.activeSelf)
{
    if (Input.GetKeyDown(KeyCode.A))
    {
        canvasPregunta3.SetActive(false);
        cantidadRespondidasCorrectamente = 3;
        puntajeScript.SumarPuntaje(15);
                preguntasRespondidas = true;

                return;

    }
    else if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C))
    {
        canvasPregunta3.SetActive(false);
        canvasFormulario.SetActive(false);
    }
}

}

}
