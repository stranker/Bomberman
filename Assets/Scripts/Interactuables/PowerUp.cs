using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TIPO
{
    BOMBA,
    RANGO,
    VIDA
}

public class PowerUp : MonoBehaviour {

    private TIPO tipoPower;
    private bool activado;
    public List<Material> materiales;
	// Use this for initialization
	void Start () {
        activado = false;
        switch (Random.Range(0,2))
        {
            case 0:
                tipoPower = TIPO.BOMBA;
                break;
            case 1:
                tipoPower = TIPO.RANGO;
                break;
            case 2:
                tipoPower = TIPO.VIDA;
                break;
            default:
                break;
        }
        GetComponent<MeshRenderer>().material = materiales[(int)tipoPower];
    }

    private void Update()
    {
        transform.Rotate(Vector3.up,1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!activado && (other.gameObject.tag == "Player"))
        {
            activado = true;
            switch (tipoPower)
            {
                case TIPO.BOMBA:
                    GameManager.Get().GetPlayer().GetComponent<Player>().UpgradeBomba();
                    break;
                case TIPO.RANGO:
                    GameManager.Get().GetPlayer().GetComponent<Player>().UpgradeRango();
                    break;
                case TIPO.VIDA:
                    GameManager.Get().GetPlayer().GetComponent<Player>().UpgradeVida();
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
