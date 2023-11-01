using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public HitPoints hitPoints; //Referencia
    public float maxHitPoints; //Puntos de vida máximos
    public float startingHitPoints; //Agregar la variable - Puntos de vida iniciales
}
