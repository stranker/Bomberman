using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {
    public Vector3 offset;
    public Quaternion rotacion;
    public GameObject player;
	// Use this for initialization
	void Start () {
        offset = Vector3.zero;
        offset.y = 10;
        rotacion = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + offset;
        transform.rotation = rotacion;
	}
}
