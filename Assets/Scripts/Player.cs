using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    public GameObject bombaPrefab;
    public int vida;
    public int maxBombas;
    public int rango;
    private List<GameObject> bombas;
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
        bombas = new List<GameObject>();
        rango = 1;
        vida = 2;
        tiempoIntocable = 4;
        timer = 0;
        maxBombas = 1;
        puedeSerLastimado = true;
        ModoTopView();
    }

    // Update is called once per frame
    void Update()
    {
        PonerBomba();
        CheckearLastimado();
        CheckModoJuego();
    }

    public void CheckearLastimado()
    {
        if (!puedeSerLastimado)
            timer += Time.deltaTime;
        if (timer >= tiempoIntocable)
        {
            puedeSerLastimado = true;
            timer = 0;
        }
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

    public void UpgradeBomba()
    {
        maxBombas++;
    }
    public void UpgradeRango()
    {
        rango++;
    }
    public void UpgradeVida()
    {
        vida++;
    }

    public void CheckModoJuego()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ModoTopView();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ModoFPS();
        }
    }

    private void ModoTopView()
    {
        GetComponent<FirstPersonController>().enabled = false;
        GetComponent<ThirdPerson>().enabled = true;
        GetComponentInChildren<Camera>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<CharacterController>().enabled = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void ModoFPS()
    {
        GetComponent<FirstPersonController>().enabled = true;
        GetComponent<ThirdPerson>().enabled = false;
        GetComponentInChildren<Camera>().enabled = true;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<CharacterController>().enabled = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemigo")
        {
            TakeDamage();
        }
    }
}
