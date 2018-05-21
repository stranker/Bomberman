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
        speed = 150;
        vivo = true;
        tiempoCaminando = 2;
        timer = tiempoCaminando;
        direccion = new Vector3(Random.Range(0, 1.0f), 0, Random.Range(0, 1.0f));
        puntaje = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if (vivo)
        {
            Moverse();
        }
    }

    public void Moverse()
    {
        GetComponent<Rigidbody>().velocity = direccion * speed * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer >= tiempoCaminando)
        {
            direccion = new Vector3(Random.Range(0, 1.0f), 0, Random.Range(0, 1.0f));
            timer = 0;
        }
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
