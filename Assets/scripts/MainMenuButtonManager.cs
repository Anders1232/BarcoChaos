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

	public void CreditsButton()
	{
		Debug.Log ("Credits funfou!");
	}

	public void ScoreButton()
	{
		Debug.Log ("Tabela Score funfou!");
	}
}
