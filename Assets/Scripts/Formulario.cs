using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Formulario : MonoBehaviour
{
    public GameObject canvasFormulario;
    public GameObject canvasPregunta1;
    public GameObject canvasPregunta2;
    public GameObject canvasPregunta3;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;

    public int cantidadRespondidasCorrectamente = 0;
    public InteraccionBrazo brazo;
    public PuntajeScript puntajeScript;

    [Header("Recompensa")]
    public Image imagenRecompensa; // La imagen que aparece al completar el formulario

    private bool recompensaEntregada = false; // Para que solo se haga la primera vez
    private float tiempoJugado = 0f;
    private bool formularioMostrado = false;

    void Start()
    {
        // Apagar todos los canvas al inicio
        canvasFormulario.SetActive(false);
        canvasPregunta1.SetActive(false);
        canvasPregunta2.SetActive(false);
        canvasPregunta3.SetActive(false);

        if (imagenRecompensa != null)
            imagenRecompensa.gameObject.SetActive(false);
    }

    void Update()
    {
        // Contar tiempo jugado
        if(!panel1.activeSelf && !panel2.activeSelf && !panel3.activeSelf && !panel4.activeSelf)
        {
            tiempoJugado += Time.deltaTime;
        }
        // Mostrar formulario después de 100 segundos
        if (!formularioMostrado && tiempoJugado >= 100f)
        {
            formularioMostrado = true;
            canvasFormulario.SetActive(true);
            canvasPregunta1.SetActive(true);
        }

        // Procesar preguntas solo si el formulario ya fue mostrado
        if (formularioMostrado)
        {
            ProcesarPreguntas();
        }
    }

    private void ProcesarPreguntas()
    {
        // Pregunta 1
        if (canvasPregunta1.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                canvasPregunta1.SetActive(false);
                canvasPregunta2.SetActive(true);
                cantidadRespondidasCorrectamente = 1;
                return;
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
                return;
            }
            else if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.A))
            {
                canvasPregunta2.SetActive(false);
                canvasPregunta1.SetActive(true);
            }
        }

        // Pregunta 3
        if (canvasPregunta3.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                canvasPregunta3.SetActive(false);
                canvasFormulario.SetActive(false);
                cantidadRespondidasCorrectamente = 3;

                // Recompensa por completar por primera vez
                if (!recompensaEntregada && imagenRecompensa != null)
                {
                    recompensaEntregada = true;
                    puntajeScript.SumarPuntaje(50);
                    StartCoroutine(MostrarRecompensaGradual());
                }

                return;
            }
            else if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C))
            {
                canvasPregunta3.SetActive(false);
                canvasPregunta1.SetActive(true);
            }
        }
    }

    private IEnumerator MostrarRecompensaGradual()
    {
        imagenRecompensa.gameObject.SetActive(true);

        Color c = imagenRecompensa.color;
        c.a = 1f;
        imagenRecompensa.color = c;

        yield return new WaitForSeconds(3f);

        float duracion = 3f;
        float tiempo = 0f;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            c.a = Mathf.Lerp(1f, 0f, tiempo / duracion);
            imagenRecompensa.color = c;
            yield return null;
        }

        imagenRecompensa.gameObject.SetActive(false);
    }
}
