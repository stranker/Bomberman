using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private int[,] matrizMapa;
    private int largoMapa;
    private int anchoMapa;
    // Use this for initialization
    void Start () {
        largoMapa = 5;
        anchoMapa = 5;
        matrizMapa = new int[largoMapa, anchoMapa];
        GenerarMapa();
        MostrarMapa();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerarMapa()
    {
        for (int i = 0; i < largoMapa; i++)
        {
            for (int j = 0; j < anchoMapa; j++)
            {
                if (i == 0 || i == anchoMapa - 1 || j == 0 || j == largoMapa - 1)
                {
                    matrizMapa[i, j] = 1;
                }
            }
        }
    }

    public void MostrarMapa()
    {
        for (int i = 0; i < largoMapa; i++)
        {
            Debug.Log(matrizMapa[i, 0] + " " + matrizMapa[i, 1] + " " + matrizMapa[i, 2] + " " + matrizMapa[i, 3] + " " + matrizMapa[i, 4]);
        }
    }
}
