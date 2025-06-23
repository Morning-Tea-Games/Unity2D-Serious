using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSelectionManager : MonoBehaviour
{
    public static PlanetSelectionManager instance;

    public List<GameObject> AllPlanets = new List<GameObject>();


    private GameObject currentSelected = null;
    private void Awake()
    {
        instance = this; 
    }

    public void SelectPlanet(GameObject selected)
    {
      
        foreach (GameObject planet in AllPlanets)
        {
            if (planet == selected)
            {
                planet.transform.localScale = Vector3.one;
                planet.transform.localScale *= 1.2f;
                currentSelected = selected;
            }
            else
            {
                planet.SetActive(false); 
            }
        }
    }
 }
    
