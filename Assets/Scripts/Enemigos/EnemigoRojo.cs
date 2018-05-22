using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoRojo : Enemigos
{
    int speed;
    private int tiempoCaminando;
    private float timer;
    private Vector3 direccion;
    // Use this for initialization
    void Start()
    {
        SetPuntaje(200);
        speed = 1000;
        tiempoCaminando = 2;
        timer = tiempoCaminando;
        direccion = new Vector3(Random.Range(-1, 1), 0, Random.Range(1, 1));
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Moverse();
    }

    public void Moverse()
    {
        timer += Time.deltaTime;
        if (timer >= tiempoCaminando)
        {
            switch (Random.Range(0,4))
            {
                case 0:
                    direccion = Vector3.forward;
                    break;
                case 1:
                    direccion = Vector3.back;
                    break;
                case 2:
                    direccion = Vector3.right;
                    break;
                case 3:
                    direccion = Vector3.left;
                    break;
                default:
                    break;
            }
            timer = 0;
        }
        GetComponent<Rigidbody>().velocity = direccion * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemigo" || collision.transform.tag == "Player")
            direccion = -direccion;
    }
}
