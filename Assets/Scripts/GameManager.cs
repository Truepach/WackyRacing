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
    private HighScore highScoreScript;
    private MenuUiHandler menuUiHandler;

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

        SceneManager.LoadScene(0);

    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            score++;
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
