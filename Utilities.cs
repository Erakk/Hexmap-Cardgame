﻿using UnityEngine;
using System.Collections;

public class Utilities : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static public GameObject PlayerDeck()
	{
		return GameObject.Find("Deck");
	}
}
