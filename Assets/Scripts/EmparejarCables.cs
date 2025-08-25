using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesario para manejar la imagen y el alpha

public class EmparejarCables : MonoBehaviour
{
    public Tasks tareas; 
    public PuntajeScript puntajeScript;

    public InteraccionBrazo brazo;
    public GameObject unionRoja;
    public GameObject unionAzul;
    public GameObject unionVerde;
    public GameObject fuego;

    public string colorI = null;
    public string colorD = null;

    public GameObject pantallaMonitort1;
    public GameObject mensajeError;

    // ✅ Imagen que se va a mostrar por inspector
    public Image imagenError; 

    private bool tareaListo = false;

    void Start()
    {
        pantallaMonitort1.SetActive(false);
        mensajeError.SetActive(false);

        if (brazo != null)
            brazo.panelCables.SetActive(false);

        if (brazo != null && brazo.Img_InteractionBG != null)
            brazo.Img_InteractionBG.SetActive(false);

        unionRoja.SetActive(false);
        unionAzul.SetActive(false);
        unionVerde.SetActive(false);
        fuego.SetActive(false);

        if (imagenError != null)
            imagenError.gameObject.SetActive(false); // Ocultamos al inicio
    }

    private void Conecciones()
    {
        if (Input.GetKeyDown(KeyCode.A)) colorI = "azul";
        if (Input.GetKeyDown(KeyCode.B)) colorI = "rojo";
        if (Input.GetKeyDown(KeyCode.C)) colorI = "verde";

        if (Input.GetKeyDown(KeyCode.Alpha1)) colorD = "verde";
        if (Input.GetKeyDown(KeyCode.Alpha2)) colorD = "rojo";
        if (Input.GetKeyDown(KeyCode.Alpha3)) colorD = "azul";
    }

    void Update()
    {
        bool pasocorrecto = tareas.pasoActual == Tasks.PasoTask.task2ArreglarCompu;

        if (brazo.panelCables.activeInHierarchy)
        {
            Conecciones();

            if (colorI != null && colorD != null)
            {
                if (colorI == colorD)
                {
                    if (colorD == "rojo") unionRoja.SetActive(true);
                    else if (colorD == "azul") unionAzul.SetActive(true);
                    else if (colorD == "verde") unionVerde.SetActive(true);
                }
                else
                {
                    fuego.SetActive(true);
                    puntajeScript.SumarPuntaje(-30);
                    brazo.panelCables.SetActive(false);

                    // ✅ MOSTRAR IMAGEN 3 seg + FADE OUT en 3 seg
                    if (imagenError != null)
                        StartCoroutine(MostrarImagenError());
                }

                colorI = null;
                colorD = null;

                if (unionRoja.activeInHierarchy && unionAzul.activeInHierarchy && unionVerde.activeInHierarchy && !tareaListo)
                {
                    tareaListo = true;
                    Debug.Log("¡Tarea lista para avanzar!");
                    brazo.Task1Hecha = true;
                    puntajeScript.SumarPuntaje(50);
                    tareas.SumarComputadoraArreglada(1);
                    brazo.panelCables.SetActive(false);
                }
            }
        }

        if (pasocorrecto && tareaListo)
        {
            tareas.AvanzarPaso();
            tareaListo = false; 
        }

        if (Input.GetMouseButtonDown(0) && brazo.dentroDelTriggerMonitorT1)
        {
            if (brazo.Task1Hecha)
            {
                pantallaMonitort1.SetActive(!pantallaMonitort1.activeSelf);
                mensajeError.SetActive(false);
            }
            else
            {
                mensajeError.SetActive(!mensajeError.activeSelf);
            }
        }
    }

    // ✅ Corutina para mostrar imagen y luego desvanecerla
    private IEnumerator MostrarImagenError()
    {
        imagenError.gameObject.SetActive(true);

        // Alpha al 100%
        Color color = imagenError.color;
        color.a = 1f;
        imagenError.color = color;

        // Espera 3 segundos
        yield return new WaitForSeconds(3f);

        // Desvanece en 3 segundos
        float tiempo = 0f;
        while (tiempo < 3f)
        {
            tiempo += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, tiempo / 3f);
            imagenError.color = color;
            yield return null;
        }

        imagenError.gameObject.SetActive(false);
    }
}
