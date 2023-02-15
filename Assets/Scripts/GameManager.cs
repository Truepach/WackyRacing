using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject platformSpawner;
    public GameObject gamePlayUi;
    
    public bool isGameStarted = false;

    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI startText;
    public TMPro.TextMeshProUGUI endText;
    private HighScore highScoreScript;
    private MenuUiHandler menuUiHandler;
    private CarController carController;

    int score = 0;
    private void Awake()
    {
        if(instance == null) 
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        highScoreScript = FindObjectOfType<HighScore>();
        menuUiHandler= FindObjectOfType<MenuUiHandler>();
        carController= FindObjectOfType<CarController>();
}

    // Update is called once per frame
    void Update()
    {
        if(!isGameStarted) 
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                GameStart();
            }
        }
    }

    public void GameStart()
    {
        isGameStarted = true;
        startText.gameObject.SetActive(false);
        platformSpawner.SetActive(true);
        gamePlayUi.SetActive(true);
        StartCoroutine(UpdateScore());
    }

    public void GameOver()
    {
        platformSpawner.SetActive(false);
        isGameStarted = false;
        GameObject canvas = GameObject.Find("MMCanvas");
        if (canvas != null)
        {
            canvas.SetActive(true);
        }
        StopCoroutine("UpdateScore");
        CheckScore();
        //Invoke("ReloadLevel", 1f);
        Invoke("MainMenu", 1f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("GameRun");
    }

    void MainMenu()
    {
        endText.gameObject.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }

    }

    IEnumerator UpdateScore()
    {
        while (isGameStarted)
        {
            yield return new WaitForSeconds(1f);
            float checkSpeed = carController.moveSpeed;
            if (checkSpeed >= 8)
            {
                score += 4;
            }
            else if (checkSpeed >4 && checkSpeed <8 )
            {
                score += 2;
            }
            else if (checkSpeed < 2)
            {
                score--;
            }
            else
            {
                score++;
            }
            scoreText.text = score.ToString();


        }
    }

    public void CheckScore()
    {
        if (score > highScoreScript.highScore)
        {
            highScoreScript.highScore = score;
            highScoreScript.SaveHighScore();

        }   
    }
}
