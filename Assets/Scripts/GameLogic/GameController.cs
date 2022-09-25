using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public GameOver gameOver;
    public GameObject interactionCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        gameOver.Setup();
        interactionCanvas.SetActive(false);
        Time.timeScale = 0;
    }
}
