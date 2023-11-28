using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerUser : MonoBehaviour
{
    public static ControllerUser Instance;

    [SerializeField] private string idUser;
    [SerializeField] private string nameUser;
    [SerializeField] private int score;
    [SerializeField] private int calidad = 2;
    [SerializeField] private float volumen = 0;
    [SerializeField] private bool isPantallaCompleta = true;

    private void Awake()
    {
        if (ControllerUser.Instance == null) {
            ControllerUser.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    public void InicioSession(string id, string name) 
    { 
        idUser = id;
        nameUser = name;
    }


    public void SumarPuntos(int puntaje)
    {
            score = puntaje;
    }

    public string GetID()
    {
        return idUser;
    }
    public string GetName()
    {
        return nameUser;
    }

    public int GetScore()
    {
        return score;
    }

    public bool GetPantalla()
    {
        return isPantallaCompleta;
    }

    public float GetVolumen()
    {
        return volumen;
    }

    public int GetCalidad()
    {
        return calidad;
    }

    public void SetPantalla(bool opcion)
    {
        isPantallaCompleta = opcion;
    }

    public void SetVolumen(float Nivel)
    {
        volumen = Nivel;
    }

    public void SetCalidad(int index)
    {
        calidad=index;
    }
}
