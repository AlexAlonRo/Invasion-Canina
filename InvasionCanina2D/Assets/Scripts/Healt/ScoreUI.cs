using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public GameObject player;

    public Text label;

    private Healt healthComponent;

    void Start()
    {
        healthComponent = player.GetComponent<Healt>();
    }

    void Update()
    {
        if (healthComponent != null && label != null)
        {
            int puntaje = Healt.ObtenerPuntaje();
            label.text = $"Puntaje : {puntaje}";
            Debug.Log("Puntaje actual: " + puntaje);
        }
    }
}
