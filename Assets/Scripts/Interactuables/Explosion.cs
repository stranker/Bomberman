using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    private float duracion;
	// Use this for initialization
	void Start () {
        duracion = 2;
        Invoke("Destruir", duracion);
	}

    private void Destruir()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            GameManager.Get().GetPlayer().GetComponent<Player>().TakeDamage();
        if (other.tag == "Enemigo")
            other.gameObject.GetComponent<Enemigos>().Destruir();
    }
}
