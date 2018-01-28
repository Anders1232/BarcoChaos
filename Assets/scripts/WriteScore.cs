using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //its a must to access new UI in script

public class WriteScore : MonoBehaviour
{
	public int[] ScoreVector;

	void Start()
	{
		ScoreVector = GameObject.Find("ScorePoints").GetComponent<Score>().score;
		GameObject.Find("TabScore").GetComponent<Text>().text = "High Score:\n1º = " + ScoreVector[0] + "\n2º = " + ScoreVector[1] + 
			"\n3º = " + ScoreVector[2] + "\n4º = " + ScoreVector[3] + "\n5º = " + ScoreVector[4];
	}
}
