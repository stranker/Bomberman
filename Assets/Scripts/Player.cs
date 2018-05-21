using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bombaPrefab;
    public int vida;
    private List<GameObject> bombas;
    private int maxBombas;
    private Vector3 movimiento;
    private int speed = 150;
    private int rango;
    private bool puedeSerLastimado;
    private int tiempoIntocable;
    private float timer;
    // Use this for initialization
    private void Awake()
    {
        Inicializar();
    }
    public void Inicializar()
    {
        movimiento = Vector3.zero;
        bombas = new List<GameObject>();
        rango = 1;
        vida = 2;
        tiempoIntocable = 4;
        timer = 0;
        maxBombas = 3;
        puedeSerLastimado = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoPersonaje();
        PonerBomba();
        CheckearLastimado();
    }

    public void CheckearLastimado()
    {
        if (!puedeSerLastimado)
        {
            timer += Time.deltaTime;
        }
        if (timer >= tiempoIntocable)
        {
            puedeSerLastimado = true;
            timer = 0;
        }
    }

    public void MovimientoPersonaje()
    {
        movimiento.x = Input.GetAxis("Horizontal") * Time.deltaTime * speed; ;
        movimiento.z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        GetComponent<Rigidbody>().velocity = movimiento;
    }

    public void PonerBomba()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && PuedoPonerBombas())
        {
            GameObject bomba = Instantiate(bombaPrefab, transform.parent);
            bomba.transform.position = new Vector3(Mathf.Round(transform.position.x -0.5f) + 0.5f ,bombaPrefab.transform.position.y,Mathf.Round(transform.position.z - 0.5f) + 0.5f);
            bomba.GetComponent<Bomba>().SetList(bombas);
            bomba.GetComponent<Bomba>().SetMaxDistance(rango);
            bombas.Add(bomba); 
        }
    }

    public bool PuedoPonerBombas()
    {
        bool puede = false;
        if (bombas.Count < maxBombas)
            puede = true;
        return puede;
    }

    public void TakeDamage()
    {
        if (puedeSerLastimado)
        {
            vida--;
            puedeSerLastimado = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemigo")
        {
            TakeDamage();
        }
    }

    public int GetVidas()
    {
        return vida;
    }

    public int GetBombas()
    {
        return maxBombas - bombas.Count;
    }

    public int GetRango()
    {
        return rango;
    }
}
