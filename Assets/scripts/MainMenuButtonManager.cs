using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonManager : MonoBehaviour {

	public void StartGameButton(string openingLevel)
	{
		SceneManager.LoadScene (openingLevel);
	}

	public void ExitGameButton()
	{
		Application.Quit();
	}

	public void CreditsButton(string creditsLevel)
	{
		SceneManager.LoadScene (creditsLevel);
	}

	public void ScoreButton(string scoreLevel)
	{
		SceneManager.LoadScene (scoreLevel);
	}
}
