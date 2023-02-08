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
        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("GameRun");
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
}
