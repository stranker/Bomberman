using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject cajaIndestructible;
    public GameObject piso;
    private int[,] matrizMapa;
    private int largoMapa;
    private int anchoMapa;
    // Use this for initialization
    void Start () {
        largoMapa = 15;
        anchoMapa = 13;
        matrizMapa = new int[largoMapa, anchoMapa];
        GenerarMapa();
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
                if (i == 0 || i == largoMapa - 1 || j == 0 || j == anchoMapa - 1 || (i % 2 == 0 && j % 2 == 0))
                    matrizMapa[i, j] = 1;
            }
        }
        for (int i = 0; i < largoMapa; i++)
        {
            for (int j = 0; j < anchoMapa; j++)
            {
                if (matrizMapa[i,j] == 1)
                {
                    Instantiate(cajaIndestructible, new Vector3(i + 0.5f, cajaIndestructible.transform.position.y, j + 0.5f),transform.rotation,transform.parent);
                }
            }
        }
        GameObject clon = Instantiate(piso);
        clon.transform.position = new Vector3(largoMapa,0,anchoMapa)/2;
        clon.transform.localScale = new Vector3(largoMapa, 1, anchoMapa)/10;
    }
}
