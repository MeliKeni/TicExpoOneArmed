using UnityEngine;
using System;
using System.Reflection;

public class AlembicController : MonoBehaviour
{
    public GameObject abcObject; // Asignar el GameObject Alembic en el Inspector
    private Component abcPlayer; // Usamos Component genérico
    private MethodInfo playMethod;
    private MethodInfo pauseMethod;
    private MethodInfo stopMethod;
    private PropertyInfo playAutoProperty;
    private PropertyInfo speedProperty;

    void Start()
    {
        if (abcObject == null)
        {
            Debug.LogError("Asigná un GameObject Alembic.");
            return;
        }

        // Buscar cualquier componente llamado "AlembicStreamPlayer"
        abcPlayer = abcObject.GetComponent("AlembicStreamPlayer");
        if (abcPlayer == null)
        {
            Debug.LogError("AlembicStreamPlayer no encontrado en el GameObject.");
            return;
        }

        // Obtener métodos y propiedades vía reflexión
        Type type = abcPlayer.GetType();
        playMethod = type.GetMethod("Play");
        pauseMethod = type.GetMethod("Pause");
        stopMethod = type.GetMethod("Stop");
        playAutoProperty = type.GetProperty("playAutomatically");
        speedProperty = type.GetProperty("speed");

        // Configurar propiedades iniciales
        if (playAutoProperty != null) playAutoProperty.SetValue(abcPlayer, false);
        if (speedProperty != null) speedProperty.SetValue(abcPlayer, 1f);
    }

    void Update()
    {
        if (abcPlayer == null) return;

        if (Input.GetKeyDown(KeyCode.P) && playMethod != null)
            playMethod.Invoke(abcPlayer, null);

        if (Input.GetKeyDown(KeyCode.O) && pauseMethod != null)
            pauseMethod.Invoke(abcPlayer, null);

        if (Input.GetKeyDown(KeyCode.R) && stopMethod != null && playMethod != null)
        {
            stopMethod.Invoke(abcPlayer, null);
            playMethod.Invoke(abcPlayer, null);
        }
    }
}
