using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour {

	public string currentLevel;
	public GameObject eleMesmo;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		currentLevel = SceneManager.GetActiveScene().name;
		if (currentLevel == "first")
			eleMesmo.SetActive (false);
	}

	private static PlayMusic instance = null;
	public static PlayMusic Instance {
		get { return instance; }
	}

	void Awake() {
		currentLevel = SceneManager.GetActiveScene().name;
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}

		Debug.Log ("currentLevel = " + currentLevel);
		DontDestroyOnLoad (this.gameObject);
	}
}
