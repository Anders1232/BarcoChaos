using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionScore : MonoBehaviour {
	[SerializeField]
	private int score;
	public int correctDestinyPoints;
	public int wrongDestinyPoints;
	public Score sc;
	// Use this for initialization
	void Start () {
		score = 0;
		sc = GameObject.FindGameObjectWithTag ("ScoreGO").GetComponent<Score> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void WrongDestiny(){
		score-= wrongDestinyPoints;
	}
	public void CorrectDestiny(){
		score += correctDestinyPoints;
	}
	public void SessionEnded(){
		;		sc.NewScore (score);

	}
}
