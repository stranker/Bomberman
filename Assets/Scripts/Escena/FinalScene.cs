using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScene : MonoBehaviour {
    public Text puntajeFinal;
    public Text vidasRestantes;
    public Text tiempoFinalizado;
    public Text enemigosMatados;
    public Text bombasMaximas;
    public Text rangoMaximo;
    private int contador;
	// Use this for initialization
	void Start () {
        contador = 0;
        vidasRestantes.text = "Vidas  restantes:  " + GameManager.vidasRestantes.ToString();
        tiempoFinalizado.text = "Tiempo   en  finalizar:  " + GameManager.tiempoTranscurrido.ToString() + " s";
        enemigosMatados.text = "Enemigos  eliminados:  " + GameManager.enemigosMatados.ToString();
        bombasMaximas.text = "maximo  Bombas  simultaneas:  " + GameManager.bombasSimultaneas.ToString();
        rangoMaximo.text = "maximo  rango  explosion:  " + GameManager.rangoMaximo.ToString();
    }

    // Update is called once per frame
    void Update () {
        
        if (contador < GameManager.puntajeTotal)
            contador += 50;
        puntajeFinal.text = "Puntaje  final:  " + contador.ToString();
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
