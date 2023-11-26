using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtIUController : MonoBehaviour
{
    public GameObject playerOrEnemy; 

    public GameObject heartContainer;
    private Image fillImage;

    private Healt healthComponent;

    void Start()
    {
        fillImage = heartContainer.GetComponent<Image>();

        healthComponent = playerOrEnemy.GetComponent<Healt>();
        
    }

    void Update()
    {
         float fillValue = healthComponent.GetHealthPercent();
         fillImage.fillAmount = fillValue ;
        
    }
}
