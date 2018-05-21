using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour {
    public GameObject explosion;
    public LayerMask levelLayer;
    private float tiempoExplosion;
    private int maxDistance;
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<SphereCollider>().isTrigger = false;
        }
    }

    private void Explotar()
    {
        bombas.Remove(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
        StartCoroutine(CrearExplosiones(Vector3.forward));
        StartCoroutine(CrearExplosiones(Vector3.right));
        StartCoroutine(CrearExplosiones(Vector3.back));
        StartCoroutine(CrearExplosiones(Vector3.left));
        Destroy(gameObject);
    }

    public void SetMaxDistance(int distance)
    {
        maxDistance = distance;
    }

    private IEnumerator CrearExplosiones(Vector3 direction)
    {
        for (int i = 1; i < 3; i++)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position,direction * i, out hit, i);
            if (!hit.collider)
            {
                Instantiate(explosion, transform.position + (i * direction), explosion.transform.rotation);
            }
            else
            {
                if (hit.transform.tag == "Destruible")
                {
                    hit.transform.GetComponent<Destruible>().Destruir();
                }
                break;
            }
            yield return new WaitForSeconds(.05f);
        }
    }

}
