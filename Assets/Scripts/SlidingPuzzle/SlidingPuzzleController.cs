using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlidingPuzzleController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool puzzleComplete = false;
    bool solved = false;
    public TextMeshProUGUI puzzleText;
    public GameObject slidingPuzzle;
    public GameObject[] lightArray;
    public GameObject[] wallArray;
    public Material baseMaterial;
    public Material poweredMaterial;
    public AudioSource audioSource;
    public AudioClip poweredAudio;
    public GameObject lightButtonPuzzle;
    public GameObject hint;
    void Start()
    {
        lightArray = GameObject.FindGameObjectsWithTag("GeneratorLight");
        wallArray = GameObject.FindGameObjectsWithTag("GeneratorWall");
        audioSource = GetComponent<AudioSource>();
        foreach (GameObject light in lightArray)
        {
            light.SetActive(false);
        }
        foreach (GameObject wall in wallArray)
        {
            wall.GetComponent<Renderer>().material = baseMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (slidingPuzzle.GetComponent<ST_PuzzleDisplay>().isActiveAndEnabled == true)
        {
            puzzleComplete = slidingPuzzle.GetComponent<ST_PuzzleDisplay>().Complete;
            if (puzzleComplete && !solved)
            {
                StartCoroutine(PowerOn());
            }
        }
    }

    IEnumerator PowerOn()
    {
        solved = true;
        puzzleText.text = "Alignment complete. Powering on...";
        int lightArrayLen = lightArray.Length;
        for (int i = 0; i < lightArrayLen / 3; i++)
        {
            lightArray[i].SetActive(true);
        }
        int wallArrayLen = wallArray.Length;
        for (int i = 0; i < wallArrayLen / 3; i++)
        {
            wallArray[i].GetComponent<Renderer>().material = poweredMaterial;
        }
        audioSource.clip = poweredAudio;
        audioSource.Play();
        yield return new WaitForSeconds(1.5f);
        for (int i = lightArrayLen / 3; i < (lightArrayLen / 3) * 2; i++)
        {
            lightArray[i].SetActive(true);
        }
        for (int i = wallArrayLen / 3; i < (wallArrayLen / 3) * 2; i++)
        {
            wallArray[i].GetComponent<Renderer>().material = poweredMaterial;
        }
        audioSource.Play();
        yield return new WaitForSeconds(1.5f);
        for (int i = (lightArrayLen / 3)*2; i < lightArrayLen -1; i++)
        {
            lightArray[i].SetActive(true);
        }
        for (int i = (wallArrayLen / 3)*2; i < wallArrayLen -1; i++)
        {
            wallArray[i].GetComponent<Renderer>().material = poweredMaterial;
        }
        audioSource.Play();
        lightButtonPuzzle.SendMessage("ToggleLocked");
        puzzleText.text = "Power restored.";
        hint.SetActive(true);
    }
}
