using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pipe : MonoBehaviour {

	public enum PipeType {
		straight,
		curve,
		doubleCurve,
		empty,
		plus
	};
	public PipeType pipeType;

	public enum Direction{
		UP,
		RIGHT,
		DOWN,
		LEFT,
		INVALID
	};

	private float angle = 0;
	public float rotateSpeed;
	private bool rotating = false;
	private Direction lastDirection;

	// Considere que a saída do cano gira no sentido horário, a partir da entrada
	public Direction PipeOrientation(){
		if (angle == 0)
			return Direction.UP;
		if (angle == 90)
			return Direction.RIGHT;
		if (angle == 180)
			return Direction.DOWN;
		if (angle == 270)
			return Direction.LEFT;
		
		return Direction.INVALID;
	}

	public void Rotate()
	{
		if (!rotating) {
			lastDirection = PipeOrientation ();
			rotating = true;
			Debug.Log ("Rotate called!");
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (rotating)
		{
			float deltaAngle = rotateSpeed * Time.deltaTime;
			angle += deltaAngle;
			Vector3 currentRotation = gameObject.transform.localRotation.eulerAngles;
			float newAngle = currentRotation.z + deltaAngle;
//			Debug.Log (deltaAngle);
			if (Mathf.CeilToInt (currentRotation.z) / 90 != Mathf.CeilToInt (newAngle) / 90) {
				if (lastDirection == Direction.UP) {
					angle = 90;
				}
				else if(lastDirection == Direction.RIGHT){
					angle = 180;
				}
				else if(lastDirection == Direction.DOWN){
					angle = 270;
				}
				else if(lastDirection == Direction.UP){
					angle = 0;
				}
				gameObject.transform.rotation = Quaternion.Euler (currentRotation.x, currentRotation.y, angle);
				rotating = false;
			} else {
				gameObject.transform.rotation = Quaternion.Euler (currentRotation.x, currentRotation.y, newAngle);
			}
		}
	}
}
