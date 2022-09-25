using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalPuzzle : MonoBehaviour
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

    private string[] possibleSolutions =
    {
        "HENE",
        "LUNA",
        "MANE",
        "MAAN",
        "LUNE",
        "HOLD",
        "MOON"
    };


    private string solution;

    public TextMeshProUGUI hint1, hint2, hint3, hint4;

    public Animator finalDoorOne;

    void Start()
    {
        answer.Enqueue(' ');
        answer.Enqueue(' ');
        answer.Enqueue(' ');
        answer.Enqueue(' ');

        solution = possibleSolutions[Random.Range(0, possibleSolutions.Length)];
        Debug.Log(solution);
        hint1.text = solution.Substring(0,1);
        hint2.text = solution.Substring(1,1);
        hint3.text = solution.Substring(2,1);
        hint4.text = solution.Substring(3,1);
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
                    finalDoorOne.SetBool("wordleSolved", true);
                }
            }
        }
    }
}
