using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Nuevo bool para marcar si la tarea ya fue completada
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
    }

    private void Conecciones()
    {
        // Teclas del lado izquierdo
        if (Input.GetKeyDown(KeyCode.A)) colorI = "azul";
        if (Input.GetKeyDown(KeyCode.B)) colorI = "rojo";
        if (Input.GetKeyDown(KeyCode.C)) colorI = "verde";

        // Teclas del lado derecho
        if (Input.GetKeyDown(KeyCode.Alpha1)) colorD = "verde";
        if (Input.GetKeyDown(KeyCode.Alpha2)) colorD = "rojo";
        if (Input.GetKeyDown(KeyCode.Alpha3)) colorD = "azul";
    }

    void Update()
    {
        bool pasocorrecto = tareas.pasoActual == Tasks.PasoTask.task2ArreglarCompu;

        // 🔹 Abrir o cerrar panel siempre que estés en el trigger
        if (Input.GetMouseButtonDown(0) && brazo.dentroDelTriggerPc3)
        {
            brazo.panelCables.SetActive(!brazo.panelCables.activeSelf);
            if (brazo.panelCables.activeSelf)
            {
                colorI = null;
                colorD = null;
            }
            else
            {
                mensajeError.SetActive(false);
            }
        }

        // 🔹 Procesar conexiones por teclas solo si el panel está abierto
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
                }

                colorI = null;
                colorD = null;

                // 🔹 Marcar tarea completada si se conectaron los tres cables
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

        // 🔹 Avanzar de paso automáticamente si estás en el paso correcto y la tarea ya se completó
        if (pasocorrecto && tareaListo)
        {
            tareas.AvanzarPaso();
            tareaListo = false; // Reseteamos para que no avance varias veces
        }

        // 🔹 Mostrar pantalla del monitor
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
}
