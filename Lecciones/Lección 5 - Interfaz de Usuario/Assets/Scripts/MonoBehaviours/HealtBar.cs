using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HitPoints hitPoints; //Referencia scriptable objects


    [HideInInspector] //Oculta la propiedad en el Inspector
    public Player character; //Barra de vida de jugador
    public Image meterImage; //Imagen del medidor
    public Text hpText; //Texto o leyenda de la barra de vida
    float maxHitPoints; //Puntos máximos de la barra de vida


    // Se inicia una sola vez al principio
    void Start()
    {
        maxHitPoints = character.maxHitPoints;
    }


    // Update is called once per frame
    void Update()
    {
        if (character != null)
        {
            meterImage.fillAmount = hitPoints.value / maxHitPoints;
            hpText.text = "HP:" + (meterImage.fillAmount * 100);
        }
    }
}

