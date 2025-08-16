using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarComputadoras : MonoBehaviour

{
    public int CantidadTotalComputadoras = 5;
    public List<GameObject> ComputadorasGuardadas = new List<GameObject>();

    // Este método lo llaman los carritos
    public void AgregarComputadora(GameObject computadora)
    {
        if (!ComputadorasGuardadas.Contains(computadora))
        {
            ComputadorasGuardadas.Add(computadora);

            // Apagar render
            Renderer rend = computadora.GetComponent<Renderer>();
            if (rend != null) rend.enabled = false;

            ActualizarConteo();
        }
    }

    public void QuitarComputadora(GameObject computadora)
    {
        if (ComputadorasGuardadas.Contains(computadora))
        {
            ComputadorasGuardadas.Remove(computadora);

            // Volver a prender render
            Renderer rend = computadora.GetComponent<Renderer>();
            if (rend != null) rend.enabled = true;

            ActualizarConteo();
        }
    }

    private void ActualizarConteo()
    {
        Debug.Log("Computadoras guardadas: " + ComputadorasGuardadas.Count);

        if (ComputadorasGuardadas.Count == CantidadTotalComputadoras)
        {
            Debug.Log("¡Todas las computadoras guardadas!");
        }
    }
}