using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

	public int[] score;

	// Use this for initialization
	void Start () {
		score = new int[5];

		score[0] = 20;
		score[1] = 16;
		score[2] = 12;
		score[3] = 10;
		score[4] = 0;
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
