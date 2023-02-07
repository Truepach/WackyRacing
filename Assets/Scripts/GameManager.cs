using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject platformSpawner;
    public bool isGameStarted = false;
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
    }

    public void GameOver()
    {
        platformSpawner.SetActive(false);
        isGameStarted = false;
    }
}
