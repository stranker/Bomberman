using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoRojo : MonoBehaviour
{
    public int speed;
    private bool vivo;
    private int tiempoCaminando;
    private float timer;
    private Vector3 direccion;
    private int puntaje;
    // Use this for initialization
    void Start()
    {
        speed = 1000;
        vivo = true;
        tiempoCaminando = 2;
        timer = tiempoCaminando;
        direccion = new Vector3(Random.Range(-1, 1), 0, Random.Range(1, 1));
        puntaje = 200;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (vivo)
        {
            Moverse();
        }
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
        if (collision.transform.tag == "Enemigo")
        {
            direccion = -direccion;
        }
    }

    public void Destruir()
    {
        GameManager.puntajeTotal += puntaje;
        GameManager.enemigosVivos--;
        Destroy(gameObject);
    }
}
