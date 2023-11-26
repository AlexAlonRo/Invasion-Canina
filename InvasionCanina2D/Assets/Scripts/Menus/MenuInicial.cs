using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuInicial : MonoBehaviour
{
    public GameObject niveles;
    public GameObject home;
    public GameObject notificacion;
    public GameObject login;
    public GameObject register;
    public GameObject ranking;

    public TMP_Text labelTitulo;
    public TMP_Text labelMensaje;

    void Start()
    {
        if (PlayerPrefs.HasKey("idUsuario"))
        {
            if (ranking != null)
            {
                ranking.SetActive(false);
            }
        }
        else
        {
            if (ranking != null)
            {
                ranking.SetActive(true);
            }
        }
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("idUsuario"))
        {
            if (ranking != null)
            {
                ranking.SetActive(true);
            }
        }
        else
        {
            if (ranking != null)
            {
                ranking.SetActive(false);
            }
        }
    }
    public void Jugar(int index)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }

    public void Niveles()
    {
        if (PlayerPrefs.HasKey("idUsuario"))
        {
            // El valor existe, puedes recuperarlo
            //string idUsuario = PlayerPrefs.GetString("idUsuario");
            if(home != null && niveles != null) {
                niveles.SetActive(true);
                home.SetActive(false);
            }
        }
        else
        {
            // El valor no existe o no se ha guardado todavía
            if (notificacion != null)
            {
                labelTitulo.text = "Accede para jugar";
                labelMensaje.text = "Por favor, inicia sesión para acceder a todos nuestros niveles y disfrutar al máximo de la experiencia de juego.";
                notificacion.SetActive(true);

            }
        }
    }

    public void Login()
    {
        if (PlayerPrefs.HasKey("idUsuario"))
        {
            if (notificacion != null)
            {
                labelTitulo.text = "Sesion Activa";
                labelMensaje.text = "Ya estás autenticado. Si deseas iniciar sesión con otra cuenta, por favor, cierra la sesión actual primero.";
                notificacion.SetActive(true);

            }

        }
        else
        {
            if (home != null && login != null)
            {
                login.SetActive(true);
                home.SetActive(false);
            }

        }
    }

    public void Register() 
    {
        if (PlayerPrefs.HasKey("idUsuario"))
        {
            if (notificacion != null)
            {
                labelTitulo.text = "Sesion Activa";
                labelMensaje.text = "Ya estás autenticado. Si deseas crear una nueva cuenta, por favor, cierra la sesión actual primero.";
                notificacion.SetActive(true);
            }

        }
        else
        {
            if (home != null && register != null)
            {
                register.SetActive(true);
                home.SetActive(false);
            }

        }
    }

    public void Salir() 
    {
        Debug.Log("Salir...");
        PlayerPrefs.DeleteKey("idUsuario");
        Application.Quit();
    }

}
