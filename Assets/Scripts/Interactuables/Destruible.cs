using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruible : MonoBehaviour {
    private GameObject puertaFinal;
    public GameObject powerUp;
    public float probPowerUp;
	// Use this for initialization
	void Start () {
        probPowerUp = 0.6f;
	}

    public void Destruir()
    {
        if (puertaFinal)
        {
            Instantiate(puertaFinal, transform.position, puertaFinal.transform.rotation,transform.parent);
        }
        else
        {
            if (Random.Range(0.0f,1.0f)>probPowerUp)
            {
                Instantiate(powerUp, new Vector3(transform.position.x, powerUp.transform.position.y, transform.position.z), powerUp.transform.rotation, transform.parent);
            }
        }
        Destroy(gameObject);
    }

    public void AsignarPuerta(GameObject puerta)
    {
        puertaFinal = puerta;
    }
}
