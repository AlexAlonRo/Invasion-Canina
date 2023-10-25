using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//La clase Player que hereda de Character
public class Player : Character
{

    //Metodo invocado cuando otro colider colisiona.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Verifica si el objeto colisionado tiene como etiqueta CanBePickedUp
        if (collision.gameObject.CompareTag("CanBePickedUp")) 
        {
            Item hitObject = collision.gameObject.GetComponent<Comsumible>().item;

            if (hitObject != null)
            {
                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN:
                        break;
                    case Item.ItemType.HEALTH:
                        AdjustHitPoints(hitObject.quantity);
                        break;
                    default:
                        break;
                }
                print("Nombre: " + hitObject.objectName);
                //Ocultamos el objeto de la escena
                collision.gameObject.SetActive(false);
            }
            
        }
    }
    public void AdjustHitPoints(int amount)
    {
        hitPoints = hitPoints + amount;
        print("Ajustando puntos: " + amount + " nuevo valor: " + hitPoints);
    }
}
