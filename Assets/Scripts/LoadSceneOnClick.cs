﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {
    public void LoadByIndex(int sceneIndex)
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(sceneIndex);
    }
}
