using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Text textoPuntaje;
    public Text textoVidas;
    public Text textoBombas;
    public Text textoRango;
    public Text textoTiempo;
    public Text textoMatados;
    private int puntaje;
    private int vidas;
    private int bombas;
    private int rango;
    private int matados;
    private int tiempoTranscurrido;
    private float timer;
	// Use this for initialization
	void Start () {
        puntaje = GameManager.Get().puntajeTotal;
        vidas = GameManager.Get().vidasRestantes;
        bombas = GameManager.Get().bombasSimultaneas;
        rango = GameManager.Get().rangoMaximo;
        matados = GameManager.Get().cantidadEnemigos - GameManager.Get().enemigosVivos;
        textoPuntaje.text = "Puntaje  " + puntaje.ToString();
        textoVidas.text = "X " + vidas.ToString();
        textoBombas.text = "X " + bombas.ToString();
        textoRango.text = rango.ToString();
        textoMatados.text = matados.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Get().puntajeTotal != puntaje)
        {
            puntaje = GameManager.Get().puntajeTotal;
            UpdateTexto();
        }
        if (vidas != GameManager.Get().vidasRestantes)
        {
            vidas = GameManager.Get().vidasRestantes;
            UpdateTexto();
        }
        if (bombas != GameManager.Get().bombasSimultaneas)
        {
            bombas = GameManager.Get().bombasSimultaneas;
            UpdateTexto();
        }
        if (rango != GameManager.Get().rangoMaximo)
        {
            rango = GameManager.Get().rangoMaximo;
            UpdateTexto();
        }
        if (matados != GameManager.Get().cantidadEnemigos - GameManager.Get().enemigosVivos)
        {
            matados = GameManager.Get().cantidadEnemigos - GameManager.Get().enemigosVivos;
            UpdateTexto();
        }
        timer += Time.deltaTime;
        tiempoTranscurrido = Mathf.RoundToInt(timer);
        GameManager.Get().tiempoTranscurrido = tiempoTranscurrido;
        textoTiempo.text = tiempoTranscurrido.ToString();
    }

    private void UpdateTexto()
    {
        textoPuntaje.text = "Puntaje  " + puntaje.ToString();
        textoVidas.text = "X " + vidas.ToString();
        textoBombas.text = "X " + bombas.ToString();
        textoRango.text = rango.ToString();
        textoMatados.text = matados.ToString();
    }
}
