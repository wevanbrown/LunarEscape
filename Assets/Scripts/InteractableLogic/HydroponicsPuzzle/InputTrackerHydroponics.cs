using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputTrackerHydroponics : MonoBehaviour
{
    public Queue<char> answer = new Queue<char>();

    private Dictionary<KeyCode, char> keycodeToChar = new Dictionary<KeyCode, char>(){
          {KeyCode.A, 'A'},
          {KeyCode.B, 'B'},
          {KeyCode.C, 'C'},
          {KeyCode.D, 'D'},
          {KeyCode.E, 'E'},
          {KeyCode.F, 'F'},
          {KeyCode.G, 'G'},
          {KeyCode.H, 'H'},
          {KeyCode.I, 'I'},
          {KeyCode.J, 'J'},
          {KeyCode.K, 'K'},
          {KeyCode.L, 'L'},
          {KeyCode.M, 'M'},
          {KeyCode.N, 'N'},
          {KeyCode.O, 'O'},
          {KeyCode.P, 'P'},
          {KeyCode.Q, 'Q'},
          {KeyCode.R, 'R'},
          {KeyCode.S, 'S'},
          {KeyCode.T, 'T'},
          {KeyCode.U, 'U'},
          {KeyCode.V, 'V'},
          {KeyCode.W, 'W'},
          {KeyCode.X, 'X'},
          {KeyCode.Y, 'Y'},
          {KeyCode.Z, 'Z'}
    };

    private string solution = "SOLAR";

    public GameObject hydroponicsDoor;
    public HydroponicsLightPuzzle lightController;
    public GameObject hint;

    public AudioSource audioSource;
    public AudioClip poweredAudio;

    void Start()
    {
        answer.Enqueue(' ');
        answer.Enqueue(' ');
        answer.Enqueue(' ');
        answer.Enqueue(' ');
        answer.Enqueue(' ');
    }

    void PrintAnswer()
    {
        GetComponent<TextMeshProUGUI>().text = "<mspace=0.7em>" + string.Join(" ", answer.ToArray()) + "</mspace>";
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyValuePair<KeyCode, char> pair in keycodeToChar)
        {
            if (Input.GetKeyDown(pair.Key))
            {
                answer.Dequeue();
                answer.Enqueue(pair.Value);
                PrintAnswer();
                if (solution.Equals(string.Join("", answer.ToArray())))
                {
                    hydroponicsDoor.SendMessage("ToggleLocked");
                    lightController.SendMessage("ToggleSolvedLights");
                    hint.SetActive(true);
                    audioSource.PlayOneShot(poweredAudio);
                    transform.parent.gameObject.SetActive(false);
                }
            }
        }
    }
}
