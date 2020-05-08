using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public UnityEngine.UI.Text scoreLabel;
    public UnityEngine.UI.Image menu;
    public UnityEngine.UI.Button startButton;


    int score = 0;
    public bool isStarted = false; //проверка на запуск игры
    public bool paused = false; //проверка на паузу

    public static GameController instance;

    public void incrementScore(int increment)
    {
        score += increment;
        scoreLabel.text = "Score :" + score;
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        startButton.onClick.AddListener(delegate{
            menu.gameObject.SetActive(false);
            isStarted = true;
        });
        }

    void Update()
    {
        if(Input.GetButtonUp("Cancel")){
        Time.timeScale = 0;
         paused=true;
        }
        if(Input.GetButtonUp("Cancel") && (paused = true)){
        Time.timeScale = 1;
         paused=false;
        }
}
}


