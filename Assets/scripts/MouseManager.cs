using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {

	public Vector2 GetMousePos(float z){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.Log (ray.origin+ "\t\t" + ray.direction);
		float factor = (z-ray.origin.z)/ray.direction.z;
		Vector3 gotcha = ray.direction*factor;
		Debug.Log (factor+ "\t\t" + gotcha);
		return new Vector2 (gotcha.x, gotcha.y);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			GetMousePos (0);
		}
	}
}
