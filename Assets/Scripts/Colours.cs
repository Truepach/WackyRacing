using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colours : MonoBehaviour
{

    public Color selectedColor;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

