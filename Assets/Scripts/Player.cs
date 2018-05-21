using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bombaPrefab;
    private List<GameObject> bombas;
    private int maxBombas = 1;
    private Vector3 movimiento;
    private int speed = 100;
    private int maxDistanceBomb;
    // Use this for initialization
    void Start()
    {
        movimiento = Vector3.zero;
        bombas = new List<GameObject>();
        maxDistanceBomb = 2;
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoPersonaje();
        PonerBomba();
    }

    public void MovimientoPersonaje()
    {
        movimiento.x = Input.GetAxis("Horizontal") * Time.deltaTime * speed; ;
        movimiento.z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        GetComponent<Rigidbody>().velocity = movimiento;
    }

    public void PonerBomba()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PuedoPonerBombas())
        {
            GameObject bomba = Instantiate(bombaPrefab, transform.parent);
            bomba.transform.position = new Vector3(Mathf.Round(transform.position.x -0.5f) + 0.5f ,bombaPrefab.transform.position.y,Mathf.Round(transform.position.z - 0.5f) + 0.5f);
            bomba.GetComponent<Bomba>().SetList(bombas);
            bomba.GetComponent<Bomba>().SetMaxDistance(maxDistanceBomb);
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

    public int GetMaxDistanceBomb()
    {
        return maxDistanceBomb;
    }
}
