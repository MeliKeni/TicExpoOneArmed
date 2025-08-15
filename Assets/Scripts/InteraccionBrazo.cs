using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionBrazo : MonoBehaviour
{
    public EmparejarCables tablero; // elementos de la UI a prender y apagar
    public GameObject panelCables;
    public GameObject Img_InteractionBG;
    public GameObject Img_InteractionBGF;

    [Header("Pantallas")]
    public GameObject pantallaMonitor1;
    public GameObject pantallaMonitor2;
    public GameObject pantallaMonitor3;
    public GameObject pantallaMonitor5;
    public GameObject pantallaMonitor6;
    public GameObject pantallaMonitor7;
    public GameObject pantallaMonitor8;
    public GameObject pantallaMonitor9;
    public GameObject pantallaMonitor10;
    public GameObject pantallaMonitor11;
    public GameObject pantallaMonitor12;
    public GameObject pantallaMonitor13;
    public GameObject pantallaMonitor14;
    public GameObject pantallaMonitor15;

    public bool puertaAbierta = false;
    public GameObject conversacion;
    public bool Task1Hecha = false;

    // Bools para ver qué abrir
    public bool dentroDelTriggerPc3 = false;
    public bool dentroDelTriggerMonitorT1 = false;
    private bool dentroDelTriggerMonitor1 = false;
    private bool dentroDelTriggerMonitor2 = false;
    private bool dentroDelTriggerMonitor3 = false;
    private bool dentroDelTriggerMonitor5 = false;
    private bool dentroDelTriggerMonitor6 = false;
    private bool dentroDelTriggerMonitor7 = false;
    private bool dentroDelTriggerMonitor8 = false;
    private bool dentroDelTriggerMonitor9 = false;
    private bool dentroDelTriggerMonitor10 = false;
    private bool dentroDelTriggerMonitor11 = false;
    private bool dentroDelTriggerMonitor12 = false;
    private bool dentroDelTriggerMonitor13 = false;
    private bool dentroDelTriggerMonitor14 = false;
    private bool dentroDelTriggerMonitor15 = false;

    private bool dentroDelTriggerPuerta = false;
    private bool dentroDelTriggerMep = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if (other.gameObject.name == "pc 3 TASK 1")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerPc3 = true;
        }
        if (other.gameObject.name == "monitor 3 TASK 1")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitorT1 = true;
        }
        if (other.gameObject.name == "monitor 1")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor1 = true;
        }
        if (other.gameObject.name == "monitor 2")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor2 = true;
        }
        if (other.gameObject.name == "monitor 4")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor3 = true;
        }
        if (other.gameObject.name == "monitor 5")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor5 = true;
        }
        if (other.gameObject.name == "monitor 6")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor6 = true;
        }
        if (other.gameObject.name == "monitor 7")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor7 = true;
        }
        if (other.gameObject.name == "monitor 8")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor8 = true;
        }
        if (other.gameObject.name == "monitor 9")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor9 = true;
        }
        if (other.gameObject.name == "monitor 10")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor10 = true;
        }
        if (other.gameObject.name == "monitor 11")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor11 = true;
        }
        if (other.gameObject.name == "monitor 12")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor12 = true;
        }
        if (other.gameObject.name == "monitor 13")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor13 = true;
        }
        if (other.gameObject.name == "monitor 14")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor14 = true;
        }
        if (other.gameObject.name == "monitor 15")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMonitor15 = true;
        }
        if (other.gameObject.name == "Puerta")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerPuerta = true;
        }
        if (other.gameObject.name == "Mep")
        {
            Img_InteractionBG.SetActive(true);
            dentroDelTriggerMep = true;
        }
        if (other.gameObject.name == "MouseRojo1" || other.gameObject.name == "MouseRojo2" ||
            other.gameObject.name == "MouseRojo3" || other.gameObject.name == "MouseRojo4")
        {
            Img_InteractionBGF.SetActive(true);
        }
        if (other.gameObject.name == "MouseAzul1" || other.gameObject.name == "MouseAzul2" ||
            other.gameObject.name == "MouseAzul3" || other.gameObject.name == "MouseAzul4")
        {
            Img_InteractionBGF.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Img_InteractionBG.SetActive(false);
        Img_InteractionBGF.SetActive(false);

        dentroDelTriggerPc3 = false;
        dentroDelTriggerMonitorT1 = false;
        dentroDelTriggerMonitor1 = false;
        dentroDelTriggerMonitor2 = false;
        dentroDelTriggerMonitor3 = false;
        dentroDelTriggerMonitor5 = false;
        dentroDelTriggerMonitor6 = false;
        dentroDelTriggerMonitor7 = false;
        dentroDelTriggerMonitor8 = false;
        dentroDelTriggerMonitor9 = false;
        dentroDelTriggerMonitor10 = false;
        dentroDelTriggerMonitor11 = false;
        dentroDelTriggerMonitor12 = false;
        dentroDelTriggerMonitor13 = false;
        dentroDelTriggerMonitor14 = false;
        dentroDelTriggerMonitor15 = false;
        
        dentroDelTriggerPuerta = false;
        dentroDelTriggerMep = false;
    }

    void Start()
    {
        pantallaMonitor1.SetActive(false);
        pantallaMonitor2.SetActive(false);
        pantallaMonitor3.SetActive(false);
        pantallaMonitor5.SetActive(false);
        pantallaMonitor6.SetActive(false);
        pantallaMonitor7.SetActive(false);
        pantallaMonitor8.SetActive(false);
        pantallaMonitor9.SetActive(false);
        pantallaMonitor10.SetActive(false);
        pantallaMonitor11.SetActive(false);
        pantallaMonitor12.SetActive(false);
        pantallaMonitor13.SetActive(false);
        pantallaMonitor14.SetActive(false);
        pantallaMonitor15.SetActive(false);
        
        conversacion.SetActive(false);
        Img_InteractionBGF.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dentroDelTriggerPc3)
            {
                panelCables.SetActive(true);
                tablero.colorI = null;
                tablero.colorD = null;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (dentroDelTriggerPc3)
            {
                panelCables.SetActive(true);
                tablero.colorI = null;
                tablero.colorD = null;
            }

            /*if(dentroDelTriggerMonitorTask1 == true){
                if (Task1Hecha == true)
                {
                    pantallaMonitort1.SetActive(true);
                }
                else
                {
                    mensajeError.SetActive(true);
                }
            }*/

            if (dentroDelTriggerMonitor1) pantallaMonitor1.SetActive(true);
            if (dentroDelTriggerMonitor2) pantallaMonitor2.SetActive(true);
            if (dentroDelTriggerMonitor3) pantallaMonitor3.SetActive(true);
            if (dentroDelTriggerMonitor5) pantallaMonitor5.SetActive(true);
            if (dentroDelTriggerMonitor6) pantallaMonitor6.SetActive(true);
            if (dentroDelTriggerMonitor7) pantallaMonitor7.SetActive(true);
            if (dentroDelTriggerMonitor8) pantallaMonitor8.SetActive(true);
            if (dentroDelTriggerMonitor9) pantallaMonitor9.SetActive(true);
            if (dentroDelTriggerMonitor10) pantallaMonitor10.SetActive(true);
            if (dentroDelTriggerMonitor11) pantallaMonitor11.SetActive(true);
            if (dentroDelTriggerMonitor12) pantallaMonitor12.SetActive(true);
            if (dentroDelTriggerMonitor13) pantallaMonitor13.SetActive(true);
            if (dentroDelTriggerMonitor14) pantallaMonitor14.SetActive(true);
            if (dentroDelTriggerMonitor15) pantallaMonitor15.SetActive(true);
            
            if (dentroDelTriggerPuerta) puertaAbierta = !puertaAbierta;
            if (dentroDelTriggerMep) conversacion.SetActive(true);
        }

        if (Input.GetMouseButtonDown(1))
        {
            panelCables.SetActive(false);
            tablero.mensajeError.SetActive(false);
            if (dentroDelTriggerMonitor1) pantallaMonitor1.SetActive(false);
            if (dentroDelTriggerMonitor2) pantallaMonitor2.SetActive(false);
            if (dentroDelTriggerMonitor3) pantallaMonitor3.SetActive(false);
            if (dentroDelTriggerMonitor5) pantallaMonitor5.SetActive(false);
            if (dentroDelTriggerMonitor6) pantallaMonitor6.SetActive(false);
            if (dentroDelTriggerMonitor7) pantallaMonitor7.SetActive(false);
            if (dentroDelTriggerMonitor8) pantallaMonitor8.SetActive(false);
            if (dentroDelTriggerMonitor9) pantallaMonitor9.SetActive(false);
            if (dentroDelTriggerMonitor10) pantallaMonitor10.SetActive(false);
            if (dentroDelTriggerMonitor11) pantallaMonitor11.SetActive(false);
            if (dentroDelTriggerMonitor12) pantallaMonitor12.SetActive(false);
            if (dentroDelTriggerMonitor13) pantallaMonitor13.SetActive(false);
            if (dentroDelTriggerMonitor14) pantallaMonitor14.SetActive(false);
            if (dentroDelTriggerMonitor15) pantallaMonitor15.SetActive(false);
            tablero.pantallaMonitort1.SetActive(false);
            conversacion.SetActive(false);
            Img_InteractionBGF.SetActive(false);
        }
    }
}
