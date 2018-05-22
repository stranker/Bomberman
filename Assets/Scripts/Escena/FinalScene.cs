using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class FinalScene : MonoBehaviour {
    public Text puntajeFinal;
    public Text vidasRestantes;
    public Text tiempoFinalizado;
    public Text enemigosMatados;
    public Text bombasMaximas;
    public Text rangoMaximo;
    private int contador;
    // Use this for initialization
    void Start()
    {
        contador = 0;
        vidasRestantes.text = "Vidas  restantes:  " + GameManager.Get().vidasRestantes.ToString();
        tiempoFinalizado.text = "Tiempo   en  finalizar:  " + GameManager.Get().tiempoTranscurrido.ToString() + " s";
        enemigosMatados.text = "Enemigos  eliminados:  " + (GameManager.Get().cantidadEnemigos - GameManager.Get().enemigosVivos).ToString();
        bombasMaximas.text = "maximo  Bombas  simultaneas:  " + GameManager.Get().bombasSimultaneas.ToString();
        rangoMaximo.text = "maximo  rango  explosion:  " + GameManager.Get().rangoMaximo.ToString();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update () {
        if (contador < GameManager.Get().puntajeTotal)
            contador += 50;
        puntajeFinal.text = "Puntaje  final:  " + contador.ToString();
    }

    public void VolverAlMenu()
    {
        Destroy(GameManager.Get().gameObject);
        SceneManager.LoadScene("MainMenuScene");
    }
}
