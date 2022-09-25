using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydroponicsLightPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] lightArray;
    public bool lightsFlipped = false;
    public Color32 panicColor;
    public Color32 uvColor;
    public Color32 solvedColor;
    public GameObject UVText;
    public GameObject FootprintText;
    public bool puzzleComplete;
    
    void Start()
    {
        UVText.SetActive(false);
        FootprintText.SetActive(false);
        lightArray = GameObject.FindGameObjectsWithTag("BotanicalLight");
        foreach (GameObject light in lightArray)
        {
            light.GetComponent<Light>().color = panicColor;
        }
    }

    // Update is called once per frame

    void ToggleUVLights()
    {
        if (!lightsFlipped)
        {
            foreach (GameObject light in lightArray)
            {
                light.GetComponent<Light>().color = uvColor;
            }
            lightsFlipped = true;
            UVText.SetActive(true);
            FootprintText.SetActive(true);
        }
        else {
            foreach (GameObject light in lightArray)
            {
                if(puzzleComplete)
                {
                    light.GetComponent<Light>().color = solvedColor;
                }
                else
                {
                    light.GetComponent<Light>().color = panicColor;
                }
            }
            lightsFlipped = false;
            UVText.SetActive(false);
            FootprintText.SetActive(false);
        }
    }

    void ToggleSolvedLights()
    {
        puzzleComplete = true;
        foreach (GameObject light in lightArray)
            {
                light.GetComponent<Light>().color = solvedColor;
            }
    }

}
