using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//La clase Player que hereda de Character
public class Player : Character
{
    public HealthBar healthBarPrefab;//Referencia a Prefab
    HealthBar healthBar; //Barra de vida instanciada

    // Este método se ejecuta una vez
    private void Start()
    {
        hitPoints.value = startingHitPoints; //Puntos Iniciales
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
    }
    /*
    * Método invocado cuando otro collider colisiona.
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Verifica si el objeto colisionado tiene como etiqueta CanBePickedUp
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {

            Item hitObject = collision.gameObject.GetComponent<Comsumible>().item;

            if (hitObject != null)
            {
                bool shouldDisappear = false;
                print("Nombre: " + hitObject.objectName);

                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN:
                        shouldDisappear = true;
                        break;
                    case Item.ItemType.HEALTH:
                        shouldDisappear = AdjustHitPoints(hitObject.quantity);
                        break;
                    default:
                        break;
                }


                if (shouldDisappear)
                {
                    //Ocultamos el objeto de la escena
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }


    public bool AdjustHitPoints(int amount)
    {
        if (hitPoints.value < maxHitPoints)
        {
            hitPoints.value = hitPoints.value + amount;
            print("Ajustando Puntos: " + amount + ". Nuevo Valor: " + hitPoints.value);
            return true;
        }
        return false;
    }

}
