using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    private LevelManager theLevelManager;

    public int coinValue;
    public int keyType;

	// Use this for initialization
	void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theLevelManager.AddCoins(coinValue);
            theLevelManager.AddKey(keyType);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
