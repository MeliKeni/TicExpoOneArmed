using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Generales : MonoBehaviour
{
    [Header("Configuración del timer")]
    public float tiempoMaximo = 60f; // Segundos, se asigna desde Inspector
    private float tiempoActual;

    [Header("UI")]
    public Text textoTimer; // Arrastrar el Text de la UI desde el Inspector
    public GameObject panelFinTiempo; // Panel que se muestra cuando el tiempo termina
    public GameObject panelInicio; // Panel que se muestra al iniciar la escena

    private bool timerTerminado = false;
    private bool juegoIniciado = false;

    void Start()
    {
        tiempoActual = tiempoMaximo;
        panelFinTiempo.SetActive(false); // Panel de fin de tiempo oculto al inicio
        panelInicio.SetActive(true); // Panel de inicio visible al iniciar
        ActualizarUI();
    }

    void Update()
    {
        // Reinicio manual con R
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reinicia panel de inicio y detiene juego
            panelInicio.SetActive(true);
            panelFinTiempo.SetActive(false);
            tiempoActual = tiempoMaximo;
            timerTerminado = false;
            juegoIniciado = false;
            SceneManager.LoadScene("L1");
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
}
