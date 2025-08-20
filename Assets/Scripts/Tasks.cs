using UnityEngine;
using TMPro;
using UnityEngine.UI;  // Necesario para Image
using System.Collections;

public class Tasks : MonoBehaviour
{
    public enum PasoTask
    {
        task1TirarBasura,
        task2ArreglarCompu,
        task3GuardarCompus,
        task4GuardarMouses,
        completado
    }

    public PasoTask pasoActual = PasoTask.task1TirarBasura;

    public TextMeshProUGUI textoUI;        // Texto para mostrar la tarea
    public GameObject objetoParaDesaparecer;  // Objeto padre con imágenes (padre e hijos)

    private Image[] imagenes; // Array de todas las Images que estén en el objeto para desaparecer
    private Coroutine fadeCoroutine;

    void Start()
    {
        objetoParaDesaparecer.SetActive(false);
        if (objetoParaDesaparecer == null)
        {
            Debug.LogError("No asignaste el objeto para desaparecer!");
            return;
        }

        imagenes = objetoParaDesaparecer.GetComponentsInChildren<Image>();

        ActualizarTextoUI();

        // Aseguramos que todas las imágenes estén visibles al inicio
        SetAlphaDeImagenes(1f);

        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(MostrarYDesvanecer(5f, 5f));
    }

    public void AvanzarPaso()
    {
        if (pasoActual == PasoTask.completado)
        {
            Debug.Log("Ya se hicieron todas las tasks");
            return;
        }

        pasoActual++;
        Debug.Log("Avanzando al paso: " + pasoActual.ToString());
        ActualizarTextoUI();

        if (objetoParaDesaparecer == null)
        {
            Debug.LogError("No asignaste el objeto para desaparecer!");
            return;
        }

        // Reiniciamos las imágenes visibles
        SetAlphaDeImagenes(1f);
        objetoParaDesaparecer.SetActive(true);

        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(MostrarYDesvanecer(5f, 5f));
    }

    void OnMouseDown()
    {
        Debug.Log("hola");
        AvanzarPaso();
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

            case PasoTask.task4GuardarMouses:
                textoUI.text = "Guarda los mouses";
                break;

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
