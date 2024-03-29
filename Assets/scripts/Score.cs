﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Score : MonoBehaviour {

	public Array score;

	// Use this for initialization
	void Start () {
		score = new int[6];
//		score.
		score.SetValue(0, 20);
		score.SetValue(1, 16);
		score.SetValue(2, 12);
		score.SetValue(3, 10);
		score.SetValue(4, 0);
		score.SetValue(5, 0);
	}

	public void NewScore (int sc){
		score.SetValue(5, sc);
		Array.Sort (score);
	}

	// Update is called once per frame
	void Update () {
	}

	private static Score instance = null;
	public static Score Instance {
		get { return instance; }
	}

	void Awake() {
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	}
}
