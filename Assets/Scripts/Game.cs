using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game : MonoBehaviour {

    public static Game current;
    public Character pc;

    public Game()
    {
        pc = new Character();
    }
}
