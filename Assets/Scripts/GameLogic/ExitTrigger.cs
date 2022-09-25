using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitTrigger : MonoBehaviour
{
    public LevelChanger levelChanger;
    public TextMeshProUGUI text;

    void Start() 
    {
        text.text = "";
    }
    void OnTriggerEnter(Collider other) 
    {
        text.text = "YOU ESCAPED";
        levelChanger.FadeToLevel(0);
    }
}
