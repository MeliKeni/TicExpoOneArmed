using UnityEngine;
using UnityEngine.UI;

public class FormularioMonitor : MonoBehaviour
{
    public GameObject canvasFormulario; // Asignar el Canvas del formulario
    public Image[] imagenes; // Array de las imágenes que se van mostrando en orden
    public Button botonA;
    public Button botonB;
    public Button botonC;

    private int preguntaActual = 0;
    private int aciertosConsecutivos = 0;
    private bool[] respondido; // Para que cada pregunta solo sume una vez

    // Definir respuestas correctas: 0 = A, 1 = B, 2 = C
    private int[] respuestasCorrectas = { 1, 2, 0 }; // Pregunta1=B, Pregunta2=C, Pregunta3=A

    private void Start()
    {
        canvasFormulario.SetActive(false);
        respondido = new bool[imagenes.Length];

        botonA.onClick.AddListener(() => Responder(0));
        botonB.onClick.AddListener(() => Responder(1));
        botonC.onClick.AddListener(() => Responder(2));
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica que sea la mano o la esfera que interactúa
        if (other.CompareTag("PlayerHand")) // Asignar el tag correcto a la mano
        {
            IniciarFormulario();
        }
    }

    private void IniciarFormulario()
    {
        canvasFormulario.SetActive(true);
        preguntaActual = 0;
        aciertosConsecutivos = 0;
        MostrarPregunta(preguntaActual);
    }

    private void MostrarPregunta(int index)
    {
        for (int i = 0; i < imagenes.Length; i++)
            imagenes[i].gameObject.SetActive(i == index);
    }

    private void Responder(int opcion)
    {
        if (preguntaActual >= imagenes.Length) return;

        // Verifica si la respuesta es correcta
        if (opcion == respuestasCorrectas[preguntaActual])
        {
            aciertosConsecutivos++;
            if (!respondido[preguntaActual])
            {
                respondido[preguntaActual] = true;
            }
        }
        else
        {
            // Si falla, se apaga el canvas
            canvasFormulario.SetActive(false);
            Debug.Log("Error en la pregunta. Formulario reiniciado.");
            return;
        }

        preguntaActual++;

        if (preguntaActual < imagenes.Length)
        {
            MostrarPregunta(preguntaActual);
        }
        else
        {
            canvasFormulario.SetActive(false);
            Debug.Log("Formulario completado correctamente!");
        }
    }
}
