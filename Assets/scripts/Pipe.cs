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
		if (angle < 1f)
			return Direction.UP;
		if (angle- 90f < 1f)
			return Direction.LEFT;
		if (angle- 180f < 1f)
			return Direction.DOWN;
		if (angle- 270f < 1f)
			return Direction.RIGHT;
		
		return Direction.INVALID;
	}

	public void Rotate()
	{
		if (!rotating) {
			lastDirection = PipeOrientation ();
			rotating = true;
//			Debug.Log ("Rotate called!");
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
					angle = 0;
				}
				else if(lastDirection == Direction.DOWN){
					angle = 270;
				}
				else if(lastDirection == Direction.UP){
					angle = 180;
				}
				gameObject.transform.rotation = Quaternion.Euler (currentRotation.x, currentRotation.y, angle);
				rotating = false;
			} else {
				gameObject.transform.rotation = Quaternion.Euler (currentRotation.x, currentRotation.y, newAngle);
			}
		}
	}
	public void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("Pipe::OnTrigerEnter called! Pipe orientation is " +  PipeOrientation());
		if (PipeOrientation () == Direction.INVALID) {
			Debug.LogError ("Pipe was rotating!");
			Application.Quit ();
		}
		if (col.gameObject.tag == "Message") {
			Message msg = col.gameObject.GetComponent<Message> ();
			if (pipeType == PipeType.curve) {
				if (PipeOrientation () == Direction.LEFT) {
					Debug.Log ("Pipe orientation is " + PipeOrientation ());
					if (msg.currentDirection == Direction.RIGHT) {//deve ir para cima
						msg.rb.velocity = new Vector2 (0, msg.speed);
						msg.currentDirection = Direction.UP;
						return;
					} else if (msg.currentDirection == Direction.DOWN) {//deve ir para esquerda
						msg.rb.velocity = new Vector2 (-msg.speed, 0);
						msg.currentDirection = Direction.LEFT;
						return;
					}
				} else if (PipeOrientation () == Direction.UP) {
					if (msg.currentDirection == Direction.DOWN) {//deve ir para a direita
						msg.rb.velocity = new Vector2 (+msg.speed, 0);
						msg.currentDirection = Direction.RIGHT;
						return;
					} else if (msg.currentDirection == Direction.LEFT) {
						col.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, msg.speed);
						msg.currentDirection = Direction.UP;
						return;
					}
				} else if (PipeOrientation () == Direction.RIGHT) {
					if (msg.currentDirection == Direction.UP) {//deve ir para a direita
						msg.rb.velocity = new Vector2 (msg.speed, 0);
						msg.currentDirection = Direction.RIGHT;
						return;
					} else if (msg.currentDirection == Direction.LEFT) {
						msg.rb.velocity = new Vector2 (0, -msg.speed);
						msg.currentDirection = Direction.DOWN;
						return;
					}
				} else if (PipeOrientation () == Direction.DOWN) {
					if (msg.currentDirection == Direction.UP) {//deve ir para a direita
						msg.rb.velocity = new Vector2 (-msg.speed, 0);
						msg.currentDirection = Direction.LEFT;
						return;
					} else if (msg.currentDirection == Direction.RIGHT) {
						msg.rb.velocity = new Vector2 (0, -msg.speed);
						msg.currentDirection = Direction.DOWN;
						return;
					}
				}
			} else if (pipeType == PipeType.doubleCurve) {
				if (PipeOrientation () == Direction.UP || PipeOrientation () == Direction.DOWN) {
					if (msg.currentDirection == Direction.UP) {//deve ir para a direita
						msg.rb.velocity = new Vector2 (msg.speed, 0);
						msg.currentDirection = Direction.RIGHT;
						return;
					} else if (msg.currentDirection == Direction.RIGHT) {
						msg.rb.velocity = new Vector2 (0, msg.speed);
						msg.currentDirection = Direction.UP;
						return;
					} else if (msg.currentDirection == Direction.DOWN) {
						msg.rb.velocity = new Vector2 (-msg.speed, 0);
						msg.currentDirection = Direction.LEFT;
						return;
					} else if (msg.currentDirection == Direction.LEFT) {
						msg.rb.velocity = new Vector2 (0, -msg.speed);
						msg.currentDirection = Direction.DOWN;
						return;
					}
				} else if (PipeOrientation () == Direction.LEFT || PipeOrientation () == Direction.RIGHT) {
					if (msg.currentDirection == Direction.UP) {//deve ir para a direita
						msg.rb.velocity = new Vector2 (-msg.speed, 0);
						msg.currentDirection = Direction.LEFT;
						return;
					} else if (msg.currentDirection == Direction.RIGHT) {
						msg.rb.velocity = new Vector2 (0, -msg.speed);
						msg.currentDirection = Direction.DOWN;
						return;
					} else if (msg.currentDirection == Direction.DOWN) {
						msg.rb.velocity = new Vector2 (msg.speed, 0);
						msg.currentDirection = Direction.RIGHT;
						return;
					} else if (msg.currentDirection == Direction.LEFT) {
						msg.rb.velocity = new Vector2 (0, msg.speed);
						msg.currentDirection = Direction.UP;
						return;
					}
					Debug.Log ("não implementado");
				}
			} else if (pipeType == PipeType.straight) {
				if (PipeOrientation () == Direction.UP || PipeOrientation () == Direction.DOWN) {
					if (msg.currentDirection == Direction.RIGHT || msg.currentDirection == Direction.LEFT) {
						Debug.LogError ("Crash!");
						Application.Quit ();
						return;
					}
				}
				if (PipeOrientation () == Direction.RIGHT || PipeOrientation () == Direction.LEFT) {
					if (msg.currentDirection == Direction.UP || msg.currentDirection == Direction.DOWN) {
						Debug.LogError ("Crash!");
						Application.Quit ();
						return;
					}
				}
			} else if (pipeType == PipeType.plus) {
				return;
			} else {
				Debug.LogError ("Crash! Pipe type is " + pipeType + "\t Pipe orientation is " + PipeOrientation() + "\t msg direction is " + msg.currentDirection);
				Application.Quit ();
			}
		}
	}
}
