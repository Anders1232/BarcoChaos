using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour {
	public Rigidbody2D rb;
//	private GameObject[] tiles;
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
	public SpriteRenderer sr;
	public Sprite spMsgPraAlmirante;
	public Sprite spMsgPraImediato;
	public Sprite spMsgPraCozinheiro;
	public Sprite spMsgPraEngenheiro;

	private Pipe currentPipe;
	// Use this for initialization
	void Start () {
		rb= GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer> ();
	}

	public void Init(Crew origin, Crew destiny){
		this.origin = origin;
		this.destiny = destiny;
		Vector2 firstPipe= new Vector2(0f, 0f);
		if (origin == Crew.ALMIRANTE) {
			firstPipe = new Vector2 (-2.455f, 1.8f);
		}
		else if (origin == Crew.IMEDIATO) {
			firstPipe = new Vector2 (0.545f, 1.8f);
		}
		else if (origin == Crew.ENGENHEIRO) {
			firstPipe = new Vector2 (-2.455f, -1.2f);
		}
		else if (origin == Crew.COZINHEIRO) {
			firstPipe = new Vector2 (0.545f, -1.2f);
		}
		if (destiny == Crew.ALMIRANTE) {
			sr.sprite = spMsgPraAlmirante;
		}
		else if (destiny == Crew.IMEDIATO) {
			sr.sprite = spMsgPraImediato;
		}
		else if (destiny == Crew.ENGENHEIRO) {
			sr.sprite = spMsgPraEngenheiro;
		}
		else if (destiny == Crew.COZINHEIRO) {
			sr.sprite = spMsgPraCozinheiro;
		}
		Vector2 msgPos = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
		Vector2 myVelocity = ( (firstPipe - msgPos).normalized) * speed;
		Debug.Log (firstPipe + " " + myVelocity);
		rb.velocity = myVelocity;
		currentDirection = Pipe.Direction.LEFT;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
