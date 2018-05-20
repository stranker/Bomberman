using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Vector3 movimiento;
    private int speed = 100;
	// Use this for initialization
	void Start () {
        movimiento = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        movimiento.x = Input.GetAxis("Horizontal") * Time.deltaTime * speed; ;
        movimiento.z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        GetComponent<Rigidbody>().velocity = movimiento;
    }
}
