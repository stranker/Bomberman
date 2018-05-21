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
        puntaje = GameManager.puntajeTotal;
        vidas = GameManager.vidasRestantes;
        bombas = GameManager.bombasSimultaneas;
        rango = GameManager.rangoMaximo;
        matados = GameManager.enemigosMatados;
        textoPuntaje.text = "Puntaje  " + puntaje.ToString();
        textoVidas.text = "X " + vidas.ToString();
        textoBombas.text = "X " + bombas.ToString();
        textoRango.text = rango.ToString();
        textoMatados.text = matados.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.puntajeTotal != puntaje)
        {
            puntaje = GameManager.puntajeTotal;
            UpdateTexto();
        }
        if (vidas != GameManager.vidasRestantes)
        {
            vidas = GameManager.vidasRestantes;
            UpdateTexto();
        }
        if (bombas != GameManager.bombasSimultaneas)
        {
            bombas = GameManager.bombasSimultaneas;
            UpdateTexto();
        }
        if (rango != GameManager.rangoMaximo)
        {
            rango = GameManager.rangoMaximo;
            UpdateTexto();
        }
        if (matados != GameManager.enemigosMatados)
        {
            matados = GameManager.enemigosMatados;
            UpdateTexto();
        }
        timer += Time.deltaTime;
        tiempoTranscurrido = Mathf.RoundToInt(timer);
        GameManager.tiempoTranscurrido = tiempoTranscurrido;
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
