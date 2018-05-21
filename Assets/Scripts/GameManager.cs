using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static int enemigosVivos;
    public static int enemigosMatados;
    public static int puntajeTotal;
    public static int vidasRestantes;
    public static GameObject player;
    public static int tiempoTranscurrido;
    public static int bombasSimultaneas;
    public static int rangoMaximo;
    public GameObject cajaIndestructible;
    public GameObject cajaDestruible;
    public GameObject piso;
    public GameObject enemigoRojo;
    public GameObject puerta;
    public int cantidadEnemigos;
    public int largoMapa;
    public int anchoMapa;
    private int[,] matrizMapa;
    private float promedioCajaDestructible = 0.7f;
    private List<GameObject> cajas;
    private static bool gameOver;
    private bool finalScreen;
    
    // Use this for initialization

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        cajas = new List<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player");
        finalScreen = false;
    }

    void Start()
    {
        matrizMapa = new int[largoMapa, anchoMapa];
        enemigosVivos = 0;
        gameOver = false;
        puntajeTotal = 0;
        vidasRestantes = player.GetComponent<Player>().GetVidas();
        GenerarMapa();
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
        enemigosMatados = cantidadEnemigos - enemigosVivos;
        
    }

    public void GenerarMapa()
    {
        // Genero mapa
        for (int i = 0; i < largoMapa; i++)
        {
            for (int j = 0; j < anchoMapa; j++)
            {
                if (i == 0 || i == largoMapa - 1 || j == 0 || j == anchoMapa - 1 || (i % 2 == 0 && j % 2 == 0))
                    matrizMapa[i, j] = 1;
                else if (i == 1 && j == 1)
                    matrizMapa[i, j] = 9;
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
                matrizMapa[i,j] = 3;
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
                        Instantiate(cajaIndestructible, new Vector3(i + 0.5f, cajaIndestructible.transform.position.y, j + 0.5f), transform.rotation, transform.parent);
                        break;
                    case 2:
                        GameObject caja = Instantiate(cajaDestruible, new Vector3(i + 0.5f, cajaIndestructible.transform.position.y, j + 0.5f), transform.rotation, transform.parent);
                        cajas.Add(caja);
                        break;
                    case 3:
                        Instantiate(enemigoRojo, new Vector3(i + 0.5f, cajaIndestructible.transform.position.y, j + 0.5f), transform.rotation, transform.parent);
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
        clon.transform.position = new Vector3(largoMapa, 0, anchoMapa) / 2;
        clon.transform.localScale = new Vector3(largoMapa, 1, anchoMapa) / 10;
        cajas[Random.Range(0, cajas.Count - 1)].GetComponent<Destruible>().AsignarPuerta(puerta);
    }

    public void MostrarMatriz()
    {
        for (int i = 0; i < largoMapa; i++)
        {
            Debug.Log(matrizMapa[i, 0] + " " + matrizMapa[i, 1] + " " + matrizMapa[i, 2] + " " + matrizMapa[i, 3] + " " + matrizMapa[i, 4] + " " + matrizMapa[i, 5] + " " +
                matrizMapa[i, 6]);
        }
    }

    public static GameObject GetPlayer()
    {
        return player;
    }

    private void GameOver()
    {
        if (gameOver && !finalScreen)
        {
            finalScreen = true;
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

    public static void FinNivel()
    {
        gameOver = true;
    }
    
    public int GetCantidadEnemigos()
    {
        return cantidadEnemigos;
    }
}
