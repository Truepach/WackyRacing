using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUiHandler : MonoBehaviour
{
    public TitleCar titleCar;


    private void Start()
    {

    }

    public void StartGame()
    {
        StartCoroutine(CheckStart());
    }
    public IEnumerator CheckStart()
    {

        float timer = 4f;
        while (timer > 0)
        {
            titleCar.MoveForward();
            timer -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(1);
    }
}