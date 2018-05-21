using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruible : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void Destruir()
    {
        Destroy(gameObject);
    }
}
