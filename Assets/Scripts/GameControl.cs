using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public float health;
    public float experience;

	// Use this for initialization
	void Awake () {
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

    // If we want persistant on screen marker for health
    public void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Health: " + health);
    }

    /*
     * Saving To File will work for playing locally...
     * WebGL instances would require reading/writing to files on server
     */
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.health = health;
        data.experience = experience;

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

            health = data.health;
            experience = data.experience;
        }
    }
}

[Serializable]
class PlayerData
{
    public float health;
    public float experience;


}
