using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform personaje;

    private float tamañoCamara;
    private float alturaPantalla;

    // Start is called before the first frame update
    void Start()
    {
        tamañoCamara = Camera.main.orthographicSize;
        alturaPantalla = tamañoCamara * 2;
    }

    // Update is called once per frame
    void Update()
    {
        CalcularPosicionCamara();
    }

    void CalcularPosicionCamara()
    {
        float pantallaPersonaje = personaje.position.x / alturaPantalla;
        float alturaCamara = (pantallaPersonaje * alturaPantalla) + tamañoCamara;

        transform.position = new Vector3(alturaCamara, transform.position.y, transform.position.z);
    }
}