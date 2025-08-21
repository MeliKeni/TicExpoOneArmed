using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmparejarCables : MonoBehaviour
{
    public Tasks tareas; // Referencia al script Tasks

    public InteraccionBrazo brazo;
    public GameObject unionRoja;
    public GameObject unionAzul;
    public GameObject unionVerde;
    public GameObject fuego;

    public string colorI = null;
    public string colorD = null;

    public GameObject pantallaMonitort1;
    public GameObject mensajeError;

    void Start()
    {
        pantallaMonitort1.SetActive(false);
        mensajeError.SetActive(false);

        brazo.panelCables.SetActive(false);
        brazo.Img_InteractionBG.SetActive(false);

        unionRoja.SetActive(false);
        unionAzul.SetActive(false);
        unionVerde.SetActive(false);
        fuego.SetActive(false);
    }

    private void Conecciones()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            colorI = "azul";
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            colorI = "rojo";
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            colorI = "verde";
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            colorD = "verde";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            colorD = "rojo";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            colorD = "azul";
        }
    }

    void Update()
    {
        Conecciones();

        if (colorD != null && colorI != null)
        {
            if (colorD == colorI)
            {
                if (colorD == "rojo")
                    unionRoja.SetActive(true);
                else if (colorD == "azul")
                    unionAzul.SetActive(true);
                else if (colorD == "verde")
                    unionVerde.SetActive(true);
            }
            else
            {
                fuego.SetActive(true);
                brazo.panelCables.SetActive(false);
            }

            colorD = null;
            colorI = null;

            // **Cuando se completan los 3 cables**
            if (unionRoja.activeInHierarchy && unionAzul.activeInHierarchy && unionVerde.activeInHierarchy)
            {
                brazo.Task1Hecha = true;
                Debug.Log("¡Task1Hecha completada!");

                // **Sumar 1 al progreso de la task de la computadora**
                if (tareas != null)
                {
                    tareas.AumentarGuardados(1);
                }

                // Avanzar al siguiente paso
                tareas.AvanzarPaso();
            }
        }

        // Mostrar pantalla o mensaje de error al clickear
        if (Input.GetMouseButtonDown(0))
        {
            if (brazo.dentroDelTriggerMonitorT1)
            {
                if (brazo.Task1Hecha)
                {
                    pantallaMonitort1.SetActive(!pantallaMonitort1.activeSelf);
                    mensajeError.SetActive(false);
                }
                else
                {
                    mensajeError.SetActive(!mensajeError.activeSelf);
                }
            }
        }
    }
}
