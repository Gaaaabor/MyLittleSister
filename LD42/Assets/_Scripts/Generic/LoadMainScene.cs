﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour {
    public string MapName;

    private void Start()
    {
        SceneManager.LoadScene(MapName);
    }
}
