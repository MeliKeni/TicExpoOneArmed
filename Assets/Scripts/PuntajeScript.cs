using UnityEngine;
using TMPro;

public class PuntajeScript : MonoBehaviour
{
    public static PuntajeScript instance;

    private int puntaje = 0;

    // Textos asignados por el Inspector
    public TextMeshProUGUI textoPuntaje;   // Puntaje en juego
    public TextMeshProUGUI textoPuntaje2;  // Puntaje final (panelFin)

    // Paneles asignados por el Inspector
    public GameObject panelInicio;  // (opcional, si lo usás)
    public GameObject panelFin;     // Este es el importante

    private bool puntajeMostradoEnFin = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        ActualizarTexto();
    }

    void Update()
    {
      

        // Si el panel de fin está activo y aún no mostramos el puntaje final
        if (panelFin != null && panelFin.activeSelf && !puntajeMostradoEnFin)
        {
            if (textoPuntaje2 != null)
                textoPuntaje2.text = puntaje.ToString();

            puntajeMostradoEnFin = true;
        }

        // Si el panel de fin ya no está activo, reiniciar puntaje y bandera
        if (panelFin != null && !panelFin.activeSelf && puntajeMostradoEnFin)
        {
            ReiniciarPuntaje();
            puntajeMostradoEnFin = false;
        }
    }

    public void SumarPuntaje(int cantidad)
    {
        puntaje += cantidad;
        ActualizarTexto();
    }

    public void RestarPuntaje(int cantidad)
    {
        puntaje -= cantidad;
        if (puntaje < 0) puntaje = 0;
        ActualizarTexto();
    }

    public void ReiniciarPuntaje()
    {
        puntaje = 0;
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        if (textoPuntaje != null)
            textoPuntaje.text = puntaje.ToString();
    }

    public int ObtenerPuntaje()
    {
        return puntaje;
    }
}
