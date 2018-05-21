using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour {
    public GameObject explosion;
    public LayerMask levelLayer;
    private float tiempoExplosion;
    private int rango;
    private List<GameObject> bombas;

    // Use this for initialization
    void Start() {
        tiempoExplosion = 4;
        Invoke("Explotar", tiempoExplosion);
    }

    public void SetList(List<GameObject> lista)
    {
        bombas = lista;
    }

    private void Update()
    {
        transform.localScale += new Vector3(0.1f,0.1f,0.1f) * Time.deltaTime;
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<SphereCollider>().isTrigger = false;
    }

    private void Explotar()
    {
        bombas.Remove(gameObject);
        GetComponent<MeshRenderer>().enabled = false;
        Instantiate(explosion, transform.position, transform.rotation);
        StartCoroutine(CrearExplosiones(Vector3.forward));
        StartCoroutine(CrearExplosiones(Vector3.right));
        StartCoroutine(CrearExplosiones(Vector3.back));
        StartCoroutine(CrearExplosiones(Vector3.left));
        Destroy(gameObject, 0.3f);
    }

    public void SetMaxDistance(int distance)
    {
        rango = distance;
    }

    private IEnumerator CrearExplosiones(Vector3 direction)
    {
        for (int i = 1; i < rango + 1; i++)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position + new Vector3(0,0.5f,0),direction * i, out hit,1);
            if (!hit.collider)
            {
                Instantiate(explosion, transform.position + (i * direction), explosion.transform.rotation);
            }
            else
            {
                if (hit.transform.tag == "Destruible")
                    hit.transform.GetComponent<Destruible>().Destruir();
                if (hit.transform.tag == "Player")
                    hit.transform.GetComponent<Player>().TakeDamage();
                if (hit.transform.tag == "Enemigo")
                    hit.transform.GetComponent<EnemigoRojo>().Destruir();
                break;
            }
            yield return new WaitForSeconds(.05f);
        }
    }

}
