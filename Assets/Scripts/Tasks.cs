using UnityEngine;
using TMPro;
using UnityEngine.UI;  // Para Image
using System.Collections;

public class Tasks : MonoBehaviour
{
    public enum PasoTask
    {
        task1TirarBasura,
        task2ArreglarCompu,
        task3GuardarCompus,
      //  task4GuardarMouses,
        completado
    }

    public PasoTask pasoActual = PasoTask.task1TirarBasura;

    public TextMeshProUGUI textoUI;           // Texto para mostrar la tarea
    public GameObject objetoParaDesaparecer; // Objeto padre con imágenes (padre e hijos)

    private Image[] imagenes;
    private Coroutine fadeCoroutine;

    void Start()
    {
        if (objetoParaDesaparecer == null)
        {
            Debug.LogError("No asignaste el objeto para desaparecer!");
            return;
        }

        imagenes = objetoParaDesaparecer.GetComponentsInChildren<Image>();

        // Empieza oculto
        objetoParaDesaparecer.SetActive(false);
    }

    // Este método podés llamarlo desde otro script para avanzar de paso
    public void AvanzarPaso()
    {
        if (pasoActual == PasoTask.completado)
        {
            Debug.Log("Ya se hicieron todas las tasks");
            return;
        }

        pasoActual++;
        Debug.Log("Avanzando al paso: " + pasoActual.ToString());
    }

    void OnMouseDown()
    {
        MostrarTextoYFade();
    }

    // Método que muestra el texto y arranca el fade
    void MostrarTextoYFade()
    {
        if (textoUI == null || objetoParaDesaparecer == null) return;

        ActualizarTextoUI();

        // Reiniciamos imágenes visibles y mostramos el cartel
        SetAlphaDeImagenes(1f);
        objetoParaDesaparecer.SetActive(true);

        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(MostrarYDesvanecer(5f, 5f));
    }

    void ActualizarTextoUI()
    {
        if (textoUI == null) return;

        switch (pasoActual)
        {
            case PasoTask.task1TirarBasura:
                textoUI.text = "Tira la basura";
                break;

            case PasoTask.task2ArreglarCompu:
                textoUI.text = "Arregla la computadora";
                break;

            case PasoTask.task3GuardarCompus:
                textoUI.text = "Guarda las computadoras";
                break;

        /*    case PasoTask.task4GuardarMouses:
                textoUI.text = "Guarda los mouses";
                break;*/

            case PasoTask.completado:
                textoUI.text = "¡Tareas completadas!";
                break;
        }
    }

    IEnumerator MostrarYDesvanecer(float tiempoVisible, float tiempoFade)
    {
        yield return new WaitForSeconds(tiempoVisible);

        float tiempo = 0f;

        while (tiempo < tiempoFade)
        {
            tiempo += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, tiempo / tiempoFade);
            SetAlphaDeImagenes(alpha);
            yield return null;
        }

        SetAlphaDeImagenes(0f);
        objetoParaDesaparecer.SetActive(false);
    }

    void SetAlphaDeImagenes(float alpha)
    {
        foreach (var img in imagenes)
        {
            if (img != null)
            {
                Color c = img.color;
                c.a = alpha;
                img.color = c;
            }
        }
    }
}
