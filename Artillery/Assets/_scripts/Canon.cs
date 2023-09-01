using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Canon : MonoBehaviour
{
    public static bool Bloaqueado;
    [SerializeField] public GameObject balaPrefab;
    private GameObject puntaCanon;
    [SerializeField] public GameObject PariculasDisparo;
    public AudioClip clipDisparo;
    private GameObject sonidoDisparo;
    private AudioSource sourceDisparo;
    private float rotacion;

    public CanonControls canonControls;
    private InputAction apuntar;
    private InputAction modificarFuerza;
    private InputAction disparar;

    private void Awake()
    {
        canonControls=new CanonControls();
    }

    private void OnEnable()
    {
        apuntar = canonControls.Canon.apuntar;
        modificarFuerza = canonControls.Canon.modificarFuerza;
        disparar = canonControls.Canon.disparar;
        apuntar.Enable();
        modificarFuerza.Enable();
        disparar.Enable();
        disparar.performed += Disparar;
    }
    private void Start()
    {
        puntaCanon = transform.Find("PuntaCanon").gameObject;
        sonidoDisparo=GameObject.Find("SonidoDisparo");
        sourceDisparo = sonidoDisparo.GetComponent<AudioSource>();   
    }
    private void Update()
    {

        #region opcion1
        ///PRIMERA OPCION
        //rotacion += Input.GetAxis("Horizontal") * AdministradorJuego.VelocidadRotacion;
        rotacion +=apuntar.ReadValue<float>()* AdministradorJuego.VelocidadRotacion;

        if (rotacion <= 30 && rotacion >= -60)
        {
            transform.localEulerAngles = new Vector3(0.0f, rotacion, 0f);
        }
        if (rotacion > 30) rotacion = 30f;
        if (rotacion < -60) rotacion = -60;
        disparar.performed += Disparar;
        //if ((Input.GetKeyDown(KeyCode.Space) && AdministradorJuego.DisparosPorJuego != 0 && !Bloaqueado))
        //{
        //Disparar();
        //}
        #endregion
        #region opcion2
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    transform.Rotate(Vector3.up, -5f);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    transform.Rotate(Vector3.up, 5f);
        //}
        //if ((Input.GetKeyDown(KeyCode.Space) && AdministradorJuego.DisparosPorJuego != 0&& !Bloaqueado) )//Se tiene duda con el bloaqueado
        //{
        //    GameObject bala = Instantiate(balaPrefab, puntaCanon.transform.position, puntaCanon.transform.rotation);
        //    Rigidbody tempRB = bala.GetComponent<Rigidbody>();
        //    SeguirCamara.objetivo = bala;
        //    tempRB.GetComponent<Rigidbody>().AddForce(-puntaCanon.transform.forward * AdministradorJuego.VelocidadBala*2, ForceMode.Impulse);
        //AdministradorJuego.DisparosPorJuego -= 1;
        //Bloaqueado = true;
        //}
        #endregion


    }

    private void Disparar(InputAction.CallbackContext context)
    {
        if(AdministradorJuego.DisparosPorJuego != 0 && !Bloaqueado)
        {
            print(AdministradorJuego.DisparosPorJuego);
        
        GameObject temp = Instantiate(balaPrefab, puntaCanon.transform.position, transform.rotation);
        GameObject particulas = Instantiate(PariculasDisparo, puntaCanon.transform.position, transform.rotation);
        Rigidbody tempRB = temp.GetComponent<Rigidbody>();
        SeguirCamara.objetivo = temp;
        Vector3 direccionDisparo = transform.rotation.eulerAngles;//new Vector3(75f, 15f, 0.009f);   transform.rotation.eulerAngles

        if (direccionDisparo.x.ToString().Equals("270.0198"))
        {

            direccionDisparo = new Vector3(direccionDisparo.x, 0f, 0f);
        }

        //direccionDisparo.y = -60 + direccionDisparo.x; --- haciendo pruebas estas lineas no van de acuerdo a como se esta realizando 
        tempRB.velocity = direccionDisparo.normalized * AdministradorJuego.VelocidadBala;
        //sourceDisparo.PlayOneShot(clipDisparo);
        sourceDisparo.Play();

        Bloaqueado = true;
        AdministradorJuego.DisparosPorJuego -= 1;
        }
    }
}
