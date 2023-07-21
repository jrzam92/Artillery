using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] public GameObject balaPrefab;
    private GameObject puntaCanon;
    private float rotacion;

    private void Start()
    {
        puntaCanon = transform.Find("PuntaCanon").gameObject;
    }
    private void Update()
    {
        
        rotacion += Input.GetAxis("Horizontal") * AdministradorJuego.VelocidadRotacion;
        
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -45f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(Vector3.up, 45f);
        }
        //if (rotacion > 90) rotacion = 90f;
        //if (rotacion < 0) rotacion = 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bala = Instantiate(balaPrefab, puntaCanon.transform.position, puntaCanon.transform.rotation);
            bala.GetComponent<Rigidbody>().AddForce(puntaCanon.transform.forward * AdministradorJuego.VelocidadBala, ForceMode.Impulse);
            //GameObject temp=Instantiate(balaPrefab,puntaCanon.transform.position, puntaCanon.transform.rotation);
            //Rigidbody tempRB=temp.GetComponent<Rigidbody>();
            //Vector3 direccionDisparo=transform.rotation.eulerAngles;
            //direccionDisparo.y = 90 - direccionDisparo.x;
            //tempRB.velocity = direccionDisparo.normalized * AdministradorJuego.VelocidadBala;
        }
    }
}
