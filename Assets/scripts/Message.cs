using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour {
	public Rigidbody2D rb;
	private GameObject[] tiles;
	public enum Crew{
		ALMIRANTE,
		IMEDIATO,
		ENGENHEIRO,
		COZINHEIRO
	};
	public Crew origin;
	public Crew destiny;
//	public int currentTile;
//	public float timePerTile;
//	private float currentTileEnterTimeSpan;
	public Pipe.Direction currentDirection;
//	private bool starting;
	public float speed;

	private Pipe currentPipe;
	// Use this for initialization
	void Start () {
		tiles = GameObject.FindGameObjectWithTag ("GameController").GetComponent<MyTileMap>().tiles;
//		currentTileEnterTimeSpan = Time.time;
//		starting = true;
//		speed = (tiles [currentTile].transform.position - gameObject.transform.position) / timePerTile;
		rb= GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2 (speed, 0);
	}

	public void SetDestiny(Vector2 destiny){
		
	}
	
	// Update is called once per frame
	void Update () {
/*		if (starting) {
			transform.position = transform.position + speed * Time.deltaTime;
			if (Time.time - currentTileEnterTimeSpan > timePerTile) {		//hora de entrar no próx tile
				starting = false;
				currentTileEnterTimeSpan = Time.time;
				currentPipe = tiles [currentTile].GetComponent<Pipe> ();
			}
		} else {
			if (Pipe.Direction.INVALID == currentPipe.PipeOrientation ()) {
				Debug.Log ("Vc falhou!");
				Application.Quit ();
			}
			else if(speed.y>0 ){// está descendo
				
			}
			else if (Pipe.PipeType.curve == currentPipe.pipeType) {
			} else if (Pipe.PipeType.doubleCurve == currentPipe.pipeType) {
			} else if (Pipe.PipeType.plus == currentPipe.pipeType) {
			} else if (Pipe.PipeType.straight == currentPipe.pipeType) {
			} else {
			}
		}*/
	}
}
