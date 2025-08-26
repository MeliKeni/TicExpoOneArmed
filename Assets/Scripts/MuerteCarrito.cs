using System.Collections;
using UnityEngine;

public class MuerteCarrito : MonoBehaviour
{
    public JuntarComputadoras god;
    public JuntarComputadorasCrotas crotas;
    public GameObject logro;
    public PuntajeScript puntajeScript;

    private CanvasGroup canvasGroup;
    private bool logroMostrado = false;

    void Start()
    {
        canvasGroup = logro.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            Debug.LogError("El objeto 'logro' necesita un CanvasGroup!");

        logro.SetActive(false);
    }

    void Update()
    {
        if (!logroMostrado && god.carritosMuertos == 3 && crotas.carritosMuertos == 3)
        {
            logroMostrado = true;
            StartCoroutine(MostrarYDesvanecerLogro());
            puntajeScript.SumarPuntaje(-10);
        }
    }

    private IEnumerator MostrarYDesvanecerLogro()
    {
        logro.SetActive(true);
        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(3f);

        float tiempo = 0f;
        float duracion = 3f;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, tiempo / duracion);
            yield return null;
        }

        logro.SetActive(false);
    }
}
