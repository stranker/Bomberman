using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ESTADOS
{
    PERSEGUIR,
    ALEJARSE,
    LAST
}

public class EnemigoVioleta : Enemigos {

    public int speed;
    public Vector3 direccion;
    private ESTADOS estadoActual;
	// Use this for initialization
	void Start () {
        speed = 10;
        SetPuntaje(500);
        estadoActual = ESTADOS.PERSEGUIR;
	}

    private void FixedUpdate()
    {
        if (estadoActual == ESTADOS.PERSEGUIR)
            PerseguirPersonaje();
        if (estadoActual == ESTADOS.ALEJARSE)
            Alejarse();
        GetComponent<Rigidbody>().velocity = direccion * speed * Time.deltaTime;
    }

    private void PerseguirPersonaje()
    {
        direccion = (GameManager.Get().player.transform.position - transform.position).normalized;
        
    }
    private void Alejarse()
    {
        if (transform.position.x < GameManager.Get().player.transform.position.x + 20)
            direccion = -(GameManager.Get().player.transform.position - transform.position).normalized;
        else
            estadoActual = ESTADOS.PERSEGUIR;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.GetComponent<Player>().TakeDamage();
            estadoActual = ESTADOS.ALEJARSE;
        }
    }
}
