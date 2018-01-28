using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour {
	public Sprite almiranteBalloon;
	public Sprite cozinheiroBalloon;
	public Sprite imeditatoBalloon;
	public Sprite engenheiroBalloon;
	public Message.Crew crewMember;
	public float timeSinceLastTry;
	public float timeBetweenTries;
	public float messageRatio;
	public SpriteRenderer sr;
	private Sprite[] possibleMessages;
	public float timeBalloonIsShowing;
	public float timeToShowBalloon;
	public GameObject message;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		timeSinceLastTry = 0;
		if (Message.Crew.ALMIRANTE == crewMember) {
			possibleMessages = new Sprite[] { cozinheiroBalloon, imeditatoBalloon, engenheiroBalloon };
		} else if (Message.Crew.COZINHEIRO == crewMember) {
			possibleMessages = new Sprite[] { almiranteBalloon, imeditatoBalloon, engenheiroBalloon };
		} else if (Message.Crew.ENGENHEIRO == crewMember) {
			possibleMessages = new Sprite[] { almiranteBalloon, imeditatoBalloon, cozinheiroBalloon };
		} else if (Message.Crew.IMEDIATO == crewMember) {
			possibleMessages = new Sprite[] { almiranteBalloon, engenheiroBalloon, cozinheiroBalloon };
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (sr.sprite == null) {
			timeSinceLastTry += Time.deltaTime;
			if (timeSinceLastTry > timeBetweenTries) {
				timeSinceLastTry = 0;
				if (Random.value < messageRatio) {
					sr.sprite = possibleMessages [Random.Range (0, possibleMessages.Length)];
					timeBalloonIsShowing = 0;
					CreateMessage ();
				}
			}
		} else {
			timeBalloonIsShowing += Time.deltaTime;
			if (timeBalloonIsShowing > timeToShowBalloon) {
				timeBalloonIsShowing = 0;
				sr.sprite = null;
			}
		}
	}
	void CreateMessage(){
		GameObject newBalloon = Object.Instantiate (message, gameObject.transform, true) as GameObject;
		newBalloon.transform.parent = null;
		newBalloon.transform.position = gameObject.transform.position;
		Message msg= newBalloon.GetComponent<Message> ();
		Message.Crew dest= Message.Crew.ALMIRANTE;
		if (sr.sprite.Equals (almiranteBalloon)) {
			dest = Message.Crew.ALMIRANTE;
		}
		else if(sr.sprite.Equals (imeditatoBalloon) ) {
			dest= Message.Crew.IMEDIATO;
		}
		else if(sr.sprite.Equals (engenheiroBalloon)){
			dest= Message.Crew.ENGENHEIRO;
		}
		else if(sr.sprite.Equals (cozinheiroBalloon)){
			dest= Message.Crew.COZINHEIRO;
		}
		msg.Init (crewMember, dest);
	}
}
