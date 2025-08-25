using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Necesario para TextMeshPro

public class PuntajeScript : MonoBehaviour
{
    // Singleton para acceder desde otros scripts
    public static PuntajeScript instance;

    // Puntaje actual
    private int puntaje = 0;

    // Texto en Canvas para mostrar el puntaje (TextMeshPro)
    public TextMeshProUGUI textoPuntaje;

    // Panel de perder (asignar en Inspector)
    public GameObject panelInicio;

  

    void Start()
    {
        ActualizarTexto();
    }

    void Update()
    {
        // Reiniciar puntaje si el panel de perder está activo
        if (panelInicio != null && panelInicio.activeSelf)
        {
            ReiniciarPuntaje();
        }

    }

    // Método público para sumar puntaje
    public void SumarPuntaje(int cantidad)
    {
        puntaje += cantidad;
        ActualizarTexto();
    }

    // Método público para restar puntaje
    public void RestarPuntaje(int cantidad)
    {
        puntaje -= cantidad;
        if (puntaje < 0) puntaje = 0;
        ActualizarTexto();
    }

    // Reinicia puntaje a 0
    public void ReiniciarPuntaje()
    {
        puntaje = 0;
        ActualizarTexto();
    }

    // Actualiza el texto en pantalla
    void ActualizarTexto()
    {
        if (textoPuntaje != null)
        {
            textoPuntaje.text =  "Puntaje: " + puntaje.ToString();
        }
    }

    // Obtener puntaje actual
    public int ObtenerPuntaje()
    {
        return puntaje;
    }
}
