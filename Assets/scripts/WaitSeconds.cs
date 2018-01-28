using UnityEngine;
using System.Collections;

public class WaitSeconds : MonoBehaviour {
	
	public float seconds;
	public GameObject GameOverBackground;
	public GameObject AtivaCanvas;

	void Start()
	{
		StartCoroutine(Wait());
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(seconds);
		GameOverBackground.SetActive (false);
		AtivaCanvas.SetActive (true);
	}
}
