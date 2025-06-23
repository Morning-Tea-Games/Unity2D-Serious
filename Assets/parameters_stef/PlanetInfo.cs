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

    public GameObject cornerCopyPrefab; 
    public Transform cornerTargetPosition;

    public bool isSelected = false;
    // Start is called before the first frame update

    private void Start()
    {
        panel.SetActive(false);
    }
  
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isSelected)
        {
            panel.SetActive(true);
            planetNameText.text = nameText;
            descriptionText.text = description;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        if (!isSelected)
        {
            panel.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (planet.anyPlanetSelected) return;

        isSelected = true;
        planet.anyPlanetSelected = true;

        Debug.Log("Планет убралась");

        panel.SetActive(false);
        transform.localScale *= 1.2f;

        planet.DeselectOther(this);

        planet.HidePlanetsAfterDelay(2f);
    }
/*    IEnumerator SelectAndMove()
    {
        transform.localScale *= 1.2f;
        yield return new WaitForSeconds(2f);

        transform.localScale /= 1.2f;

        gameObject.SetActive(false);

        if (cornerCopyPrefab != null && cornerTargetPosition != null)
        {
            GameObject copy = Instantiate(cornerCopyPrefab, cornerTargetPosition.position, Quaternion.identity);
            copy.transform.SetParent(cornerTargetPosition.parent); // Если это UI
        }
    }*/
}
