using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance = null;
    public GameObject playerPrefab;
    public GameObject player;
    public GameObject cajaIndestructible;
    public GameObject cajaDestruible;
    public GameObject piso;
    public GameObject puerta;
    public int enemigosVivos;
    public int puntajeTotal;
    public int vidasRestantes;
    public int tiempoTranscurrido;
    public int bombasSimultaneas;
    public int rangoMaximo;
    public int cantidadEnemigos;
    public int largoMapa;
    public int anchoMapa;
    public float offset = 0.5f;
    public List<GameObject> enemigos;
    private GameObject mapa;
    private int[,] matrizMapa;
    private float promedioCajaDestructible = 0.7f;
    private List<GameObject> cajas;
    private static bool gameOver;
    private bool finalScreen;
    private bool modoFPS;

    // Use this for initialization

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        Inicializar();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        if (player)
        {
            vidasRestantes = player.GetComponent<Player>().GetVidas();
            bombasSimultaneas = player.GetComponent<Player>().GetBombas();
            rangoMaximo = player.GetComponent<Player>().GetRango();
        }
    }

    public void GenerarMapa()
    {
        BorrarMapaAnterior();
        // Genero mapa
        for (int i = 0; i < largoMapa; i++)
        {
            for (int j = 0; j < anchoMapa; j++)
            {
                if (i == 0 || i == largoMapa - 1 || j == 0 || j == anchoMapa - 1 || (i % 2 == 0 && j % 2 == 0))
                    matrizMapa[i, j] = 1;
                else if (i > 2 || j > 2)
                    if (Random.Range(0, 1.0f) > promedioCajaDestructible)
                        matrizMapa[i, j] = 2;
            }
        }
        // Genero enemigos
        while (enemigosVivos < cantidadEnemigos)
        {
            int i = Random.Range(2, largoMapa - 1);
            int j = Random.Range(2, anchoMapa - 1);
            if (matrizMapa[i,j] == 0)
            {
                switch (Random.Range(0,3))
                {
                    case 0:
                        matrizMapa[i, j] = 3;
                        break;
                    case 1:
                        matrizMapa[i, j] = 4;
                        break;
                    case 2:
                        matrizMapa[i, j] = 5;
                        break;
                    default:
                        break;
                }
                enemigosVivos++;
            }
        }
        // Instancio todos los objetos
        for (int i = 0; i < largoMapa; i++)
        {
            for (int j = 0; j < anchoMapa; j++)
            {
                switch (matrizMapa[i, j])
                {
                    case 1:
                        Instantiate(cajaIndestructible, new Vector3(i + offset, cajaIndestructible.transform.position.y, j + offset), transform.rotation, mapa.transform);
                        break;
                    case 2:
                        GameObject caja = Instantiate(cajaDestruible, new Vector3(i + offset, cajaDestruible.transform.position.y, j + offset), transform.rotation, mapa.transform);
                        cajas.Add(caja);
                        break;
                    case 3:
                        Instantiate(enemigos[0], new Vector3(i + offset, enemigos[0].transform.position.y, j + offset), transform.rotation, mapa.transform);
                        break;
                    case 4:
                        Instantiate(enemigos[1], new Vector3(i + offset, enemigos[1].transform.position.y, j + offset), transform.rotation, mapa.transform);
                        break;
                    case 5:
                        Instantiate(enemigos[2], new Vector3(i + offset, enemigos[2].transform.position.y, j + offset), transform.rotation, mapa.transform);
                        break;
                    default:
                        break;
                }
            }
        }
        player = Instantiate(playerPrefab, new Vector3(1.5f, 1, 1.5f), transform.rotation, transform.parent);
        GameObject pisoNivel = Instantiate(piso);
        pisoNivel.transform.position = new Vector3(largoMapa, 0, anchoMapa) / 2;
        pisoNivel.transform.localScale = new Vector3(largoMapa, 1, anchoMapa) / 10;
        cajas[Random.Range(0, cajas.Count - 1)].GetComponent<Destruible>().AsignarPuerta(puerta);
    }

    private void BorrarMapaAnterior()
    {
        mapa = GameObject.FindGameObjectWithTag("Mapa");
        if (mapa.GetComponentsInChildren<Transform>().Length>0)
            for (int i = 0; i < mapa.GetComponentsInChildren<Transform>().Length; i++)
                if (i!=0)
                    Destroy(mapa.GetComponentsInChildren<Transform>()[i].gameObject);

    }

    public void MostrarMatriz()
    {
        for (int i = 0; i < largoMapa; i++)
        {
            Debug.Log(matrizMapa[i, 0] + " " + matrizMapa[i, 1] + " " + matrizMapa[i, 2] + " " + matrizMapa[i, 3] + " " + matrizMapa[i, 4] + " " + matrizMapa[i, 5] + " " +
                matrizMapa[i, 6]);
        }
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    private void GameOver()
    {
        if (gameOver && !finalScreen)
        {
            finalScreen = true;
            player.GetComponent<FirstPersonController>().enabled = false;
            SceneManager.LoadScene("FinalScene");
        }
        else if (!gameOver && !finalScreen)
        {
            if (vidasRestantes <= 0)
            {
                gameOver = true;
            }
        }
    }

    public static GameManager Get()
    {
        return instance;
    }

    public static void FinNivel()
    {
        gameOver = true;
    }

    public int[,] GetMapa()
    {
        return matrizMapa;
    }
    
    public void Inicializar()
    {
        player = null;
        cajas = new List<GameObject>();
        finalScreen = false;
        mapa = GameObject.FindGameObjectWithTag("Mapa");
        matrizMapa = new int[largoMapa, anchoMapa];
        gameOver = false;
        puntajeTotal = 0;
        GenerarMapa();
        vidasRestantes = player.GetComponent<Player>().GetVidas();
    }
}
