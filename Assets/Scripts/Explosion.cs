using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    private float duracion;
	// Use this for initialization
	void Start () {
        duracion = 2;
        Invoke("Destruir", 2);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destruible")
        {
            Debug.Log("xd");
        }
    }

    private void Destruir()
    {
        Destroy(gameObject);
    }
}
