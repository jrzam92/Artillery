using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public GameObject particulasExplosion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.ToLower() == "suelo")
        {
            Invoke("Explotar", 3);

        }
        if (collision.gameObject.tag.ToLower() == "obstaculo" || collision.gameObject.tag.ToLower() == "objetivo") 
        {
            Explotar(); 
        }
    }

    public void Explotar()
    {
        GameObject particulas=Instantiate(particulasExplosion,transform.position,Quaternion.identity) as GameObject;
        Canon.Bloaqueado = false;
        SeguirCamara.objetivo = null;
        Destroy(this.gameObject);
    }
}
