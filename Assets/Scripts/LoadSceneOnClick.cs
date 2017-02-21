using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneOnClick : MonoBehaviour {

    public string levelToLoad;

    public void LoadByIndex(string level)
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Called from LoadSceneOnClick");
        SceneManager.LoadScene(levelToLoad);
    }
}
