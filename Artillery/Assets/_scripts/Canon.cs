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

        #region opcion1
        /////PRIMERA OPCION
        //rotacion += Input.GetAxis("Horizontal") * AdministradorJuego.VelocidadRotacion;
        //if (rotacion > 30) rotacion = 30f;
        //if (rotacion < -60) rotacion = -60;
        //if (rotacion <= 30 && rotacion >= -60)
        //{
        //    transform.localEulerAngles = new Vector3(0.0f, rotacion, 0f);
        //}

        //if (Input.GetKeyDown(KeyCode.Space) && AdministradorJuego.DisparosPorJuego != 0)
        //{

        //    GameObject temp = Instantiate(balaPrefab, puntaCanon.transform.position, puntaCanon.transform.rotation);
        //    Rigidbody tempRB = temp.GetComponent<Rigidbody>();
        //    Vector3 direccionDisparo = transform.rotation.eulerAngles;
        //    direccionDisparo.y = -60 + direccionDisparo.x;
        //    tempRB.velocity = direccionDisparo.normalized * AdministradorJuego.VelocidadBala;
        //    AdministradorJuego.DisparosPorJuego -= 1;
        //}
        #endregion
        #region opcion2
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -5f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(Vector3.up, 5f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && AdministradorJuego.DisparosPorJuego != 0)
        {
            GameObject bala = Instantiate(balaPrefab, puntaCanon.transform.position, puntaCanon.transform.rotation);
            bala.GetComponent<Rigidbody>().AddForce(puntaCanon.transform.forward * AdministradorJuego.VelocidadBala, ForceMode.Impulse);
            AdministradorJuego.DisparosPorJuego -= 1;
        }
        #endregion 


    }
}
