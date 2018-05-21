using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruible : MonoBehaviour {
    private GameObject puertaFinal;
	// Use this for initialization
	void Start () {
		
	}

    public void Destruir()
    {
        if (puertaFinal)
        {
            Instantiate(puertaFinal, transform.position, puertaFinal.transform.rotation,transform.parent);
        }
        Destroy(gameObject);
    }

    public void AsignarPuerta(GameObject puerta)
    {
        puertaFinal = puerta;
    }
}
