using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour {

    public bool abierta;

    private void Start()
    {
        abierta = false;
    }

    private void Update()
    {
        if (GameManager.enemigosVivos == 0 && !abierta)
        {
            AbrirPuerta();
        }
    }

    public void AbrirPuerta()
    {
        abierta = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (abierta && other.tag == "Player")
        {
            GameManager.FinNivel();
        }
    }
}
