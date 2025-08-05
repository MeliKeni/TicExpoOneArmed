using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3CajaAzul : MonoBehaviour
{
    public int CantidadTotalMouseAzules = 4;
    public GameObject TextoFinalAzul;
    public List<GameObject> ObjetosGuardados = new List<GameObject>();

    void Start()
    {
        TextoFinalAzul.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.StartsWith("MouseAzul") && !ObjetosGuardados.Contains(other.gameObject)) //si hay contacto con un mouse y ese mouse no esta en la lista ya
        {
            ObjetosGuardados.Add(other.gameObject); //agrega a la lista

            ActualizarConteo();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (ObjetosGuardados.Contains(other.gameObject)) //si  el objeto que sale esta en la lsita
        {
            ObjetosGuardados.Remove(other.gameObject); //sacamos al coso de la lista
            ActualizarConteo();
        }
    }
    private void ActualizarConteo()
    {
        int CantidadMouseAzulesGuardados = ObjetosGuardados.Count;
        Debug.Log("Objetos en lista: " + CantidadMouseAzulesGuardados);

        if (CantidadMouseAzulesGuardados == 4)
        {
            TextoFinalAzul.SetActive(true);
            Debug.Log("¡Todos los objetos están dentro! Mostrando texto.");

        }
        else
        {
            TextoFinalAzul.SetActive(false);
        }

    }
}
