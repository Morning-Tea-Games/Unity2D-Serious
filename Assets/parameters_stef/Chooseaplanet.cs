using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Chooseaplanet : MonoBehaviour
{
    public dialogue dialogues;
    public Image Planet1;
    public Image Planet2;

    public PlanetInfo PlanetInfo1;
    public PlanetInfo PlanetInfo2;

    public bool anyPlanetSelected = false;

    private bool planetsSpawned = false;

    public PlanetInfo selectedPlanetInfo;

    public Transform cornerTargetPosition;

    public bool Done = false;
    void Update()
    {
        ChooseAPlanet();

        if (Done && !dialogues.dialogueText.gameObject.activeSelf)
        {
            dialogues.StartWhileGameDialogue();
            Done = false; 
        }
    }

    void ChooseAPlanet()
    {
        if (!planetsSpawned && dialogues.firstDialogueFinsihed == true)
        {
            Planet1.gameObject.SetActive(true);
            Planet2.gameObject.SetActive(true);
            planetsSpawned = true;
        }
    }

    public void DeselectOther(PlanetInfo selectedPlanet)
    {

        Debug.Log("DeselectOther called. selectedPlanet = " + selectedPlanet.name);

        selectedPlanetInfo = selectedPlanet;

        if (selectedPlanet == PlanetInfo1)
        {
            PlanetInfo2.gameObject.SetActive(false);
            Debug.Log("Disabling object: " + PlanetInfo2.gameObject.name);
        }
        else if (selectedPlanet == PlanetInfo2)
        {
            Debug.Log("We are");
            PlanetInfo1.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Selected planet didn't match any known planet info.");
        }

    }

    public void HidePlanetsAfterDelay(float delaySeconds)
    {
        StartCoroutine(HideBothPlanetsCoroutine(delaySeconds));
    }

    private IEnumerator HideBothPlanetsCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);


        if (selectedPlanetInfo == PlanetInfo1)
        { PlanetInfo2.gameObject.SetActive(false); }
        else if (selectedPlanetInfo == PlanetInfo2)
        { 
            PlanetInfo1.gameObject.SetActive(false); 
        }

        if (selectedPlanetInfo != null && cornerTargetPosition != null)
        {
            RectTransform selectedRect = selectedPlanetInfo.GetComponent<RectTransform>();
            selectedRect.SetParent(cornerTargetPosition.parent, false);
            selectedRect.position = cornerTargetPosition.position;
            selectedRect.localScale = Vector3.one * 0.5f;
        }

        Done = true; // turn on the dialogue
    }


}
