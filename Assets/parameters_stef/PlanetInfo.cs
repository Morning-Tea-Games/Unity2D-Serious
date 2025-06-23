using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Numerics;

public class PlanetInfo : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Chooseaplanet planet;

    public TMP_Text planetNameText;
    public TMP_Text descriptionText;
    public GameObject panel;

    public string nameText;
    public string description;


    public bool isSelected = false;
    // Start is called before the first frame update

    private void Start()
    {
        panel.SetActive(false);
    }
  
    public void OnPointerEnter(PointerEventData eventData)
    {

            panel.SetActive(true);
            planetNameText.text = nameText;
            descriptionText.text = description;
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {

            panel.SetActive(false);
     
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (planet.anyPlanetSelected) return;

        isSelected = true;
        planet.anyPlanetSelected = true;

        Debug.Log("Планетa убралась");

        panel.SetActive(false);
        transform.localScale *= 1.2f;

        planet.DeselectOther(this);

        planet.HidePlanetsAfterDelay(3f);
    }
}
