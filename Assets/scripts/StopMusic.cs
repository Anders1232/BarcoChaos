using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopMusic : MonoBehaviour {

	public string currentLevel;
	public GameObject eleMesmo;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		currentLevel = SceneManager.GetActiveScene().name;
		if (currentLevel == "game_over")
			eleMesmo.SetActive (false);
		if (currentLevel == "main_menu" || currentLevel == "first") {
			eleMesmo.SetActive (true);
		}
	}

	private static StopMusic instance = null;
	public static StopMusic Instance {
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
