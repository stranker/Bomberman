using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum ESTADOS
{
    IDLE,
    WALKING
};

public class Enemigos : MonoBehaviour {
    private ESTADOS estadoActual;
	// Use this for initialization
	void Start () {
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
