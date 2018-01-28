using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsAndScoreButtonManager : MonoBehaviour {

	public void MainMenuButton(string openingLevel)
	{
		SceneManager.LoadScene (openingLevel);
	}
}
