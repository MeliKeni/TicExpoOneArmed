using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generales : MonoBehaviour
{
    [Header("Configuración del timer")]
    public float tiempoMaximo = 60f; 
    private float tiempoActual;

    [Header("UI")]
    public Text textoTimer; 
    public GameObject panelFinTiempo; 
    public GameObject panelInicio; 

    [Header("Referencias de tareas")]
    public InteraccionBrazo brazo; // Script que tiene Task1Hecha
    public GameObject T1; // Elemento del canvas
    public Material materialNuevo; // Material que se asignará al completar la tarea

    private bool timerTerminado = false;
    private bool juegoIniciado = false;
    private bool tareaAplicada = false; // Para no aplicar el material varias veces

    void Start()
    {
        tiempoActual = tiempoMaximo;
        panelFinTiempo.SetActive(false);
        panelInicio.SetActive(true);
        ActualizarUI();
    }

    void Update()
    {
        // Reinicio manual con R
        if (Input.GetKeyDown(KeyCode.R))
        {
            panelInicio.SetActive(true);
            panelFinTiempo.SetActive(false);
            tiempoActual = tiempoMaximo;
            timerTerminado = false;
            juegoIniciado = false;
            tareaAplicada = false; // Reinicia estado del material
        }

        // Comenzar juego con Enter
        if (!juegoIniciado && Input.GetKeyDown(KeyCode.Return))
        {
            panelInicio.SetActive(false);
            juegoIniciado = true;
        }

        if (juegoIniciado && !timerTerminado)
        {
            // Countdown
            tiempoActual -= Time.deltaTime;
            if (tiempoActual <= 0f)
            {
                tiempoActual = 0f;
                timerTerminado = true;
                MostrarPanelFinTiempo();
            }

            ActualizarUI();
        }

        // Cambiar material si se completó la tarea
        if (brazo != null && brazo.Task1Hecha && !tareaAplicada)
        {
            CambiarMaterialT1();
            tareaAplicada = true;
        }
    }

    void MostrarPanelFinTiempo()
    {
        if (panelFinTiempo != null)
        {
            panelFinTiempo.SetActive(true);
        }
    }

    void ActualizarUI()
    {
        if (textoTimer != null)
        {
            textoTimer.text = Mathf.CeilToInt(tiempoActual).ToString();
        }
    }

    void CambiarMaterialT1()
    {
        if (T1 != null && materialNuevo != null)
        {
            Renderer rend = T1.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material = materialNuevo;
            }
        }
    }
}
