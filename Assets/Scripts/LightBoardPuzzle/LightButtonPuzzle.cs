using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightButtonPuzzle : MonoBehaviour
{
    public bool solved;
    public bool testing;
    public GameObject finalCodeScreen;
    public GameObject hint;
    public TextMeshProUGUI puzzleText;
    public Color32 panicColor;
    public Color32 correctColor;
    public Color32 solvedColor;
    public Light generatorLight;
    public Material generatorOffMaterial;
    public Material generatorOnMaterial;
    public Material generatorSolvedMaterial;
    public AudioSource audioSource;
    public AudioClip genertorSound;
    public AudioClip generatorSound2;
    private GameObject[] buttonArray;
    public GameObject[] lightArray;
    private GameObject[] generatorBatteryArray;
    private GameObject[] sequencedLightArray;
    // Start is called before the first frame update
    void Start()
    {
        buttonArray = GameObject.FindGameObjectsWithTag("LightSequencePuzzleButton");
        lightArray = GameObject.FindGameObjectsWithTag("LightSequencePuzzleLight");
        generatorBatteryArray = GameObject.FindGameObjectsWithTag("GeneratorBattery");
        sequencedLightArray = GameObject.FindGameObjectsWithTag("GeneratorSequencedLight");
        finalCodeScreen.SetActive(true);
        hint.SetActive(false);
        // Lock each button when the game loads
        ToggleLocked();
        foreach (GameObject generator in generatorBatteryArray)
        {
            Material[] materials = generator.GetComponent<Renderer>().materials;
            materials[1] = generatorOffMaterial;
            generator.GetComponent<Renderer>().materials = materials;
            Light[] genLights = generator.GetComponentsInChildren<Light>();
            foreach (Light light in genLights)
            {
                light.enabled = false;
            }
        }
        // Toggle each light in the lightArray (need to add randomness)
        foreach (GameObject light in lightArray)
        {
            light.GetComponent<BoardLight>().SendMessage("ToggleLight");
        }
        foreach (GameObject light in sequencedLightArray)
        {
            light.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int buttonsOn = 0;
        foreach (GameObject light in lightArray)
        {
            if (light.GetComponent<Light>().color == correctColor || light.GetComponent<Light>().color == solvedColor)
            {
                buttonsOn++;
            }
        }
        puzzleText.text = buttonsOn + " of 4 Generators Online";
        foreach (GameObject light in lightArray)
        {
            if (light.GetComponent<Light>().color == panicColor)
            {
                return;
            }
        }
        if (!testing && !solved)
        {
            StartCoroutine(PowerOn());
        }
        if (solved)
        {
            puzzleText.text = "4 of 4 Generators Online. Power restored. All systems online";
        }
    }

    void ToggleLocked()
    {
        foreach (GameObject button in buttonArray)
        {
            button.GetComponent<Interactable>().SendMessage("ToggleLocked");
        }

    }
    IEnumerator PowerOn()
    {
        solved = true;
        finalCodeScreen.SetActive(true);
        puzzleText.text = "Generators online. Powering on...";
        foreach (GameObject light in lightArray)
        {
            light.GetComponent<Light>().color = solvedColor;
        }
        foreach (GameObject button in buttonArray)
        {
            button.GetComponent<Interactable>().SendMessage("ToggleLocked");
        }
        audioSource.Play();
        yield return new WaitForSeconds(2.0f);
        audioSource.clip = genertorSound;
        foreach (GameObject generator in generatorBatteryArray)
        {
            Material[] materials = generator.GetComponent<Renderer>().materials;
            materials[1] = generatorSolvedMaterial;
            generator.GetComponent<Renderer>().materials = materials;
            Light[] genLights = generator.GetComponentsInChildren<Light>();
            foreach (Light light in genLights)
            {
                light.enabled = true;
            }
            audioSource.Play();
            yield return new WaitForSeconds(1.5f);
        }
        yield return new WaitForSeconds(1.0f);
        foreach (GameObject light in sequencedLightArray)
        {
            light.SetActive(true);
        }
        audioSource.clip = generatorSound2;
        audioSource.Play();
        hint.SetActive(true);
    }
}
