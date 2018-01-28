using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	public void RestartButton(string openingLevel)
	{
		SceneManager.LoadScene (openingLevel);
	}

	public void MainMenuButton(string mainMenuLevel)
	{
		SceneManager.LoadScene (mainMenuLevel);
	}
}
