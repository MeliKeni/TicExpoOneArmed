using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Generales : MonoBehaviour
{
    [Header("Configuración del timer")]
    public float tiempoMaximo = 60f;
    private float tiempoActual;

    [Header("UI")]
    public Text textoTimer;            // TextMeshPro del contador
    public GameObject panelInicio1;        // Pantalla 1
    public GameObject panelInicio2;        // Pantalla 2
    public GameObject panelFinJuego;       // Pantalla final

    private enum UIState { Inicio1, Inicio2, Jugando, Fin }
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
          
        // ----- ATAJO GLOBAL: VOLVER AL INICIO -----
        if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            CambiarAInicio1();
            return;
        }

        // ----- ENTER: avanzar según el estado -----
        if (Input.GetKeyDown(KeyCode.Return)) // Enter
        {
            switch (estado)
            {
                case UIState.Inicio1:
                    CambiarAInicio2();
                    break;

                case UIState.Inicio2:
                    IniciarJuegoConTiempo();
                    break;

                case UIState.Fin:
                     SceneManager.LoadScene("L1");
                     break;
            }
        }

        // ----- TECLA 0: modo sin tiempo -----
        if (estado == UIState.Inicio2 && (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0)))
        {
            IniciarJuegoSinTiempo();
        }
        else if (estado == UIState.Jugando && modoSinTiempo &&
                 (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0)))
        {
            TerminarJuego();
        }

        // ----- TIMER (modo con tiempo) -----
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

    // ==================== ESTADOS / PANTALLAS ====================

    void CambiarAInicio1()
    {
        estado = UIState.Inicio1;
        panelInicio1.SetActive(true);
        panelInicio2.SetActive(false);
        panelFinJuego.SetActive(false);

        // Resetear variables
        modoSinTiempo = false;
        timerTerminado = false;
        tiempoActual = tiempoMaximo;

        // Mostrar/ocultar timer (opcional: oculto en menús)
        if (textoTimer) textoTimer.gameObject.SetActive(false);

        // Por si algún menú puso el tiempo en 0
        Time.timeScale = 1f;

        ActualizarUI();
    }

    void CambiarAInicio2()
    {
        estado = UIState.Inicio2;
        panelInicio1.SetActive(false);
        panelInicio2.SetActive(true);
        panelFinJuego.SetActive(false);

        if (textoTimer) textoTimer.gameObject.SetActive(false);
        Time.timeScale = 1f;
        
    }

    void IniciarJuegoConTiempo()
    {
        estado = UIState.Jugando;
        panelInicio2.SetActive(false);
        panelInicio1.SetActive(false);
        panelFinJuego.SetActive(false);

        modoSinTiempo = false;
        timerTerminado = false;
        tiempoActual = tiempoMaximo;

        // Asegura que el tiempo corra
        Time.timeScale = 1f;

        if (textoTimer) textoTimer.gameObject.SetActive(true);
        ActualizarUI();
    }

    void IniciarJuegoSinTiempo()
    {
        estado = UIState.Jugando;
        panelInicio2.SetActive(false);
        panelInicio1.SetActive(false);
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

        if (textoTimer) textoTimer.gameObject.SetActive(false);
        // Podrías pausar acá si querés: Time.timeScale = 0f;
    }

    // ==================== UI ====================

    void ActualizarUI()
    {
        if (textoTimer && !modoSinTiempo)
        {
            textoTimer.text = Mathf.CeilToInt(tiempoActual).ToString();
        }
    }
}
