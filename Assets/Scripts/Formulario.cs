using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Formulario : MonoBehaviour
{
    public GameObject canvasFormulario;
    public GameObject canvasPregunta1;
    public GameObject canvasPregunta2;
    public GameObject canvasPregunta3;
    public int cantidadRespondidasCorrectamente = 0;
    public InteraccionBrazo brazo;
    public PuntajeScript puntajeScript;

    [Header("Recompensa")]
    public Image imagenRecompensa; // La imagen que aparece al completar el formulario

    private bool recompensaEntregada = false; // Para que solo se haga la primera vez

    void Start()
    {
        canvasFormulario.SetActive(false);
        canvasPregunta1.SetActive(false);
        canvasPregunta2.SetActive(false);
        canvasPregunta3.SetActive(false);
        cantidadRespondidasCorrectamente = 0;

        if (imagenRecompensa != null)
        {
            imagenRecompensa.gameObject.SetActive(false); // Empieza apagada
        }
    }

    void Update()
    {
        // Abrir formulario solo si el jugador está dentro del trigger del monitor 8
        if (Input.GetMouseButtonDown(0) && brazo != null && brazo.dentroDelTriggerMonitor8)
        {
            canvasFormulario.SetActive(true);
            canvasPregunta1.SetActive(true);
        }

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
            else if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.A))
            {
                canvasPregunta1.SetActive(false);
                canvasFormulario.SetActive(false);
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
                canvasFormulario.SetActive(false);
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
                canvasFormulario.SetActive(false);
            }
        }
    }

    // Coroutine para mostrar la recompensa y desvanecerla gradualmente
  private IEnumerator MostrarRecompensaGradual()
{
    imagenRecompensa.gameObject.SetActive(true);

    // Asegurarse que está completamente visible
    Color c = imagenRecompensa.color;
    c.a = 1f;
    imagenRecompensa.color = c;

    // 1️⃣ Esperar 3 segundos con alpha = 1
    yield return new WaitForSeconds(3f);

    // 2️⃣ Desvanecer durante 3 segundos
    float duracion = 3f;
    float tiempo = 0f;

    while (tiempo < duracion)
    {
        tiempo += Time.deltaTime;
        c.a = Mathf.Lerp(1f, 0f, tiempo / duracion);
        imagenRecompensa.color = c;
        yield return null;
    }

    // Apagar al final
    imagenRecompensa.gameObject.SetActive(false);
}

}
