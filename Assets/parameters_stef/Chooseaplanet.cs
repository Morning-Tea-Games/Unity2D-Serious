using System.Collections;
using System.Collections.Generic;
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

    public PlanetInfo selectedPlanetInfo;
    // Update is called once per frame
    void Update()
    {
        ChooseAPlanet();
    }

    void ChooseAPlanet()
    {
        if (dialogues.firstDialogueFinsihed == true)
        {
            Planet1.gameObject.SetActive(true);
            Planet2.gameObject.SetActive(true);
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

        PlanetInfo1.gameObject.SetActive(false);
        PlanetInfo2.gameObject.SetActive(false);
    }


}
