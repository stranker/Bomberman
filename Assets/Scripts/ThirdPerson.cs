using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour {
    private Vector3 movimiento;
    private int speed = 150;
    // Use this for initialization
    void Start () {
        movimiento = Vector3.zero;
    }

    public void MovimientoPersonaje()
    {
        movimiento.x = Input.GetAxis("Horizontal") * Time.deltaTime * speed; ;
        movimiento.z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        GetComponent<Rigidbody>().velocity = movimiento;
    }

    void Update () {
        MovimientoPersonaje();
	}
}
