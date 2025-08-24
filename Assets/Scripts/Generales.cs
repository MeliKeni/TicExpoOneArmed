using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Generales : MonoBehaviour
{
    [Header("Configuración del timer")]
    public float tiempoMaximo = 60f;
    private float tiempoActual;

    [Header("UI")]
    public Text textoTimer;            
    public GameObject panelInicio1;    
    public GameObject panelInicio2;    
    public GameObject panelInicio3;    // NUEVO PANEL
    public GameObject panelFinJuego;   

    private enum UIState { Inicio1, Inicio2, Inicio3, Jugando, Fin }
    private UIState estado = UIState.Inicio1;

    private bool modoSinTiempo = false;
    private bool timerTerminado = false;

    void Start()
    {
        tiempoActual = tiempoMaximo;
        CambiarAInicio1();
    }

    void Update()
    {
        // Atajo global para reiniciar
        if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            SceneManager.LoadScene("L1");
            CambiarAInicio1();
            return;
        }

        // Enter: avanzar por pantallas
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (estado)
            {
                case UIState.Inicio1:
                    CambiarAInicio2();
                    break;
                case UIState.Inicio2:
                    CambiarAInicio3();
                    break;
                case UIState.Inicio3:
                    IniciarJuegoConTiempo();
                    break;
                case UIState.Fin:
                    SceneManager.LoadScene("L1");
                    break;
            }
        }

        // Tecla 0: modo sin tiempo
        if (estado == UIState.Inicio3 && (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0)))
        {
            IniciarJuegoSinTiempo();
        }
        else if (estado == UIState.Jugando && modoSinTiempo &&
                 (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0)))
        {
            TerminarJuego();
        }

        // Timer con tiempo
        if (estado == UIState.Jugando && !modoSinTiempo && !timerTerminado)
        {
            tiempoActual -= Time.deltaTime;
            if (tiempoActual <= 0f)
            {
                tiempoActual = 0f;
                timerTerminado = true;
                TerminarJuego();
            }
            ActualizarUI();
        }
    }

    // ===== ESTADOS =====

    void CambiarAInicio1()
    {
        estado = UIState.Inicio1;
        panelInicio1.SetActive(true);
        panelInicio2.SetActive(false);
        panelInicio3.SetActive(false);
        panelFinJuego.SetActive(false);

        modoSinTiempo = false;
        timerTerminado = false;
        tiempoActual = tiempoMaximo;

        if (textoTimer) textoTimer.gameObject.SetActive(false);
        Time.timeScale = 1f;

        ActualizarUI();
    }

    void CambiarAInicio2()
    {
        estado = UIState.Inicio2;
        panelInicio1.SetActive(false);
        panelInicio2.SetActive(true);
        panelInicio3.SetActive(false);
        panelFinJuego.SetActive(false);

        if (textoTimer) textoTimer.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    void CambiarAInicio3()
    {
        estado = UIState.Inicio3;
        panelInicio1.SetActive(false);
        panelInicio2.SetActive(false);
        panelInicio3.SetActive(true);
        panelFinJuego.SetActive(false);

        if (textoTimer) textoTimer.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    void IniciarJuegoConTiempo()
    {
        estado = UIState.Jugando;
        panelInicio1.SetActive(false);
        panelInicio2.SetActive(false);
        panelInicio3.SetActive(false);
        panelFinJuego.SetActive(false);

        modoSinTiempo = false;
        timerTerminado = false;
        tiempoActual = tiempoMaximo;

        Time.timeScale = 1f;

        if (textoTimer) textoTimer.gameObject.SetActive(true);
        ActualizarUI();
    }

    void IniciarJuegoSinTiempo()
    {
        estado = UIState.Jugando;
        panelInicio1.SetActive(false);
        panelInicio2.SetActive(false);
        panelInicio3.SetActive(false);
        panelFinJuego.SetActive(false);

        modoSinTiempo = true;
        timerTerminado = false;

        Time.timeScale = 1f;

        if (textoTimer)
        {
            textoTimer.gameObject.SetActive(true);
            textoTimer.text = "∞";
        }
    }

    void TerminarJuego()
    {
        estado = UIState.Fin;
        panelFinJuego.SetActive(true);
        panelInicio1.SetActive(false);
        panelInicio2.SetActive(false);
        panelInicio3.SetActive(false);

        if (textoTimer) textoTimer.gameObject.SetActive(false);
    }

    // ===== UI =====
    void ActualizarUI()
    {
        if (textoTimer && !modoSinTiempo)
        {
            textoTimer.text = Mathf.CeilToInt(tiempoActual).ToString();
        }
    }
}
