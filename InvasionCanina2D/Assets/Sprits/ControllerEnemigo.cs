using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControllerEnemigo : MonoBehaviour
{
    private float minX, maxX, minY, maxY;

    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float tiempoEnemigos;

    private float tiemposSiguienteEnemigo;

    private void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
    }

    private void Update()
    {
        tiemposSiguienteEnemigo += Time.deltaTime;

        if (tiemposSiguienteEnemigo >= tiempoEnemigos) 
        {
            tiemposSiguienteEnemigo = 0;

            CrearEnemigo();
        }
    }

    private void CrearEnemigo()
    {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));

        Instantiate(enemigos[numeroEnemigo],posicionAleatoria, Quaternion.identity);
    }
}
