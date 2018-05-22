using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAmarillo : Enemigos {

    public int tiempoIdle;
    public float timer;
    private float probabilidadRealocar = 0.7f;
    // Use this for initialization
    void Start () {
        tiempoIdle = 3;
        SetPuntaje(1000);
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= tiempoIdle)
        {
            Realocar();
            timer = 0;
        }
	}

    public void Realocar()
    {
        bool realocado = false;
        while (!realocado)
        {
            for (int i = 0; i < GameManager.Get().largoMapa; i++)
            {
                for (int j = 0; j < GameManager.Get().anchoMapa; j++)
                {
                    if (GameManager.Get().GetMapa()[i, j] == 0 && !realocado)
                    {
                        if (Random.Range(0.0f, 1.0f) > probabilidadRealocar)
                        {
                            realocado = true;
                            transform.position = new Vector3(i + GameManager.Get().offset, transform.position.y, j + GameManager.Get().offset);
                            break;
                        }
                    }
                }
            }
        }
    }
}
