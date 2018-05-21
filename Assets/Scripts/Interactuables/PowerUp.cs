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
        transform.Rotate(Vector3.up,Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!activado && (other.gameObject.tag == "Player" || other.gameObject.tag == "FPSPlayer"))
        {
            activado = true;
            switch (tipoPower)
            {
                case TIPO.BOMBA:
                    GameManager.player.GetComponent<Player>().UpgradeBomba();
                    break;
                case TIPO.RANGO:
                    GameManager.player.GetComponent<Player>().UpgradeRango();
                    break;
                case TIPO.VIDA:
                    GameManager.player.GetComponent<Player>().UpgradeVida();
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
