using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdministradorJuego : MonoBehaviour
{
    public static AdministradorJuego SinglentonAdministradorJuego;
    public static int VelocidadBala = 50;
    public static int DisparosPorJuego = 5;
    public static float VelocidadRotacion = 10;

    public GameObject CanvasGanar;
    public GameObject CanvasPerder;

    private void Awake()
    {
        if (SinglentonAdministradorJuego == null)
        {
            SinglentonAdministradorJuego = this;
        }
        else
        {
            Debug.LogError("Ya existe una instancia de esta clase");
        }
    }
    private void Update()
    {
        if(DisparosPorJuego==0)
        {
            PerderJuego();
          
        }
    }

    public void GanarJuego()
    {
        CanvasGanar.SetActive(true);  
    }
    public void PerderJuego()
    {
        CanvasPerder.SetActive(true);
    }
}
