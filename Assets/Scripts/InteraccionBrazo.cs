using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionBrazo : MonoBehaviour
{
    public EmparejarCables tablero; 
    public GameObject panelCables;
    public GameObject Img_InteractionBG; 

    [Header("Pantallas")]
    public GameObject pantallaMonitor1;
    public GameObject pantallaMonitor2;
    public GameObject pantallaMonitor3;
    public GameObject pantallaMonitor5;
    public GameObject pantallaMonitor6;
    public GameObject pantallaMonitor7;
    public GameObject pantallaMonitor8;
    public GameObject pantallaMonitor9;
    public GameObject pantallaMonitor10;
    public GameObject pantallaMonitor11;
    public GameObject pantallaMonitor12;
    public GameObject pantallaMonitor13;
    public GameObject pantallaMonitor14;
    public GameObject pantallaMonitor15;

    public bool puertaAbierta = false;
    public GameObject conversacion;
    public bool Task1Hecha = false;

    [Header("Tasks")]
    public GameObject cilindroObjetivo;   // asignar por inspector
    public Tasks tasksScript;             // asignar por inspector

    // Bools para ver qué abrir
    public bool dentroDelTriggerPc3 = false;
    public bool dentroDelTriggerMonitorT1 = false;
    private bool dentroDelTriggerMonitor1 = false;
    private bool dentroDelTriggerMonitor2 = false;
    private bool dentroDelTriggerMonitor3 = false;
    private bool dentroDelTriggerMonitor5 = false;
    private bool dentroDelTriggerMonitor6 = false;
    private bool dentroDelTriggerMonitor7 = false;
    public bool dentroDelTriggerMonitor8 = false;
    private bool dentroDelTriggerMonitor9 = false;
    private bool dentroDelTriggerMonitor10 = false;
    private bool dentroDelTriggerMonitor11 = false;
    private bool dentroDelTriggerMonitor12 = false;
    private bool dentroDelTriggerMonitor13 = false;
    private bool dentroDelTriggerMonitor14 = false;
    private bool dentroDelTriggerMonitor15 = false;

    private bool dentroDelTriggerPuerta = false;
    private bool dentroDelTriggerMep = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "pc 3 TASK 1") dentroDelTriggerPc3 = true;
        if (other.gameObject.name == "monitor 3 TASK 1") dentroDelTriggerMonitorT1 = true;
        if (other.gameObject.name == "monitor 1") dentroDelTriggerMonitor1 = true;
        if (other.gameObject.name == "monitor 2") dentroDelTriggerMonitor2 = true;
        if (other.gameObject.name == "monitor 4") dentroDelTriggerMonitor3 = true;
        if (other.gameObject.name == "monitor 5") dentroDelTriggerMonitor5 = true;
        if (other.gameObject.name == "monitor 6") dentroDelTriggerMonitor6 = true;
        if (other.gameObject.name == "monitor 7") dentroDelTriggerMonitor7 = true;
        if (other.gameObject.name == "monitor 8") dentroDelTriggerMonitor8 = true;
        if (other.gameObject.name == "monitor 9") dentroDelTriggerMonitor9 = true;
        if (other.gameObject.name == "monitor 10") dentroDelTriggerMonitor10 = true;
        if (other.gameObject.name == "monitor 11") dentroDelTriggerMonitor11 = true;
        if (other.gameObject.name == "monitor 12") dentroDelTriggerMonitor12 = true;
        if (other.gameObject.name == "monitor 13") dentroDelTriggerMonitor13 = true;
        if (other.gameObject.name == "monitor 14") dentroDelTriggerMonitor14 = true;
        if (other.gameObject.name == "monitor 15") dentroDelTriggerMonitor15 = true;
        if (other.gameObject.name == "Puerta") dentroDelTriggerPuerta = true;
        if (other.gameObject.name == "Mep") dentroDelTriggerMep = true;

        if (tasksScript != null && cilindroObjetivo != null && other.gameObject == cilindroObjetivo)
        {
            tasksScript.SendMessage("MostrarTextoYProgreso");
        }

        Img_InteractionBG.SetActive(true); 
    }

    private void OnTriggerExit(Collider other)
    {
        dentroDelTriggerPc3 = false;
        dentroDelTriggerMonitorT1 = false;
        dentroDelTriggerMonitor1 = false;
        dentroDelTriggerMonitor2 = false;
        dentroDelTriggerMonitor3 = false;
        dentroDelTriggerMonitor5 = false;
        dentroDelTriggerMonitor6 = false;
        dentroDelTriggerMonitor7 = false;
        dentroDelTriggerMonitor8 = false;
        dentroDelTriggerMonitor9 = false;
        dentroDelTriggerMonitor10 = false;
        dentroDelTriggerMonitor11 = false;
        dentroDelTriggerMonitor12 = false;
        dentroDelTriggerMonitor13 = false;
        dentroDelTriggerMonitor14 = false;
        dentroDelTriggerMonitor15 = false;
        dentroDelTriggerPuerta = false;
        dentroDelTriggerMep = false;

        Img_InteractionBG.SetActive(false); 
    }

    void Start()
    {
        pantallaMonitor1.SetActive(false);
        pantallaMonitor2.SetActive(false);
        pantallaMonitor3.SetActive(false);
        pantallaMonitor5.SetActive(false);
        pantallaMonitor6.SetActive(false);
        pantallaMonitor7.SetActive(false);
        pantallaMonitor8.SetActive(false);
        pantallaMonitor9.SetActive(false);
        pantallaMonitor10.SetActive(false);
        pantallaMonitor11.SetActive(false);
        pantallaMonitor12.SetActive(false);
        pantallaMonitor13.SetActive(false);
        pantallaMonitor14.SetActive(false);
        pantallaMonitor15.SetActive(false);

        conversacion.SetActive(false);
        Img_InteractionBG.SetActive(false);
        panelCables.SetActive(false); 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click izquierdo
        {
            // 🔹 PC3: abrir panel solo si estamos en el paso correcto
            if (dentroDelTriggerPc3)
            {
                if(tablero.tareas != null && tablero.tareas.pasoActual == Tasks.PasoTask.task2ArreglarCompu)
                {
                    panelCables.SetActive(!panelCables.activeSelf);
                    if (panelCables.activeSelf)
                    {
                        tablero.colorI = null;
                        tablero.colorD = null;
                    }
                    else
                    {
                        tablero.mensajeError.SetActive(false);
                    }
                }
                else
                {
                    tablero.mensajeError.SetActive(!tablero.mensajeError.activeSelf);
                }
            }

            // Monitores
            if (dentroDelTriggerMonitor1) pantallaMonitor1.SetActive(!pantallaMonitor1.activeSelf);
            if (dentroDelTriggerMonitor2) pantallaMonitor2.SetActive(!pantallaMonitor2.activeSelf);
            if (dentroDelTriggerMonitor3) pantallaMonitor3.SetActive(!pantallaMonitor3.activeSelf);
            if (dentroDelTriggerMonitor5) pantallaMonitor5.SetActive(!pantallaMonitor5.activeSelf);
            if (dentroDelTriggerMonitor6) pantallaMonitor6.SetActive(!pantallaMonitor6.activeSelf);
            if (dentroDelTriggerMonitor7) pantallaMonitor7.SetActive(!pantallaMonitor7.activeSelf);
            if (dentroDelTriggerMonitor8) pantallaMonitor8.SetActive(!pantallaMonitor8.activeSelf);
            if (dentroDelTriggerMonitor9) pantallaMonitor9.SetActive(!pantallaMonitor9.activeSelf);
            if (dentroDelTriggerMonitor10) pantallaMonitor10.SetActive(!pantallaMonitor10.activeSelf);
            if (dentroDelTriggerMonitor11) pantallaMonitor11.SetActive(!pantallaMonitor11.activeSelf);
            if (dentroDelTriggerMonitor12) pantallaMonitor12.SetActive(!pantallaMonitor12.activeSelf);
            if (dentroDelTriggerMonitor13) pantallaMonitor13.SetActive(!pantallaMonitor13.activeSelf);
            if (dentroDelTriggerMonitor14) pantallaMonitor14.SetActive(!pantallaMonitor14.activeSelf);
            if (dentroDelTriggerMonitor15) pantallaMonitor15.SetActive(!pantallaMonitor15.activeSelf);

            // Puerta
            if (dentroDelTriggerPuerta) puertaAbierta = !puertaAbierta;

            // Conversación
            if (dentroDelTriggerMep) conversacion.SetActive(!conversacion.activeSelf);
        }
    }
}
