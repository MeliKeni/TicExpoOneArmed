using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3CajaRoja : MonoBehaviour
{
    // Start is called before the first frame update

    public int CantidadTotalMouseRojos = 4;
    public GameObject TextoFinalRojo;
    public List<GameObject> ObjetosGuardados = new List<GameObject>();

    void Start()
    {
        TextoFinalRojo.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.StartsWith("MouseRojo") && !ObjetosGuardados.Contains(other.gameObject)) //si hay contacto con un mouse y ese mouse no esta en la lista ya
        {
            ObjetosGuardados.Add(other.gameObject); //agrega a la 

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
        int CantidadMouseRojosGuardados = ObjetosGuardados.Count;
        Debug.Log("Objetos en lista: " + CantidadMouseRojosGuardados);

        if (CantidadMouseRojosGuardados == CantidadTotalMouseRojos)
        {
            TextoFinalRojo.SetActive(true);
            Debug.Log("¡Todos los objetos están dentro! Mostrando texto.");

        }
        else
        {
            TextoFinalRojo.SetActive(false);
        }

    }
    void Update()
    {
      
    }
}
