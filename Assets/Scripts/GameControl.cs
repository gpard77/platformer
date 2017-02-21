using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public float health;
    public float experience;
    public int coinCount;
    public int sceneToLoad;

    private LevelManager theLevelManager;

	// Use this for initialization
	void Awake () {
        theLevelManager = FindObjectOfType<LevelManager>();

        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        } 
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    /*
    // If we want persistant on screen marker for health
    public void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Health: " + health);
    }*/

    /*
     * Saving To File will work for playing locally...
     * WebGL instances would require reading/writing to files on server
     */
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.posx = transform.position.x;
        data.posy = transform.position.y;
        data.posz = transform.position.z;
        //data.health = health;
        //data.experience = experience;
        //data.coinCount = theLevelManager.getCoinCount(); 
        data.coinCount = coinCount;       
        data.sceneToLoad = SceneManager.GetActiveScene().buildIndex;

        Debug.Log("Called from within save");
        Debug.Log("Coin Count:" + coinCount);

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            transform.position = new Vector3(data.posx, data.posy, data.posz);
            health = data.health;
            experience = data.experience;
            coinCount = data.coinCount;

            //theLevelManager.AddCoins(coinCount);

            SceneManager.LoadScene(data.sceneToLoad);
            
        }
    }
}

[Serializable]
class PlayerData
{
    public float health;
    public float experience;
    public float posx;
    public float posy;
    public float posz;
    public int sceneToLoad;
    public int coinCount;
}
