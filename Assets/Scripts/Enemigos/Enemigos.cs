using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemigos : MonoBehaviour {
    private bool vivo;
    private int puntaje;
    // Use this for initialization
    void Start () {

	}

    public void Destruir()
    {
        GameManager.Get().puntajeTotal += puntaje;
        GameManager.Get().enemigosVivos--;
        Destroy(gameObject);
    }

    public void SetPuntaje(int val)
    {
        puntaje = val;
    }

    public int GetPuntaje()
    {
        return puntaje;
    }

}
