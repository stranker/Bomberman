using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public GameObject cajaIndestructible;
    public GameObject cajaDestruible;
    public GameObject piso;
    public GameObject player;
    private int[,] matrizMapa;
    private int largoMapa;
    private int anchoMapa;
    // Use this for initialization

    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        largoMapa = 9;
        anchoMapa = 7;
        matrizMapa = new int[largoMapa, anchoMapa];
        GenerarMapa();
        MostrarMatriz();
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
                else if (i == 1 && j == 1)
                    matrizMapa[i, j] = 9;
               /* else if (i > 2 || j > 2)
                    if (Random.Range(0,1.0f) > 0.5f)
                        matrizMapa[i, j] = 2;*/
            }
        }
        for (int i = 0; i < largoMapa; i++)
        {
            for (int j = 0; j < anchoMapa; j++)
            {
                switch (matrizMapa[i, j])
                {
                    case 1:
                        Instantiate(cajaIndestructible, new Vector3(i + 0.5f, cajaIndestructible.transform.position.y, j + 0.5f), transform.rotation, transform.parent);
                        break;
                    case 2:
                        Instantiate(cajaDestruible, new Vector3(i + 0.5f, cajaIndestructible.transform.position.y, j + 0.5f), transform.rotation, transform.parent);
                        break;
                    case 9:
                        player.transform.position = new Vector3(i + 0.5f, 1, j + 0.5f);
                        break;
                    default:
                        break;
                }
            }
        }
        GameObject clon = Instantiate(piso);
        clon.transform.position = new Vector3(largoMapa,0,anchoMapa)/2;
        clon.transform.localScale = new Vector3(largoMapa, 1, anchoMapa)/10;
    }

    public void MostrarMatriz()
    {
        for (int i = 0; i < largoMapa; i++)
        {
            Debug.Log(matrizMapa[i, 0] + " " + matrizMapa[i, 1] + " " + matrizMapa[i, 2] + " " + matrizMapa[i, 3] + " " + matrizMapa[i, 4] + " " + matrizMapa[i, 5] + " " +
                matrizMapa[i, 6]);
        }
    }
}
