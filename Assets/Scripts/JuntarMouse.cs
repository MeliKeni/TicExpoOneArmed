using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarMouse : MonoBehaviour
{
    public int CantidadTotalMouses = 5;
    public List<GameObject> MousesTiradas = new List<GameObject>();
    public Tasks tareas;
    private bool pasocorrecto = false;
    public PuntajeScript puntajeScript;

    void Update()
    {
        if (pasocorrecto && tareas.pasoActual == Tasks.PasoTask.task4JuntarMouses)
        {
            tareas.AvanzarPaso();
            pasocorrecto = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("mouse") && !MousesTiradas.Contains(other.gameObject))
        {
            // Agregar a la lista permanente
            MousesTiradas.Add(other.gameObject);

            // Antes de destruir, desactivamos física y colisiones
            Rigidbody rb = other.attachedRigidbody;
            if (rb != null) rb.isKinematic = true;

            Collider col = other.GetComponent<Collider>();
            if (col != null) col.enabled = false;

            // Sumar puntaje y progreso de tarea
            puntajeScript.SumarPuntaje(5);
            tareas.sumarMouses(1);

            // Verificar conteo
            ActualizarConteo();

            // Iniciamos coroutine que destruye al soltar
            StartCoroutine(DestruirAlSoltar(other.gameObject));
        }
    }

    private IEnumerator DestruirAlSoltar(GameObject mouse)
    {
        // Esperamos hasta que el Rigidbody ya no sea agarrado
        Rigidbody rb = mouse.GetComponent<Rigidbody>();
        while (rb != null && !rb.isKinematic) // o tu condición de "suelto" según tu sistema
        {
            yield return null;
        }

        // Destruir
        Destroy(mouse);
    }

    private void ActualizarConteo()
    {
        int CantidadMousesGuardados = MousesTiradas.Count;
        Debug.Log("Objetos guardados: " + CantidadMousesGuardados);

        if (CantidadMousesGuardados == CantidadTotalMouses)
        {
            Debug.Log("¡Todos los objetos fueron guardados!");
            pasocorrecto = true;
        }
    }
}
