using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorJuego : MonoBehaviour
{
    public static AdministradorJuego SinglentonAdministradorJuego;
    public static int VelocidadBala = 50;
    public static int DisparosPorJuego = 10;
    public static float VelocidadRotacion = 10;

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
}
