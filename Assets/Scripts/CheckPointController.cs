﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour {

    public Sprite flagClosed;
    public Sprite flagOpen;
    public bool checkPointActive;

    private SpriteRenderer theSpriteRenderer;

	// Use this for initialization
	void Start () {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theSpriteRenderer.sprite = flagOpen;
            checkPointActive = true; 
        }
    }
}
