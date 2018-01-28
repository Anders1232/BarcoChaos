using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //its a must to access new UI in script
using System;

public class WriteScore : MonoBehaviour
{
	public Array ScoreVector;

	void Start()
	{
		ScoreVector = GameObject.Find("ScorePoints").GetComponent<Score>().score;
		GameObject.Find("TabScore").GetComponent<Text>().text = "HIGH SCORES:\n\n\n1º = " + ScoreVector.GetValue(0) + "\n\n2º = " + ScoreVector.GetValue(1) + 
			"\n\n3º = " + ScoreVector.GetValue(2) + "\n\n4º = " + ScoreVector.GetValue(3) + "\n\n5º = " + ScoreVector.GetValue(4);
	}
}
