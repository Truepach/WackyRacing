using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUiHandler : MonoBehaviour
{
    public static MenuUiHandler Instance;
    public TitleCar titleCar;
    public TMPro.TextMeshProUGUI highScoreText;
    private HighScore highScore;


    private void Start()
    {
        highScore = FindObjectOfType<HighScore>();
        SetHighScore();
 
    }

    public void StartGame()
    {
        StartCoroutine(CheckStart());
    }
    public IEnumerator CheckStart()
    {
        Audio.Instance.PlaySoundEffectWithDelay(0);
        
        float timer = 4f;
        while (timer > 0)
        {
            titleCar.MoveForward();
            timer -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(1);
        gameObject.SetActive(false);

    }

    public void SetHighScore()
    {
        int score = highScore.highScore;

        highScoreText.text = "Highscore: " + score;

    }

    public void MenuUiLoad()
    {
        gameObject.SetActive(true);
    }
}