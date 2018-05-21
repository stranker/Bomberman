using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum ESTADOS
{
    IDLE,
    WALKING
};

public class Enemigos : MonoBehaviour {
    private bool vivo;
    private ESTADOS estadoActual;
	// Use this for initialization
	void Start () {
        vivo = true;
        estadoActual = ESTADOS.IDLE;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void MaquinaDeEstados()
    {
        if (estadoActual == ESTADOS.IDLE)
        {

        }
    }
}
